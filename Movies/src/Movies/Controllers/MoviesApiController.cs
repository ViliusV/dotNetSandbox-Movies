using Microsoft.AspNetCore.Mvc;
using Movies.Services.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
	[Route("api/[controller]")]
	public class MoviesApiController : Controller
	{
		private readonly IVideoProviderService _videoProviderService;
		private readonly IMovieService _movieService;

		public MoviesApiController(IVideoProviderService videoProviderService, IMovieService movieService)
		{
			_videoProviderService = videoProviderService;
			_movieService = movieService;
		}

		[HttpGet]
		[Route(nameof(Test))]
		public IActionResult Test()
		{
			return Ok(nameof(MoviesApiController));
		}

		[HttpGet]
		public IActionResult Get()
		{
			var movies = _movieService.GetAll();
			return Ok(movies);
		}

		[HttpGet()]
		[Route(nameof(GetTrailerVideoId))]
		public IActionResult GetTrailerVideoId([FromQuery]string title)
		{
			var task = _videoProviderService.GetTrailerVideoId(title);
			var videoId = task.Result;

			return Ok(videoId);
		}
	}
}
