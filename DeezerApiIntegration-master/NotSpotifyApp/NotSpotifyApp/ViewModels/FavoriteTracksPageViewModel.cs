using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSpotifyApp.ViewModels
{
    public class FavoriteTracksPageViewModel : BaseViewModel
    {
        public DelegateCommand ReturnToTrackPageCommand { get; set; }

        public FavoriteTracksPageViewModel(INavigationService navigationService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            ReturnToTrackPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }
    }
}
