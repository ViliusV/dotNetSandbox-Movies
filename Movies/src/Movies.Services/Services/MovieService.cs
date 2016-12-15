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
                new Movie {Title = "Lord of the Rings" },
                new Movie {Title = "A Life of Brian" }
            };

            foreach (var movie in movies)
            {
                movie.TrailerVideoUrl = _videoProviderService?.GetTrailerVideoUrl(movie.Title);
            }

            return movies;
        }

        public string GetBestMovieFromGenre(string genre)
        {
            var genres = new Dictionary<string, string>()
            {
                ["crime"] = "Godfather",
                ["fantasy"] = "Lord of the Rings",
                ["comedy"] = "A Life of Brian"
            };

            if (string.IsNullOrEmpty(genre))
            {
                return null;
            }

            var genreKey = genre.ToLowerInvariant();
            if (genres.ContainsKey(genreKey))
            {
                return genres[genreKey];
            }

            return null;
        }
    }

}