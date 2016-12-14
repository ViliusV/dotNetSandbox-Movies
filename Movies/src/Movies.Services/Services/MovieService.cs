using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IVideoProviderService _videoProviderService;

        public MovieService(IVideoProviderService videoProviderService)
        {
            _videoProviderService = videoProviderService;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = new List<Movie>
            {
                new Movie {Title = "Godfather" },
                new Movie {Title = "Lord of the Rings" }
            };

            foreach (var movie in movies)
            {
                movie.TrailerVideoUrl = _videoProviderService?.GetTrailerVideoUrl(movie.Title);
            }

            return movies;
        }
    }

}