using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;

namespace NotSpotifyApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        Artist _selectedArtist;
        Album _selectedAlbum;
        Track _selectedTrack;
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();
        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();
        public DelegateCommand<Artist> GoToArtistInfoPage { get; set; }
        public DelegateCommand<Album> GoToAlbumInfoPage { get; set; }
        public DelegateCommand<Track> GoToTrackInfoPage { get; set; }

        public Artist SelectedArtist
        {
            get { return _selectedArtist; }
            set
            {
                _selectedArtist = value;

                if (_selectedArtist != null); 
            }
        }

        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;

                if (_selectedAlbum != null) ;
            }
        }

        public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set
            {
                _selectedTrack = value;

                if (_selectedTrack != null) ;
            }
        }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            
            LoadModelArtists();
            LoadModelAlbums();
            LoadModelTracks();

            GoToArtistInfoPage = new DelegateCommand<Artist>(async (_selectedArtist) =>
            {
                var ArtistID = new NavigationParameters();
                ArtistID.Add("Artist id", _selectedArtist.Id);

                await NavigationService.NavigateAsync(NavigationConstants.ArtistInfoPage, ArtistID);

            });

            GoToAlbumInfoPage = new DelegateCommand<Album>(async (_selectedAlbum) =>
            {
                var AlbumID = new NavigationParameters();
                AlbumID.Add("Album id", _selectedAlbum.Id);

                await NavigationService.NavigateAsync(NavigationConstants.AlbumInfoPage, AlbumID);
            });

            GoToTrackInfoPage = new DelegateCommand<Track>(async (_selectedTrack) =>
            {
                var TrackID = new NavigationParameters();
                TrackID.Add("Track id", _selectedTrack.Id);

                await NavigationService.NavigateAsync(NavigationConstants.TrackInfoPage, TrackID);
            });

        }

        public void LoadModelArtists()
        {
            Artists.Add(new Artist { Id = 4050205, Name = "The Weeknd", Picture = "TheWeeknd.jpg" });
            Artists.Add(new Artist { Id = 4103408, Name = "5 Seconds Of Summer", Picture = "SOS.jpg" });
            Artists.Add(new Artist { Id = 1319, Name = "Pearl Jam", Picture = "PearlJam.jpg" });
            Artists.Add(new Artist { Id = 8706544, Name = "Dua Lipa", Picture = "DuaLipa.jpg" });
            Artists.Add(new Artist { Id = 7101343, Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            Artists.Add(new Artist { Id = 9635624, Name = "Billie Eilish", Picture = "BillieEilish.jpg" });

        }

        public void LoadModelAlbums()
        {

            Albums.Add(new Album { Id = 137217782, Title = "After Hours", CoverXl = "AfterHours.jpg" });
            Albums.Add(new Album { Id = 137822762, Title = "Calm", CoverXl = "Calm.jpg" });
            Albums.Add(new Album { Id = 135172192, Title = "Eternal Atake", CoverXl = "EternalAtake.jpg" });
            Albums.Add(new Album { Id = 137938012, Title = "Future Nostalgia", CoverXl = "FutureNostalgia.jpg" });
            Albums.Add(new Album { Id = 138369782, Title = "Gigaton", CoverXl = "Gigaton.jpg" });
            Albums.Add(new Album { Id = 133125512, Title = "My Turn", CoverXl = "MyTurn.jpg" });
            Albums.Add(new Album { Id = 133878352, Title = "YHLQMDLG", CoverXl = "YHLQMDLG.jpg" });
        }

        public void LoadModelTracks()
        {
            Tracks.Add(new Track { Rank = 1, Id = 819736552, Title = "Blinding Lights - The Weeknd" });
            Tracks.Add(new Track { Rank = 2, Id = 825986992, Title = "The Box - Rody Rich" });
            Tracks.Add(new Track { Rank = 3, Id = 793163542, Title = "Don't Start Now - Dua Lipa" });
            Tracks.Add(new Track { Rank = 4, Id = 742744952, Title = "Circles - Post Malone" });
            Tracks.Add(new Track { Rank = 5, Id = 847699482, Title = "Life is Good - Future ft Drake" });
            Tracks.Add(new Track { Rank = 6, Id = 826264812, Title =  "Adore You - Harry Styles" });
        }     
        
    }
}
