if (typeof jQuery === 'undefined') {
    console.warn('ReportDataFilter: jQuery is not loaded; skipping initialization.');
} else {
    (function ($) {

        $(document).on('click', '.report-filter-toggle', function (e) {

            e.preventDefault();
            e.stopPropagation();

            $(this)
                .siblings('.date-filter-panel')
                .stop(true, true)
                .slideToggle(250);

        });

        $(document).on('click', '.date-filter-panel', function (e) {
            e.stopPropagation();
        });

        $(document).on('click', function () {
            $('.date-filter-panel').slideUp(250);
        });

    })(jQuery);
}

