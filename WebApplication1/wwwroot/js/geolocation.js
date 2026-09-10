// geolocation.js

const GeoService = (function () {

    const options = {
        enableHighAccuracy: true,
        timeout: 10000,
        maximumAge: 0
    };

    const MAX_RETRIES = 3;
    const ACCEPTABLE_ACCURACY = 800; 


    function delay(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    function getCurrentPosition() {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(resolve, reject, options);
        });
    }

    async function getLocation() {

        if (!navigator.geolocation) {
            throw new Error("Geolocation not supported");
        }

        let lastAccuracy = null;

        for (let attempt = 1; attempt <= MAX_RETRIES; attempt++) {

            const pos = await getCurrentPosition();
            const crd = pos.coords;

            lastAccuracy = crd.accuracy;

            if (crd.accuracy <= ACCEPTABLE_ACCURACY) {

                return {
                    latitude: crd.latitude,
                    longitude: crd.longitude,
                    accuracy: crd.accuracy,
                    timestamp: new Date().toISOString()
                };
            }

            // Wait before retrying (give GPS time to refine)
            await delay(1500);
        }

        throw new Error(
            `Unable to get accurate location (Last accuracy: ${Math.round(lastAccuracy)}m). Please move to open area.`
        );
    }

    return {
        getLocation
    };

    return {
        getLocation
    };

})();
