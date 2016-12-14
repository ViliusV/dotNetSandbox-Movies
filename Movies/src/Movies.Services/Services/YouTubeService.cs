
namespace Movies.Services.Services
{
    public class YouTubeService : IVideoProviderService
    {
        public string GetTrailerVideoUrl(string movieTitle)
        {
            return "https://www.youtube.com/embed/3ycmmJ6rxA8"; //ToDo: Get from Api
        }
    }
}
