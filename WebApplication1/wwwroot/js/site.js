// Select all elements with class 'only-digits'
document.querySelectorAll('.only-digits').forEach(function (input) {
    input.addEventListener('input', function () {
        this.value = this.value.replace(/\D/g, ''); // remove non-digits
    });
});
// for set and predict series


function showLoading() {
    document.body.style.cursor = "wait";
}

function closeModal(id) {
    const el = document.getElementById(id);
    const modal = bootstrap.Modal.getInstance(el);
    if (modal) modal.hide();
}

function initRequisition(requisitionType) {
    const input = document.querySelector(`input[data-requisition-type="${requisitionType}"]`);
    if (!input) {
        console.warn?.(`[Requisition] Input not found for: ${requisitionType}`);
        return;
    }

    const form = input.closest('form');
    if (!form) {
        console.warn?.(`[Requisition] Form not found for: ${requisitionType}`);
        return;
    }

    let predictedSeries = null;

    async function loadPredictedSeries() {
        try {
            input.value = '...';
            const response = await fetch(`/series/predict?seriesName=${encodeURIComponent(requisitionType)}`);
            const value = (await response.text()).trim();
            input.value = value;
            predictedSeries = value;
            form.dataset.predictedSeries = value;
        } catch (err) {
            console.error?.(`[Requisition] Failed to load series for ${requisitionType}`, err);
            input.value = 'Auto # Error';
        }
    }

    async function confirmBeforeSubmit(e) {
        e.preventDefault();

        try {
            const response = await fetch(`/series/generate?seriesName=${encodeURIComponent(requisitionType)}`);
            const currentSeries = (await response.text()).trim();

            if (predictedSeries && predictedSeries !== currentSeries) {
                const confirmed = confirm(
                    `Requisition number changed:\n\n` +
                    `Type: ${requisitionType}\n` +
                    `Predicted: ${predictedSeries}\n` +
                    `Current:   ${currentSeries}\n\n` +
                    `Do you want to proceed with ${currentSeries}?`
                );
                if (!confirmed) return;

                input.value = currentSeries;
            }

            form.submit();
        } catch (err) {
            console.error?.(`[Requisition] Submit failed for ${requisitionType}`, err);
            alert(`Failed to confirm requisition. Please try again.`);
        }
    }

    form.addEventListener('submit', confirmBeforeSubmit);

    loadPredictedSeries();
}

//function change() {
//    let SelectOutcome = document.getElementById("Outcome").value;
//    let checkoutbtn = document.getElementById("CustomerDetailsCheckoutBtn");

//    // Check if the selected outcome is "Meeting"
//    if (SelectOutcome === "Meeting") {
//        checkoutbtn.style.display = "none"; // Hide the button if the outcome is "Meeting"
//    } else {

//        checkoutbtn.style.display = "block";
//    }
//    outcomes();
//}



//function outcomes() {

//    let suboutcomes = document.getElementById("Outcome").value;
//    let container = document.getElementById("hideValuesOnSelect");
//    let reappointment = document.getElementById("ReAppointmentDiv");
//    if (suboutcomes === "Meeting") {
//        container.style.display = "block";
//        reappointment.style.display = "none";

//        let salutation = document.getElementById("Salutation").value;
//        let customerName = document.getElementById("ContactPersonName").value;
//        var ContactPerson = document.getElementById("ContactPerson").value = salutation + " " + customerName;

//        //var ContactPerson = document.getElementById('ContactPerson').value;
//        var CustomerName = document.getElementById('CustomerName').value;;
//        var CustomerContactNumber = document.getElementById('CustomerContactNumber').value;
//        //var CustomerGSTNumber = document.getElementById('CustomerGSTNumber').value;
//        var CurrentLocation = document.getElementById('CurrLoc').value;


//        var data = {
//            CustomerName: CustomerName,
//            ContactPerson: ContactPerson,
//            CustomerContactNumber: CustomerContactNumber,
//            CurrentLocation: CurrentLocation,
//            // CustomerGSTNumber: CustomerGSTNumber,


//        };
//        $.ajax({
//            type: "POST",
//            url: "/Flow/UpdateNewCustomerMeetingDetails",
//            data: data,
//            success: function (response) {
//                if (response.status) {




//                } else {


//                    alert('Update failed Please refresh and Retry Again: ' + response.message);

//                }
//            },
//            error: function (xhr, status, error) {


//                console.error("Error: " + error);
//                alert("An error occurred while updating the Route. " + xhr.responseText);
//            }
//        });



//    } else if (suboutcomes === "No-Meeting") {

//        reappointment.style.display = "block";
//        container.style.display = "none";
//    }
//}



$(window).on('scroll', function (event) {
    if ($(this).scrollTop() > 600) {
        $('.back-to-top').fadeIn(200)
    } else {
        $('.back-to-top').fadeOut(200)
    }
});

//Animate the scroll to yop
$('.back-to-top').on('click', function (event) {
    event.preventDefault();

    $('html, body').animate({
        scrollTop: 0,
    }, 1500);
});



//Javascript for navigation bar , sidebar start

//var x = window.matchMedia("(max-width: 414px)");

//function SidebarBackgroundopen() {
//    if (x) {
//        const slide = document.querySelector(".slide");
//        slide.style.display = "flex";
//    }
//    else {
//        const sidebar = document.querySelector(".SidebarContainer");
//        sidebar.style.display = "flex";
//    }

//}

//function SidebarBackgroundclose() {
//    if (x) {
//        const slide = document.querySelector(".slide");
//        slide.style.display = "none";
//    }
//    else {
//        const sidebar = document.querySelector(".SidebarContainer");
//        sidebar.style.display = "none";

