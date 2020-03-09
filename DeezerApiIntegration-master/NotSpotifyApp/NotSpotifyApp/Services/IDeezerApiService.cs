using NotSpotifyApp.Models;
using System.Threading.Tasks;

namespace NotSpotifyApp.Services
{
    public interface IDeezerApiService
    {
        Task<Artist> GetArtistInfo(string Id);
    }
}
