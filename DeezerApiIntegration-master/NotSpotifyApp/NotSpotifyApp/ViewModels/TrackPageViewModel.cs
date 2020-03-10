using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotSpotifyApp.ViewModels
{
    public class TrackPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService PageDialogService { get; set; }
        protected IDeezerApiService _apiService;
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GetTrackInfoCommand { get; set; }
        public Track TrackInfo { get; set; }
        public string Id { get; set; }

        public TrackPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _apiService = apiService;
            GetTrackInfoCommand = new DelegateCommand(async () =>
            {
                await GetTrackData();
            });
        }

        async Task GetTrackData()
        {
            if(await CheckInternetConnection())
            {
                try
                {
                    TrackInfo = await _apiService.GetTrackInfo(Id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"API EX {ex}");    
                }
            }
        }

        public async Task<bool> CheckInternetConnection()
        {
            bool IsInternetAvaible = true;
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsInternetAvaible = false;
                await App.Current.MainPage.DisplayAlert($"{AlertTextConstants.TitleText}", $"{AlertTextConstants.MessageText}", $"{AlertTextConstants.OptionButtonText}");
            }
            return IsInternetAvaible;
        }
    }
}