//    }
//}

//function shownotificationbar() {
//    const notificationbar = document.querySelector(".notificationbar");
//    notificationbar.style.display = "flex";
//}
//function closenotificationbar() {
//    const notificationbar = document.querySelector(".notificationbar");
//    notificationbar.style.display = "none";
//}







// document.addEventListener("DOMContentLoaded", function ()) {

//     shownotificationbar();

// }

//function dropdownOpen(event, Id2) {
//    event.stopPropagation();
//    /*let userPageList = document.getElementById(Id1);*/
//    let insideList = document.getElementById(Id2);




//    if (insideList.style.display === 'none' || insideList.style.display === '') {
//        /* userPageList.style.display = 'block';*/

//        insideList.style.display = 'block';


//    } else {
//        insideList.style.display = 'none';
//    }


//    document.querySelector("body").addEventListener("click", () => {
//        insideList.style.display = 'none';
//    });


//}



//function dropdownOpenDiv(event, Id2) {
//    event.stopPropagation();
//    /*let userPageList = document.getElementById(Id1);*/
//    let insideList = document.getElementById(Id2);




//    if (insideList.style.display === 'none' || insideList.style.display === '') {
//        /* userPageList.style.display = 'block';*/

//        insideList.style.display = 'block';


//    } else {
//        insideList.style.display = 'none';
//    }






//}


function datetime() {
    var abc = document.getElementById("ReAppointmentDate").value;
    console.log(abc);

    dt1 = new Date();
    dt2 = new Date(abc);

    if (dt2 < dt1) {
        alert("Wrong input appointment time less than current time")

    }

    else {
        var x = diff_hours(dt1, dt2);
        var y = diff_minutes(dt1, dt2);
        //console.log(x);
        var z;
        z = x / 24;
        z = Math.abs(Math.round(z));
        x = Math.ceil(x % 24);
        y = Math.ceil(y % x);
        document.getElementById("ReAppointmentDate").innerHTML = `<p>${z} Days ${x} Hour and
	${y} Minutes for next meeting.
	</p>`;
        document.getElementById("ReAppointmentDate").style.color = "#30694F";
    }
}

function diff_hours(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60);
    return Math.abs(Math.round(diff));

}

function diff_minutes(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60);
    return Math.abs(Math.round(diff));

}



function GetDetails() {
    datetime();
    var date = document.getElementById("ReAppointmentDate").value;
    getTodayReappointments(date);
}




function getTodayReappointments(d) {

    var datein = d;
    /*    $.noConflict();*/

    $.ajax({
        type: "GET",
        url: "/Flow/GetTodayAppointments",
        contentType: "application/json",
        data: { Date: datein },
        success: function (receipts) {
            console.log("Success: ");
            if (receipts) {
                let tableBody = document.getElementById("tbody");
                tableBody.innerHTML = "";
                $(receipts).each(function (index, item) {
                    var seq = index + 1;


                    const tr = document.createElement("tr");
                    tr.innerHTML =
                        `<td>${seq}</td>
                              <td>${item.appointmentTime ? (typeof item.appointmentTime === 'string' ? item.appointmentTime : `${item.appointmentTime.hour ?? "00"}:${String(item.appointmentTime.minute ?? "00").padStart(2, "0")}`) : "N/A"}</td>
                              <td>${item.customerName} </td>                                     
                              <td>${item.area}</td>`;

                    tableBody.appendChild(tr);
                });

                document.getElementById("DisplayRoutes").style.display = 'block';
            }
        },
        error: function (xhr, status, error) {
            console.error("Error: " + error);
            console.log("Status: " + status);
            console.log("XHR: ", xhr);
            alert("An error occurred while fetching products. " + xhr.responseText);
        }
    });

}

document.addEventListener("DOMContentLoaded", () => {
    const icon = document.getElementById("downloadIcon");
    const buttons = document.getElementById("downloadButtons");

    if (!icon || !buttons) return; // Exit silently if not present

    // Toggle visibility
    icon.addEventListener("click", (event) => {
        event.stopPropagation(); // prevent closing immediately
        buttons.classList.toggle("show");
    });

    // Hide when clicking outside
    document.addEventListener("click", (event) => {
        if (!icon.contains(event.target) && !buttons.contains(event.target)) {
            buttons.classList.remove("show");
        }
    });
});
// show login timer to user 
function startLoginTimer(checkInTime) {
    const timerContainer = document.getElementById("calendarTimerContainer");
    const timerElement = document.getElementById("workTimer");


    if (timerContainer) {
        timerContainer.style.display = "flex";
    }

    function updateTimer() {
        const now = new Date();
        const checkIn = new Date(checkInTime);
        const diff = now - checkIn;

        const hrs = Math.floor(diff / 3600000);
        const mins = Math.floor((diff % 3600000) / 60000);
        const secs = Math.floor((diff % 60000) / 1000);

        if (timerElement) {
            timerElement.innerText =
                (hrs < 10 ? "0" + hrs : hrs) + ":" +
                (mins < 10 ? "0" + mins : mins) + ":" +
                (secs < 10 ? "0" + secs : secs);
        }
    }

    updateTimer();
    timerInterval = setInterval(updateTimer, 1000);
}




//window.reportFilterCallback = null;

$(document).on('click', '.btn-apply-report-filter', function () {

    const container = $(this)
        .closest('.report-filter-container');

    const startDate =
        container.find('.filter-from-date').val();

    const endDate =
        container.find('.filter-to-date').val();

    $('#StartDate').val(startDate);
    $('#EndDate').val(endDate);

    $('#visitReportForm').submit();
});