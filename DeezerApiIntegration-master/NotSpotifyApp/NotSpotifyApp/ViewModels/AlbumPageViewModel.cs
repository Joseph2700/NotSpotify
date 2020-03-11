using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace NotSpotifyApp.ViewModels
	{
		public class AlbumPageViewModel : BaseViewModel, INotifyPropertyChanged
		{

			protected IDeezerApiService _apiService;
			public event PropertyChangedEventHandler PropertyChanged;
			public DelegateCommand GetAlbumInfoCommand { get; set; }
			public Album AlbumInfo { get; set; }
			public string Id { get; set; }

			public AlbumPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
			{
				_apiService = apiService;
				GetAlbumInfoCommand = new DelegateCommand(async () =>
				{
					await GetAlbumData();
				});
			}

			async Task GetAlbumData()
			{
				if (await CheckInternetConnection())
				{
					try
					{
						AlbumInfo = await _apiService.GetAlbumInfo(Id);				
					}
					catch (Exception ex)
					{
						Debug.WriteLine($"API EXCEPTION {ex}");
					}
				}
			}

		}
}


