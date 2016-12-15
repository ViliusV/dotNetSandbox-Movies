using System.Collections.Generic;
using Movies.Domain;
using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie Get(string title);
        Task Update(Movie movie);
    }
}
