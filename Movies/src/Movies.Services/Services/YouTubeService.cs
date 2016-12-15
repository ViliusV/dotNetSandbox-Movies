using Google.Apis.Services;
using Movies.Data.Repositories;
using System.Linq;
using System.Threading.Tasks;
using YouTubeApiService = Google.Apis.YouTube.v3.YouTubeService;

namespace Movies.Services.Services
{
    public class YouTubeService : IVideoProviderService
    {
        private readonly IMovieService _movieService;

        public YouTubeService(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<string> GetTrailerVideoId(string movieTitle)
        {
            if (string.IsNullOrEmpty(movieTitle))
            {
                return null;
            }

            var movie = _movieService.Get(movieTitle);
            
            if (string.IsNullOrEmpty(movie?.TrailerVideoId))
            {
                var query = $"{movieTitle} trailer";
                var videoId = (await GetVideoFromYoutube(query)).Id.VideoId;

                if (movie != null)
                {
                    movie.TrailerVideoId = videoId;
                    await _movieService.Update(movie);
                }

                return videoId;
            } else
            {
                return movie.TrailerVideoId;
            }
        }

        private async Task<Google.Apis.YouTube.v3.Data.SearchResult> GetVideoFromYoutube(string query)
        {
            //ToDo: store api key in config
            var service = new YouTubeApiService(new BaseClientService.Initializer() { ApiKey = "AIzaSyBCKvubbI7mGVNNjHV_sPpk_sho-Jsa_JQ" });
            var searchRequest = service.Search.List("snippet");
            searchRequest.Q = query;
            searchRequest.MaxResults = 1;

            var searchTask = searchRequest.ExecuteAsync();
            var searchResponse = await searchTask;
            var video = searchResponse.Items?.FirstOrDefault();

            return video;
        }
    }
}
