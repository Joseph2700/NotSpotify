using NotSpotifyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.Services
{
    public interface IApiManager
    {
        Task<ObservableCollection<Album>> AddFavoriteAlbumAsync(string Id);
        Task<ObservableCollection<Album>> ShowAlbumDataAsync();

        Task<ObservableCollection<Track>> AddFavoriteTrackAsync(string Id);
        Task<ObservableCollection<Track>> ShowTrackDataAsync();

    }
}
