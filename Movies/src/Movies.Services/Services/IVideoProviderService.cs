using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public interface IVideoProviderService
    {
        Task<string> GetTrailerVideoId(string movieTitle);
    }
}
