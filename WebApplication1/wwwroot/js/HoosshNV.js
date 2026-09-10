

// Navigation Tab  active

document.querySelectorAll('.suspect-tab').forEach(tab => {

    if (window.location.pathname.toLowerCase() === tab.getAttribute('href').toLowerCase()) {

        document.querySelectorAll('.suspect-tab')
            .forEach(t => t.classList.remove('active'));

    tab.classList.add('active');
    }
});

// window object par attach karne se ye globally accessible ho jata hai
window.openFilterSheet = function () {
    const modalElement = document.getElementById('sortModal');
    if (modalElement) {
        // Ensure karein ki bootstrap library load ho chuki hai
        const filterModal = new bootstrap.Modal(modalElement);
        filterModal.show();
    } else {
        console.error("Modal element 'sortModal' not found in DOM");
    }
};

// Filter Form Submit Logic
document.addEventListener("submit", function (e) {
    if (e.target && e.target.id === "filterForm") {
        e.preventDefault();

        const selectedRadio = document.querySelector('input[name="sortBy"]:checked');
        if (!selectedRadio) return;

        const filterValue = selectedRadio.value.toLowerCase();
        const cards = document.querySelectorAll(".compact-card");
        const dot = document.getElementById("filterActiveDot");

        cards.forEach(card => {
            const content = card.getAttribute("data-search").toLowerCase();
            if (filterValue === "all" || content.includes(filterValue)) {
                card.style.display = "block";
                card.style.animation = "fadeIn 0.4s ease";
            } else {
                card.style.display = "none";
            }
        });

        if (dot) dot.style.display = (filterValue !== "all") ? "block" : "none";

        const modalInstance = bootstrap.Modal.getInstance(document.getElementById('sortModal'));
        if (modalInstance) modalInstance.hide();
    }
});


//function openFilterSheet() {
//    const modalElement = document.getElementById('sortModal');
//    if (modalElement) {
//        const filterModal = new bootstrap.Modal(modalElement);
//        filterModal.show();
//    }
//}

//document.addEventListener("submit", function (e) {
//    if (e.target && e.target.id === "filterForm") {
//        e.preventDefault();

//        const selectedRadio = document.querySelector('input[name="sortBy"]:checked');
//        if (!selectedRadio) return;


//        const filterValue = selectedRadio.value.toLowerCase();
//        const cards = document.querySelectorAll(".compact-card");

//        cards.forEach(card => {
//            const content = card.getAttribute("data-search").toLowerCase();

//            if (filterValue === "all" || content.includes(filterValue)) {
//                card.style.display = "block";
//                card.style.animation = "fadeIn 0.4s ease";
//            } else {
//                card.style.display = "none";
//            }
//        });


//        const modalInstance = bootstrap.Modal.getInstance(document.getElementById('sortModal'));
//        if (modalInstance) modalInstance.hide();
//    }
//});


function resetFilter() {
    const defaultRadio = document.querySelector('input[data-default="true"]') ||
        document.querySelector('input[name="sortBy"]');
    if (defaultRadio) {
        defaultRadio.checked = true;
    }

    document.querySelectorAll(".compact-card").forEach(card => {
        card.style.display = "block";
    });
}


