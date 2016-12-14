
namespace Movies.Services.Services
{
    public class YouTubeService : IVideoProviderService
    {
        public string GetTrailerVideoUrl(string movieTitle)
        {
            return "https://www.youtube.com/watch?v=7RYpJAUMo2M"; //Rocky
        }
    }
}
