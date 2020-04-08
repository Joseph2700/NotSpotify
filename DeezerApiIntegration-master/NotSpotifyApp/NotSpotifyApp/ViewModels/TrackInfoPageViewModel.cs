using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class TrackInfoPageViewModel: BaseViewModel, IInitialize
    {
        public Track TrackInfo { get; set; }
        public DelegateCommand GetTrackInfoCommand { get; set; }
        public DelegateCommand ReturnToTrackPageCommand { get; set; }
        public DelegateCommand ShareTrackCommand { get; set; }
        public string Id { get; set; }

        public TrackInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
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
        }

        public void Initialize(INavigationParameters parameters)
        {
            if(parameters.ContainsKey("Track id"))
            {
                Id = parameters["Track id"].ToString();
                GetTrackInfoCommand.Execute();
            }
        }

        async Task GetTrackData()
        {
            TrackInfo = await ApiService.GetTrackInfo(Id);
        }
    }
}
