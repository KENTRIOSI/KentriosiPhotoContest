var page = 1;
var _inCallback = false;

function loadContests() {
    if (page > 0 && !_inCallback) {
        _inCallback = true;
        page++;

        $('#contests-loading').html('<img src="/Content/Images/ajax-loader.gif" alt="loading..." />');

        $.get("/Home/Index/" + page, function (successData) {
            if (successData != '') {
                $('.contests-container').append(successData);
            }
            else {
                page = 0;
            }

            _inCallback = false;
            $('#contests-loading').empty();
        })
            .done(
            function success() { }
        )
        .fail(function (errorData) { console.log(errorData); });
    }
}

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        loadContests();
    }
});