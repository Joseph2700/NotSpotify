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
    public class HomePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        protected IDeezerApiService _apiService;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Artist> _artists;
        private ObservableCollection<Album> _albums;
        private ObservableCollection<Track> _tracks;

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {         
            _artists = new ObservableCollection<Artist>();
            _artists.Add(new Artist { Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            _artists.Add(new Artist { Name = "NCT 127", Picture = "NCT127.jpg" });
            _artists.Add(new Artist { Name = "Jhene Aiko", Picture = "JheneAiko.jpg" });
            _artists.Add(new Artist { Name = "BTS", Picture = "BTS.jpg" });
            _artists.Add(new Artist { Name = "Post Malone", Picture = "PostMalone.jpg" });
            _artists.Add(new Artist { Name = "Lil Baby", Picture = "LilBaby.jpg" });
            _artists.Add(new Artist { Name = "Bad Bunny", Picture = "BadBunny.jpg" });
            _artists.Add(new Artist { Name = "Billie Eilish", Picture = "BillieEilish.jpg" });

            _albums = new ObservableCollection<Album>();
            _albums.Add(new Album { Title = "YHLQMDLG", CoverXl = "YHLQMDLG.jpg" });
            _albums.Add(new Album { Title = "Saturation", CoverXl = "Saturation.jpg" });
            _albums.Add(new Album { Title = "Blond", CoverXl = "Blond.jpg" });
            _albums.Add(new Album { Title = "T R A P S O U L", CoverXl = "Trapsoul.jpg" });
            _albums.Add(new Album { Title = "Blond", CoverXl = "Blond.jpg" });

            _tracks = new ObservableCollection<Track>();
            _tracks.Add(new Track { Rank = 1,Title = "The Box - Roddy Rich"});
            _tracks.Add(new Track { Rank = 2, Title = "Don't Start now - Dua Lipa"});
            _tracks.Add(new Track { Rank = 3, Title = "Life Is Good - Future ft Drake"});
            _tracks.Add(new Track { Rank = 4, Title = "Blinding Lights - The Weeknd"});
            _tracks.Add(new Track { Rank = 5, Title = "Circles - Post Malone"});

        }

        public ObservableCollection<Artist> Artists
        {
            get
            {
                return _artists;
            }
            set
            {
                if (_artists != value)
                {
                    _artists = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Artists"));
                }
            }
        }

        public ObservableCollection<Album> Albums
        {
            get
            {
                return _albums;
            }
            set
            {
                if (_albums != value)
                {
                    _albums = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Albums"));
                }
            }
        }

        public ObservableCollection<Track> Tracks
        {
            get
            {
                return _tracks;
            }
            set
            {
                if (_tracks != value)
                {
                    _tracks = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Tracks"));
                }
            }
        }
        private void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }

    }
}
