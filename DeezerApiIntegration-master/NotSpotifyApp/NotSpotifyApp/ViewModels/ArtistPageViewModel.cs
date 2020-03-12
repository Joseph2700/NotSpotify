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
        protected IDeezerApiService _apiService; 
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GetArtistInfoCommand { get; set; }
        public Artist ArtistInfo { get; set; }
        public string Id { get; set; }


        public ArtistPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
           
            GetArtistInfoCommand = new DelegateCommand(async () =>
            {
                await GetArtistData();
            });
        }

        async Task GetArtistData()
        {
           
            if (await CheckInternetConnection())
            {
                    ArtistInfo = await _apiService.GetArtistInfo(Id);
            }
        }
           
    }
}

       

