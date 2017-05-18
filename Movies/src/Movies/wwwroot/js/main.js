//ToDo: Bundle files
//ToDo: Switch to Webpack from Bower to use EcmaScript2015?

collection = undefined;

let MoviesCollection = function (movies) {
	this.movies = movies;
}

//Adding function to prototype, so it would be stored in one place instead of storing it in each MoviesCollection object
MoviesCollection.prototype.get = function (id) {
	for (let i = 0; i < this.Movies.length; i++) {
		if (this.Movies[i].id === id) {
			return this.Movies[id];
		}
	}
	return null;
}



let Movie = function (id, title, trailerVideoId) {
	this.id = id;
	this.title = title;
	this.trailerVideoId = trailerVideoId;
};

Movie.prototype.assignTrailerVideoId = function () {
	if (this.trailerVideoId !== undefined && this.trailerVideoId !== null && this.trailerVideoId !== '') {
		return;
	}

	$.ajax({
		url: 'api/MoviesApi/GetTrailerVideoId',
		data: {
			title: this.title
		},
		success: function (data) {
			if (typeof data !== 'undefined' && data !== null && data !== '') {
				this.trailerVideoId = data;
			}
		}

	});
};




$(function () {
	let showAllMovies = function () {
		$.ajax({
			url: 'api/MoviesApi',
			success: function (data) {
				if (data !== undefined && data !== null && data.length > 0) {
					let movies = [];
					collection = new MoviesCollection(movies);
					for (let id = 0; id < data.length; id++) {
						let movie = new Movie(data[id].id, data[id].title, data[id].trailerVideoId);
						movies.push(movie); 
						//Handlebars could be called directly here with each data[id].
						//Creating a collection object is just for educational reasons to better understand how prototyping works
					}

					appendMovies();
				}
			}
		});

	}

	showAllMovies();
});


let appendMovies = function () {
	let moviesContainer = $('.movies-container');
	moviesContainer.empty();
	let templateSource = $("#movie-template").html();
	let template = Handlebars.compile(templateSource);

	//collection.movies all has the movies, because it contains a reference to movies variable, check if it's not emptied after exiting ajax call
	for (let id = 0; id < collection.movies.length; id++) {
		let movieHtml = $(template(collection.movies[id]));

		//This allows to attache event listener, before adding element to DOM
		movieHtml.on('click', '.trailer-load-button', function () {
			loadButtonClick(this);
		});

		moviesContainer.append(movieHtml);
	}
}

let loadButtonClick = function (button) {
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
}


	let  appendVideo = function (movieElement, id) {
		let movieElementExists = typeof movieElement !== "undefined" && movieElement !== null;
		let idExists = typeof id !== "undefined" && id !== null;

		if (movieElementExists && idExists) {
			let trailerVideo = movieElement.find('.trailer-video');
			let trailerVideoIframe = movieElement.find('.trailer-video iframe');
			let source = $(trailerVideoIframe).prop('src') + id;

			$(trailerVideoIframe).prop('src', source);
			$(trailerVideo).show();
		}
	};