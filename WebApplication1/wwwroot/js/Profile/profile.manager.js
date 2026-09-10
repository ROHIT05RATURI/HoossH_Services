(function () {

    const KEY = "AppUserProfile_v1";

    // ------------------------
    // GLOBAL STATE
    // ------------------------
    window.AppUser = {};

    // ------------------------
    // STORAGE
    // ------------------------
    function save() {
        localStorage.setItem(KEY, JSON.stringify(window.AppUser));
    }

    function load() {
        const data = localStorage.getItem(KEY);
        return data ? JSON.parse(data) : null;
    }

    // ------------------------
    // RENDER UI
    // ------------------------
    function render() {

        const p = window.AppUser;

        // HEADER
        setId("profile-name", p.fullName);
        setClass("profile-email", p.email);
        setClass("profile-phone", p.phone);
        setClass("profile-location", `${p.city || ''}, ${p.country || ''}`);

        // Update Images (Dono Main aur Modal wali)
        if (p.profileImage) {
            const mainImg = document.getElementById("mainProfileImg");
            const editImg = document.getElementById("editProfileImg");
            const imgSrc = `data:image/jpeg;base64,${p.profileImage}`;

            if (mainImg) mainImg.src = imgSrc;
            if (editImg) editImg.src = imgSrc;
        }

        // IDENTITY (HTML labels ke exact naam match kiye gaye hain)
        setInfo("PAN Number", p.pan);
        setInfo("Aadhaar Number", p.aadhar);

        // BANK
        setInfo("Account No", p.accountNo);
        setInfo("IFSC Code", p.ifsc);
        setInfo("Bank Name", p.bankName);
        setInfo("Branch", p.branch);
        setInfo("Account Holder", p.accountHolder);

        // ADDRESS
        setInfo("Full Address", p.address);
        setInfo("City", p.city);
        setInfo("State", p.state);
        setInfo("Pincode", p.pinCode);
        setInfo("Country", p.country);

        // PROGRESS
        updateProgress();
    }

    // ------------------------
    // PROGRESS
    // ------------------------
    function updateProgress() {

        const p = window.AppUser;

        const fields = [
            p.fullName, p.email, p.phone,
            p.pan, p.aadhar,
            p.accountNo, p.ifsc, p.bankName,
            p.address, p.city, p.state, p.pinCode, p.country
        ];

        const filled = fields.filter(f => f && f !== "-").length;
        const percent = Math.round((filled / fields.length) * 100);

        const bar = document.getElementById("profileProgress");
        const txt = document.getElementById("profilePercent");

        if (bar) bar.style.width = percent + "%";
        if (txt) txt.innerText = percent + "% completed";
    }

    // ------------------------
    // HELPERS
    // ------------------------
    function setId(id, val) {
        const el = document.getElementById(id);
        if (el) el.innerText = val || "-";
    }

    function setClass(cls, val) {
        document.querySelectorAll("." + cls).forEach(e => {
            // Icon preserve karne ka premium logic
            const icon = e.querySelector('i');
            if (icon) {
                e.innerHTML = '';
                e.appendChild(icon);
                e.append(' ' + (val || "-"));
            } else {
                e.innerText = val || "-";
            }
        });
    }

    function setInfo(label, val) {
        // Yahan par humne nayi 'prf-data-lbl' class update kar di hai!
        const el = [...document.querySelectorAll(".prf-data-lbl")]
            .find(e => e.innerText.trim() === label);

        if (el && el.nextElementSibling) {
            el.nextElementSibling.innerText = val || "-";
        }
    }

    // ------------------------
    // UPDATE (FULL)
    // ------------------------
    function update(data) {
        window.AppUser = { ...window.AppUser, ...data };
        save();
        render();
    }

    // ------------------------
    // INIT
    // ------------------------
    function init() {
        const stored = load();

        if (stored) {
            window.AppUser = stored;
            render();
        } else {
            window.AppUser = {};
        }
    }

    // ------------------------
    // PUBLIC API
    // ------------------------
    window.ProfileManager = {
        init,
        update
    };

})();