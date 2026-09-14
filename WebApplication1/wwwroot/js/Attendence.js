// =========================================================
// ATTENDANCE CALENDAR
// Renders the monthly grid and loads real attendance data
// from /Team/GetMonthlyAttendance for each month shown.
// =========================================================

let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();

let selectYear = document.getElementById("year");
let selectMonth = document.getElementById("month");

// Join date is supplied by the view via window.attendanceJoinDate
// (set in a small inline <script> before this file is loaded).
let joinDate = window.attendanceJoinDate ? new Date(window.attendanceJoinDate) : null;
if (joinDate) joinDate.setHours(0, 0, 0, 0);

function generate_year_range(start, end) {
    let years = "";
    for (let year = start; year <= end; year++) {
        years += "<option value='" + year + "'>" + year + "</option>";
    }
    return years;
}

let createYear = generate_year_range(2000, 3099);
document.getElementById("year").innerHTML = createYear;

let months = [
    "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
];
let days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

let $dataHead = "<tr>";
for (let dhead in days) {
    $dataHead += "<th data-days='" + days[dhead] + "'>" + days[dhead] + "</th>";
}
$dataHead += "</tr>";
document.getElementById("thead-month").innerHTML = $dataHead;

let monthAndYear = document.getElementById("monthAndYear");

// Navigate to the next month
function next() {
    currentYear = currentMonth === 11 ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    getAttendanceData(currentMonth, currentYear);
}

// Navigate to the previous month
function previous() {
    currentYear = currentMonth === 0 ? currentYear - 1 : currentYear;
    currentMonth = currentMonth === 0 ? 11 : currentMonth - 1;
    getAttendanceData(currentMonth, currentYear);
}

// Jump straight to a chosen month/year (wired to the #month/#year selects)
function jump() {
    currentYear = parseInt(selectYear.value);
    currentMonth = parseInt(selectMonth.value);
    getAttendanceData(currentMonth, currentYear);
}

// Fetches the month's attendance records, then draws the grid and fills it in.
function getAttendanceData(month, year) {
    $.ajax({
        type: "GET",
        url: "/Team/GetMonthlyAttendance",
        data: { month: month + 1, year: year },
        success: function (attendanceData) {
            showCalendar(month, year);
            fillCalendar(attendanceData);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching attendance data:", error);
            showCalendar(month, year);
            alert("Failed to fetch attendance data for this month.");
        }
    });
}

// Colors in each day cell based on the fetched attendance records.
// Adds a small status dot + optional time label instead of filling the whole cell.
function fillCalendar(attendanceData) {
    if (!attendanceData) return;

    attendanceData.forEach(record => {
        const dateObj = new Date(record.attendenceDate);
        const date = dateObj.getDate();
        const cell = document.querySelector(`#calendar-body [data-date="${date}"]`);

        // Skip days before the employee joined — those stay locked as "not-joined"
        if (!cell || cell.classList.contains("not-joined-bg")) return;

        const status = record.managerStatus || record.status;
        const time = dateObj.toLocaleTimeString([], { hour: "2-digit", minute: "2-digit", hour12: true });

        function addDot(dotClass) {
            const dot = document.createElement("span");
            dot.className = "status-dot " + dotClass;
            cell.appendChild(dot);
        }

        function addTime() {
            const timeSpan = document.createElement("span");
            timeSpan.className = "attendance-time";
            timeSpan.innerText = time;
            cell.appendChild(timeSpan);
        }

        // A real recorded status always takes priority over the default weekend styling
        cell.classList.remove("weekend-bg");

        if (status === "Present" || status === "Approved") {
            addDot("present-approved-dot");
            addTime();
        } else if (status === "Pending") {
            addDot("present-not-approved-dot");
            addTime();
        } else if (status === "Absent") {
            addDot("absent-dot");
        } else if (status === "Leave") {
            addDot("leave-dot");
        } else if (status === "Working on Leave") {
            addDot("working-leave-dot");
            addTime();
        } else {
            // Unrecognized/blank status on a non-weekend day — leave as a plain default cell.
        }
    });
}

function daysInMonth(iMonth, iYear) {
    return 32 - new Date(iYear, iMonth, 32).getDate();
}

// Builds the empty calendar grid for the given month/year.
function showCalendar(month, year) {
    let firstDay = new Date(year, month, 1).getDay();
    let tbl = document.getElementById("calendar-body");
    tbl.innerHTML = "";
    monthAndYear.innerHTML = months[month] + " " + year;
    selectYear.value = year;
    selectMonth.value = month;

    const totalDays = daysInMonth(month, year);
    let date = 1;

    for (let i = 0; i < 6 && date <= totalDays; i++) {
        let row = document.createElement("tr");

        for (let j = 0; j < 7; j++) {
            let cell = document.createElement("td");

            if ((i === 0 && j < firstDay) || date > totalDays) {
                cell.className = "empty-cell";
            } else {
                cell.setAttribute("data-date", date);
                cell.setAttribute("data-month", month + 1);
                cell.setAttribute("data-year", year);
                cell.setAttribute("data-month_name", months[month]);
                cell.className = "date-picker";
                cell.innerHTML = '<span class="c-day-num">' + date + "</span>";

                const cellDate = new Date(year, month, date);
                cellDate.setHours(0, 0, 0, 0);

                if (joinDate && cellDate < joinDate) {
                    cell.classList.add("not-joined-bg");
                } else if (j === 0) {
                    // Sunday column — real attendance status (if any) overrides this in fillCalendar()
                    cell.classList.add("weekend-bg");
                }

                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                    cell.classList.add("today-highlight");
                }

                date++;
            }

            row.appendChild(cell);
        }

        tbl.appendChild(row);
    }
}

// Initial load — fetches this month's real attendance data instead of
// rendering an empty calendar with no status colors.
getAttendanceData(currentMonth, currentYear);