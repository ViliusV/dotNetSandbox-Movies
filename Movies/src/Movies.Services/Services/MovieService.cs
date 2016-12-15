using System.Collections.Generic;
using Movies.Domain;
using Movies.Data.Repositories;

namespace Movies.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IVideoProviderService _videoProviderService;
        private readonly IMovieRepository _movieRepository;

        public MovieService(IVideoProviderService videoProviderService, IMovieRepository movieRepository)
        {
            _videoProviderService = videoProviderService;
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = _movieRepository.GetAll();

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
                ["comedy"] = "Monty Python's Life of Brian"
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