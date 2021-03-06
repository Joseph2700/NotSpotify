﻿using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class TrackInfoPageViewModel: BaseViewModel, IInitialize
    {
        public Track TrackInfo { get; set; }
        protected IApiManager ApiManager = new ApiManager();
        private readonly INavigationService _navigationService;
        public DelegateCommand GetTrackInfoCommand { get; set; }
        public DelegateCommand AddFavoriteTrackCommand { get; set; } 
        public DelegateCommand ReturnToTrackPageCommand { get; set; }
        public DelegateCommand GoToSongPlayerPageCommand { get; set; }
        public DelegateCommand ShareTrackCommand { get; set; }
        public string SelectedTrackID { get; set; }
        public string Id { get; set; }

        public TrackInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _navigationService = navigationService; 

            GetTrackInfoCommand = new DelegateCommand(async () =>
            {
                await GetTrackData();
            });

            ReturnToTrackPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });

            ShareTrackCommand = new DelegateCommand(async () =>
            {
                await CrossShare.Current.Share(new ShareMessage
                {
                    Title = $"Hey check this artist out! - {TrackInfo.Title}",
                    Url = $"{TrackInfo.Share}"
                });
            });

            GoToSongPlayerPageCommand = new DelegateCommand(async () =>
            {
                await GoToSongPlayer();
            });

            AddFavoriteTrackCommand = new DelegateCommand(async () =>
            {
                await AddTrackToFavorites();
                await pageDialogueService.DisplayAlertAsync($"{AlertTextConstants.AddedFavoriteTitle}", $"{AlertTextConstants.AddedFavoriteMessage}", $"{AlertTextConstants.OptionButtonText}");
            });

        }

        public void Initialize(INavigationParameters parameters)
        {
            if(parameters.ContainsKey("Track id"))
            {
                Id = parameters["Track id"].ToString();
                GetTrackInfoCommand.Execute();
            }
            SelectedTrackID = Id;
        }

        async Task GoToSongPlayer()
        {
            var TrackID = new NavigationParameters();
            TrackID.Add("Track id", Id);

            if (await CheckInternetConnection())
            {
                var navigation = _navigationService.NavigateAsync(NavigationConstants.SongPlayerPage, TrackID);
            }
        }

        public async Task AddTrackToFavorites()
        {
            await ApiManager.AddFavoriteTrackAsync(SelectedTrackID);
        }

        async Task GetTrackData()
        {
            TrackInfo = await ApiService.GetTrackInfo(Id);
        }
    }
}
