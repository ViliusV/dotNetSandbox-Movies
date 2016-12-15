using Google.Apis.Services;
using System.Linq;
using System.Threading.Tasks;
using YouTubeApiService = Google.Apis.YouTube.v3.YouTubeService;

namespace Movies.Services.Services
{
    public class YouTubeService : IVideoProviderService
    {
        public async Task<string> GetTrailerVideoId(string movieTitle)
        {
            if (string.IsNullOrEmpty(movieTitle))
            {
                return null;
            }

            //ToDo: store api key in config
            var service = new YouTubeApiService(new BaseClientService.Initializer() { ApiKey = "AIzaSyBCKvubbI7mGVNNjHV_sPpk_sho-Jsa_JQ" });
            var searchRequest = service.Search.List("snippet");
            searchRequest.Q = $"{movieTitle} trailer";
            searchRequest.MaxResults = 1;

            var searchTask = searchRequest.ExecuteAsync();
            var searchResponse = await searchTask;

            var videoId = searchResponse.Items?.FirstOrDefault()?.Id?.VideoId;

            return videoId;
        }
    }
}
