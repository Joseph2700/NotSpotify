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
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class TrackPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly INavigationService _navigationService;
        public ObservableCollection<Track> ModelTracks { get; set; } = new ObservableCollection<Track>();
        public DelegateCommand SearchTrackCommand { get; set; }
        public DelegateCommand GoToFavoriteTracksCommand { get; set; }
        public string Id { get; set; }

        public TrackPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _navigationService = navigationService;
            LoadModelTracks();

            SearchTrackCommand = new DelegateCommand(async () =>
            {
                await SearchTrack();
            });           
        }
        async Task SearchTrack()
        {
            var TrackID = new NavigationParameters();
            TrackID.Add("Track id", Id);

            if (await CheckInternetConnection())
            {
                var navigation = _navigationService.NavigateAsync(NavigationConstants.SongPlayerPage, TrackID);
            }
        }
        public void LoadModelTracks()
        {
            ModelTracks.Add(new Track() { Title = "The Box - Roddy Rich" });
            ModelTracks.Add(new Track() { Title = "Don't Start Now - Dua Lipa" });            
            ModelTracks.Add(new Track() { Title = "Life is Good - Future ft Drake" });
            ModelTracks.Add(new Track() { Title = "Blinding Lights - The Weeknd" });
            ModelTracks.Add(new Track() { Title = "Circles - Post Malone" });
        }
    }
}
