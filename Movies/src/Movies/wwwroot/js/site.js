//ToDo: Bundle files
$(function () {
    $('.trailer-load-button').click(function () {
        loadButtonClick(this);
    });
});
var loadButtonClick = function (button) {
    var movie = $(button).closest('.movie');
    var title = movie.data('title');
    $.ajax({
        url: 'api/MoviesApi/GetTrailerVideoId',
        data: {
            title: title
        },
        success: function (data) {
            if (typeof data !== 'undefined' && data !== null && data !== '') {
                appendVideo(movie, data);
                $(button).hide();
            }
        }
    });
};
var appendVideo = function (movieElement, id) {
    var movieElementExists = typeof movieElement !== "undefined" && movieElement !== null;
    var idExists = typeof id !== "undefined" && id !== null;
    if (movieElementExists && idExists) {
        var trailerVideo = movieElement.find('.trailer-video');
        var trailerVideoIframe = movieElement.find('.trailer-video iframe');
        var source = $(trailerVideoIframe).prop('src') + id;
        $(trailerVideoIframe).prop('src', source);
        $(trailerVideo).show();
    }
};
//# sourceMappingURL=site.js.map