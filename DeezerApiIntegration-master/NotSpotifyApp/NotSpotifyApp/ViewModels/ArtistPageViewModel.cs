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
    public class ArtistPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IPageDialogService PageDialogService { get; set; }
        protected IDeezerApiService _apiService; 
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GetArtistInfoCommand { get; set; }
        public Artist ArtistInfo { get; set; }
        public string Id { get; set; }


        public ArtistPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _apiService = apiService;
            GetArtistInfoCommand = new DelegateCommand(async () =>
            {
                await GetArtistData();
            });
        }

        async Task GetArtistData()
        {
           
            if (await CheckInternetConnection())
            {
                try
                {

                    ArtistInfo = await _apiService.GetArtistInfo(Id);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"API EXCEPTION {ex}");
                }
            }
        }

            public async Task<bool> CheckInternetConnection()
            {
                bool IsInternetAvailable = true;
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    IsInternetAvailable = false;
                    await App.Current.MainPage.DisplayAlert($"{AlertTextConstants.TitleText}", $"{AlertTextConstants.MessageText}", $"{AlertTextConstants.OptionButtonText}");
                }
                return IsInternetAvailable;
            }


    }
}

       

