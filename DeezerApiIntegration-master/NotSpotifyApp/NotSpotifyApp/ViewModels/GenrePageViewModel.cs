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
	public class GenrePageViewModel : BaseViewModel
	{		
		
		public DelegateCommand GetGenreInfoCommand { get; set; }
		public Genre GenreInfo { get; set; }
		public string Id { get; set; }

		public GenrePageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
		{
			
			GetGenreInfoCommand = new DelegateCommand(async () =>
			{
				await GetGenreData();
			});
		}

		async Task GetGenreData()
		{
			if (await CheckInternetConnection())
			{
					GenreInfo = await ApiService.GetGenreInfo(Id);
			
			}
		}

	}
}
