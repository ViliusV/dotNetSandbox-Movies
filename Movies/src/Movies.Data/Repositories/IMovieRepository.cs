using Movies.Domain;
using System.Collections.Generic;

namespace Movies.Data.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
