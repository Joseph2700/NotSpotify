using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class FavoriteAlbumsPageViewModel : BaseViewModel
    {
        protected IApiManager ApiManager = new ApiManager();
        public ObservableCollection<Album> FavoriteAlbumsList { get; set; }
        public DelegateCommand ReturnToAlbumPageCommand { get; set; }
        public DelegateCommand GetFavoriteAlbums { get; set; }

        public FavoriteAlbumsPageViewModel(INavigationService navigationService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            ReturnToAlbumPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });

            GetFavoriteAlbums = new DelegateCommand(async () =>
            {
                await GetFavoriteAlbumsAsync();
            });
            GetFavoriteAlbums.Execute();
        }

        public async Task GetFavoriteAlbumsAsync()
        {
            try
            {
                var Albums = await ApiManager.ShowAlbumDataAsync();
                if (Albums != null)
                {
                    if (FavoriteAlbumsList == null)
                    {
                        FavoriteAlbumsList = new ObservableCollection<Album>();
                        FavoriteAlbumsList = Albums;
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
