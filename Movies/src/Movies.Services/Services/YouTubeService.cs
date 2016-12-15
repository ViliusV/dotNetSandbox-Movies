using Google.Apis.Services;
using System.Linq;
using YouTubeApiService = Google.Apis.YouTube.v3.YouTubeService;

namespace Movies.Services.Services
{
    public class YouTubeService : IVideoProviderService
    {


        public string GetTrailerVideoUrl(string movieTitle)
        {
            //ToDo: store api key in config
            var service = new YouTubeApiService(new BaseClientService.Initializer() { ApiKey = "AIzaSyBCKvubbI7mGVNNjHV_sPpk_sho-Jsa_JQ" });
            var searchRequest = service.Search.List("snippet");
            searchRequest.Q = $"{movieTitle} trailer";
            searchRequest.MaxResults = 1;

            var searchResponse = searchRequest.Execute(); //ToDo: use await

            var videoUrl = searchResponse.Items?.FirstOrDefault()?.Id?.VideoId;

            return videoUrl;
        }
    }
}
