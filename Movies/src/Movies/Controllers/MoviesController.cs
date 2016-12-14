using Microsoft.AspNetCore.Mvc;
using Movies.Services.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var movies = _movieService?.GetAll();

            return View(movies);
        }
    }
}
