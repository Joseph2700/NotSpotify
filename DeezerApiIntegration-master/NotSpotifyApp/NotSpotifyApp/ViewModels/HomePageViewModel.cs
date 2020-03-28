using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
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
    public class HomePageViewModel : BaseViewModel
    {
        protected IDeezerApiService _apiService;
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();
        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            LoadHomePageInfo();
        }

        public void LoadHomePageInfo()
        {        
            Artists.Add(new Artist { Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            Artists.Add(new Artist { Name = "NCT 127", Picture = "NCT127.jpg" });
            Artists.Add(new Artist { Name = "Jhene Aiko", Picture = "JheneAiko.jpg" });
            Artists.Add(new Artist { Name = "BTS", Picture = "BTS.jpg" });
            Artists.Add(new Artist { Name = "Post Malone", Picture = "PostMalone.jpg" });
            Artists.Add(new Artist { Name = "Lil Baby", Picture = "LilBaby.jpg" });
            Artists.Add(new Artist { Name = "Bad Bunny", Picture = "BadBunny.jpg" });
            Artists.Add(new Artist { Name = "Billie Eilish", Picture = "BillieEilish.jpg" });

            Albums.Add(new Album { Title = "YHLQMDLG", CoverXl = "YHLQMDLG.jpg" });
            Albums.Add(new Album { Title = "Saturation", CoverXl = "Saturation.jpg" });
            Albums.Add(new Album { Title = "Blond", CoverXl = "Blond.jpg" });
            Albums.Add(new Album { Title = "T R A P S O U L", CoverXl = "Trapsoul.jpg" });
            Albums.Add(new Album { Title = "Blond", CoverXl = "Blond.jpg" });
            
            Tracks.Add(new Track { Rank = 1, Title = "The Box - Roddy Rich" });
            Tracks.Add(new Track { Rank = 2, Title = "Don't Start now - Dua Lipa" });
            Tracks.Add(new Track { Rank = 3, Title = "Life Is Good - Future ft Drake" });
            Tracks.Add(new Track { Rank = 4, Title = "Blinding Lights - The Weeknd" });
            Tracks.Add(new Track { Rank = 5, Title = "Circles - Post Malone" });
        }


    }
}
