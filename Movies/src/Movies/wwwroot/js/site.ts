//ToDo: Bundle files
$(function () {
	$('.trailer-load-button').click(function () {
		loadButtonClick(this);
	});
});



let loadButtonClick = function (button: JQuery) {
	let movie = $(button).closest('.movie');
	let title = movie.data('title');

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

		//ToDo: on error show error message, don't allow to click button once more
	});
}


let appendVideo = function (movieElement: JQuery, id: number) {
	let movieElementExists = typeof movieElement !== "undefined" && movieElement !== null;
	let idExists = typeof id !== "undefined" && id !== null;

	if (movieElementExists && idExists) {
		let trailerVideo = movieElement.find('.trailer-video');
		let trailerVideoIframe = movieElement.find('.trailer-video iframe');
		let source = $(trailerVideoIframe).prop('src') + id;

		$(trailerVideoIframe).prop('src', source);
		$(trailerVideo).show();
	}
}