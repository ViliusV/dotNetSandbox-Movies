//ToDo: Bundle files
//ToDo: Switch to Webpack from Bower to use EcmaScript2015?

let MoviesCollection = function (movies) {
	this.movies = movies;
}

//Adding function to prototype, so it would be stored in one place instead of storing it in each MoviesCollection object
MoviesCollection.prototype.get = function (id) {
	for (let i = 0, moviesLength = this.Movies.length; i < moviesLength; i++) {
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