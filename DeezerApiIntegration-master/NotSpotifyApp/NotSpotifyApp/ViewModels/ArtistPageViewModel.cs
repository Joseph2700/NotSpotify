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
using Xamarin.Essentials;

namespace NotSpotifyApp.ViewModels
{
    public class ArtistPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<Artist> ModelArtists { get; set; } = new ObservableCollection<Artist>();
        public DelegateCommand SearchArtistCommand { get; set; }
        public string Id { get; set; }


        public ArtistPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _navigationService = navigationService;
            LoadModelArtists();
                      
            SearchArtistCommand = new DelegateCommand(async () =>
            {
                await SearchArtist();
            });
        }

        async Task SearchArtist()
        {
            var ArtistID = new NavigationParameters();
            ArtistID.Add("Artist id", Id);

            if (await CheckInternetConnection())
            {
                var navigation = _navigationService.NavigateAsync(NavigationConstants.ArtistInfoPage, ArtistID);
            }
        }


        public void LoadModelArtists()
        {
            ModelArtists.Add(new Artist() { Name = "Billie Eilish", Picture = "BillieEilish.jpg" });
            ModelArtists.Add(new Artist() { Name = "Jhené Aiko", Picture = "JheneAiko.jpg" });
            ModelArtists.Add(new Artist() { Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            ModelArtists.Add(new Artist() { Name = "Lil Baby", Picture = "LilBaby.jpg" });
            ModelArtists.Add(new Artist() { Name = "Bad Bunny", Picture = "BadBunny.jpg" });
            ModelArtists.Add(new Artist() { Name = "NCT 127", Picture = "NCT127.jpg" });
            ModelArtists.Add(new Artist() { Name = "BTS", Picture = "BTS.jpg" });
            ModelArtists.Add(new Artist() { Name = "Post Malone", Picture = "PostMalone.jpg" });
        }

        
           
    }
}

       

