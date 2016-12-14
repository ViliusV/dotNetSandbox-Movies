using System.Collections.Generic;
using Movies.Domain;

namespace Movies.Services.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
    }
}
