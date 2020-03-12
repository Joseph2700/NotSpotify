using NotSpotifyApp.Models;
using System.Threading.Tasks;

namespace NotSpotifyApp.Services
{
    public interface IDeezerApiService
    {
        Task<Artist> GetArtistInfo(string Id);
        Task<Genre> GetGenreInfo(string Id);
        Task<Album> GetAlbumInfo(string Id);
    }
}
