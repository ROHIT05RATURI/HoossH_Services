
const calendarDates = document.getElementById('calendarDates');
const monthYear = document.getElementById('monthYear');
const modal = document.getElementById('modal');
const closeModalButton = document.querySelector('.close-button');
const saveAppointmentButton = document.getElementById('saveAppointment');
const appointmentTitleInput = document.getElementById('appointmentTitle');

let currentDate = new Date();
let currentMonth = currentDate.getMonth();
let currentYear = currentDate.getFullYear();
let selectedDate = null;

function renderCalendar(month, year) {
    calendarDates.innerHTML = '';
    const firstDay = new Date(year, month).getDay();
    const daysInMonth = new Date(year, month + 1, 0).getDate();

    const monthName = new Date(year, month).toLocaleString('default', { month: 'long' });
    monthYear.textContent = `${monthName} ${year}`;

    for (let i = 0; i < firstDay; i++) {
        const emptyCell = document.createElement('div');
        emptyCell.classList.add('calendar-date');
        calendarDates.appendChild(emptyCell);
    }

    for (let day = 1; day <= daysInMonth; day++) {
        const dateCell = document.createElement('div');
        dateCell.classList.add('calendar-date');
        dateCell.textContent = day;

        // Check if there are saved appointments
        const savedAppointments = getAppointmentsForDate(day, month, year);
        if (savedAppointments) {
            savedAppointments.forEach(appointment => {
                const appointmentDiv = document.createElement('div');
                appointmentDiv.classList.add('appointment');
                appointmentDiv.textContent = appointment;
                appointmentDiv.addEventListener('click', (e) => {
                    e.stopPropagation();
                    appointmentTitleInput.value = appointment;
                    selectedDate = { day, month, year };
                    openModal();
                });
                dateCell.appendChild(appointmentDiv);
            });
        }

        dateCell.addEventListener('click', () => {
            selectedDate = { day, month, year };
            appointmentTitleInput.value = '';
            openModal();
        });

        calendarDates.appendChild(dateCell);
    }
}

function openModal() {
    modal.style.display = 'block';
}

function closeModal() {
    modal.style.display = 'none';
}

function saveAppointment() {
    const title = appointmentTitleInput.value;
    if (title && selectedDate) {
        saveAppointmentForDate(selectedDate.day, selectedDate.month, selectedDate.year, title);
        renderCalendar(currentMonth, currentYear);
        closeModal();
    }
}

function getAppointmentsForDate(day, month, year) {
    const key = `${year}-${month}-${day}`;
    return JSON.parse(localStorage.getItem(key)) || [];
}

function saveAppointmentForDate(day, month, year, title) {
    const key = `${year}-${month}-${day}`;
    let appointments = JSON.parse(localStorage.getItem(key)) || [];
    appointments.push(title);
    localStorage.setItem(key, JSON.stringify(appointments));
}

document.getElementById('prevMonth').addEventListener('click', () => {
    currentMonth--;
    if (currentMonth < 0) {
        currentMonth = 11;
        currentYear--;
    }
    renderCalendar(currentMonth, currentYear);
});

document.getElementById('nextMonth').addEventListener('click', () => {
    currentMonth++;
    if (currentMonth > 11) {
        currentMonth = 0;
        currentYear++;
    }
    renderCalendar(currentMonth, currentYear);
});

closeModalButton.addEventListener('click', closeModal);
saveAppointmentButton.addEventListener('click', saveAppointment);

window.addEventListener('click', (e) => {
    if (e.target === modal) {
        closeModal();
    }
});

renderCalendar(currentMonth, currentYear);



