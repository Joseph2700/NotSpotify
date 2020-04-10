using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Plugin.SimpleAudioPlayer;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
	public class SongPlayerPageViewModel : BaseViewModel, IInitialize
	{
		public Track TrackInfo { get; set; }
		public DelegateCommand GetTrackInfoCommand { get; set; }
		public DelegateCommand PlayTrackCommand { get; set; }
		public DelegateCommand PauseTrackCommand { get; set; }
		public DelegateCommand PreviousPageCommand { get; set; }
		public DelegateCommand ShareTrackCommand { get; set; }
		public string Id { get; set; }
		ISimpleAudioPlayer player;

		public SongPlayerPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
		{
			var stream = GetStreamFromFile("Nameofmp3.mp3");
			player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
			player.Load(stream);

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

			PlayTrackCommand = new DelegateCommand(async () =>
			{
				player.Play();
			});

			PauseTrackCommand = new DelegateCommand(async () =>
			{
				player.Pause();
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

		Stream GetStreamFromFile(string filename)
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;

			var stream = assembly.GetManifestResourceStream("NotSpotifyApp." + filename);

			return stream;
		}

	}
}
