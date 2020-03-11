﻿using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotSpotifyApp.ViewModels
{
    public class BaseViewModel
    {
        protected INavigationService NavigationService { get; set; }
        protected IDeezerApiService ApiService { get; set; }

        public BaseViewModel(INavigationService navigationService, IDeezerApiService apiService)
        {
            NavigationService = navigationService;
            ApiService = apiService;
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


