using NotSpotifyApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}


