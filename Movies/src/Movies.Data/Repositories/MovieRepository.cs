using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesContext _context;

        public MovieRepository(MoviesContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }
    }
}
