// Write your Javascript code.

//ToDo: Bundle files
$(function () {
    $('.trailer-load-button').click(function () {
        var button = $(this);
        var movie = $(button).closest('.movie');
        var title = movie.data('title');
        
        $.ajax({
            url: 'api/MoviesApi/GetTrailerVideoId',
            data: {
                title: title
            },
            success: function(data){
                if (typeof data !== 'undefined' && data !== null && data !== '') {
                    var trailerVideo = movie.find('.trailer-video');
                    var trailerVideoIframe = movie.find('.trailer-video iframe');
                    var source = $(trailerVideoIframe).prop('src') + data;

                    $(trailerVideoIframe).prop('src', source);
                    $(trailerVideo).show();
                    $(button).hide();
                }
            }

            //ToDo: on error show error message, don't allow to click button once more
        });
    });
});