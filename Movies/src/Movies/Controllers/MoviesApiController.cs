using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    public class MoviesApiController : Controller
    {
        private readonly IVideoProviderService _videoProviderService;

        public MoviesApiController(IVideoProviderService videoProviderService)
        {
            _videoProviderService = videoProviderService;
        }

        [HttpGet]
        [Route(nameof(Test))]
        public IActionResult Test()
        {
            return Ok(nameof(MoviesApiController));
        }

        [HttpGet()]
        [Route(nameof(GetTrailerVideoId))]
        public IActionResult GetTrailerVideoId([FromQuery]string title)
        {
            var videoId = _videoProviderService.GetTrailerVideoId(title);

            return Ok(videoId);
        }
    }
}
