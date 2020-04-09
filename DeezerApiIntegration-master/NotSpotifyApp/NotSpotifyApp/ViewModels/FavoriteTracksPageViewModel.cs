using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class FavoriteTracksPageViewModel : BaseViewModel
    {
        protected IApiManager ApiManager = new ApiManager();
        public ObservableCollection<Track> FavoriteTracksList { get; set; } 
        public DelegateCommand ReturnToTrackPageCommand { get; set; }
        public DelegateCommand GetFavoriteTracks { get; set; }

        public FavoriteTracksPageViewModel(INavigationService navigationService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            ReturnToTrackPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });

            GetFavoriteTracks = new DelegateCommand(async () =>
            {
                await GetFavoriteTracksAsync();
            });
            GetFavoriteTracks.Execute();
        }

        public async Task GetFavoriteTracksAsync()
        {
            try
            {
                var Tracks = await ApiManager.ShowTrackDataAsync();
                if (Tracks != null)
                {
                    if (FavoriteTracksList == null)
                    {
                        FavoriteTracksList = new ObservableCollection<Track>();
                        FavoriteTracksList = Tracks;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API EXCEPTION {ex}");
            }
        }
    }
}
