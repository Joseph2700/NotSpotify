using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
	public class SongPlayerPageViewModel : BaseViewModel, IInitialize
	{
		public Track TrackInfo { get; set; }
		public DelegateCommand GetTrackInfoCommand { get; set; }
		public DelegateCommand PreviousPageCommand { get; set; }
		public DelegateCommand ShareTrackCommand { get; set; }
		public string Id { get; set; }

		public SongPlayerPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
		{
			GetTrackInfoCommand = new DelegateCommand(async () =>
			{
				await GetTrackData();
			});

			PreviousPageCommand = new DelegateCommand(async () =>
			{
				await navigationService.GoBackAsync();
			});

			ShareTrackCommand = new DelegateCommand(async () =>
			{
				await CrossShare.Current.Share(new ShareMessage
				{
					Title = $"Hey check this song out! - {TrackInfo.Title}",
					Url = $"{TrackInfo.Share}"
				});
			});
		}

		public void Initialize(INavigationParameters parameters)
		{
			if (parameters.ContainsKey("Track id"))
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
