using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace NotSpotifyApp.ViewModels
	{
		public class AlbumPageViewModel : BaseViewModel
		{
		    private readonly INavigationService _navigationService;
		    public ObservableCollection<Album> ModelAlbums { get; set; } = new ObservableCollection<Album>();
			public DelegateCommand SearchAlbumCommand { get; set; }
			public DelegateCommand GoToFavoriteAlbumsPageCommand { get; set; } 
			public string Id { get; set; }

			public AlbumPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
			{
			    _navigationService = navigationService;
			    LoadModelAlbums();

				SearchAlbumCommand = new DelegateCommand(async () =>
				{
					await SearchAlbum();
				});

				GoToFavoriteAlbumsPageCommand = new DelegateCommand(async () =>
				{
					await navigationService.NavigateAsync(NavigationConstants.FavoriteAlbumsPage);
				});
			}

			async Task SearchAlbum()
			{
				var AlbumID = new NavigationParameters();
				AlbumID.Add("Album id", Id);

				if (await CheckInternetConnection())
				{
					var navigation = _navigationService.NavigateAsync(NavigationConstants.AlbumInfoPage, AlbumID);
				}
			}


		public void LoadModelAlbums()
			{
				ModelAlbums.Add(new Album() { Title = "YHLQMDLG", CoverXl = "YHLQMDLG.jpg", ReleaseDate = "29 de febrero de 2020" });
				ModelAlbums.Add(new Album() { Title = "Blonde", CoverXl = "Blond.jpg", ReleaseDate = "20 de agosto de 2016"});
				ModelAlbums.Add(new Album() { Title = "Saturation", CoverXl = "Saturation.jpg", ReleaseDate = "9 de junio de 2017" });
				ModelAlbums.Add(new Album() { Title = "T R A P S O U L", CoverXl = "Trapsoul.jpg", ReleaseDate = "2 de octubre de 2015" });
			
			}

	    }
}


