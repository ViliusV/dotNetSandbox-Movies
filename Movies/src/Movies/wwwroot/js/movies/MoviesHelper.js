
let MOVIES = function () {
	var collection;

	appendMovies = function () {
		let moviesContainer = $('.movies-container');
		let moviesFragment = $(document.createDocumentFragment());
		moviesContainer.empty();
		let templateSource = $("#movie-template").html();
		let template = Handlebars.compile(templateSource);

		//collection.movies all has the movies, because it contains a reference to movies variable, check if it's not emptied after exiting ajax call
		for (let id = 0, moviesCollectionLength = collection.movies.length; id < moviesCollectionLength; id++) {
			let movieHtml = $(template(collection.movies[id]));

			//This allows to attache event listener, before adding element to DOM
			movieHtml.on('click', '.trailer-load-button', function () {
				loadButtonClick(this);
			});

			moviesFragment.append(movieHtml);
		}

		moviesContainer.append(moviesFragment);
	};


	loadButtonClick = function (button) {
		let movie = $(button).closest('.movie');
		let title = movie.data('title');

		//ToDo: refactor to use assignTrailerVideoId

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
	};


	appendVideo = function (movieElement, id) {
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

	return {
		showAllMovies: function () {
			$.ajax({
				url: 'api/MoviesApi',
				success: function (data) {
					if (data !== undefined && data !== null && data.length > 0) {
						let movies = [];
						collection = new MoviesCollection(movies);
						for (let id = 0, dataLength = data.length; id < dataLength; id++) {
							let movieEntity = data[id];
							let movie = new Movie(movieEntity.id, movieEntity.title, movieEntity.trailerVideoId);
							movies.push(movie);
							//Handlebars could be called directly here with each data[id].
							//Creating a collection object is just for educational reasons to better understand how prototyping works
						}

						appendMovies();
					}
				}
			});
		},
	};
}();