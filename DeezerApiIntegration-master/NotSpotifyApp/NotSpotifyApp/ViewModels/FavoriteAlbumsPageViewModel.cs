using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSpotifyApp.ViewModels
{
    public class FavoriteAlbumsPageViewModel : BaseViewModel
    {
        public DelegateCommand ReturnToAlbumPageCommand { get; set; }

        public FavoriteAlbumsPageViewModel(INavigationService navigationService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            ReturnToAlbumPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }
    }
}
