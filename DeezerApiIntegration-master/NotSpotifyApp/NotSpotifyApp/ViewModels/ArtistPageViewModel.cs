using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class ArtistPageViewModel : BaseViewModel
    {
        Artist _selectedArtist;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ObservableCollection<Artist> ModelArtists { get; set; } = new ObservableCollection<Artist>();
        public DelegateCommand SearchArtistCommand { get; set; }
        public string Id { get; set; }

        public Artist SelectedArtist 
        {
            get { return _selectedArtist; }
            set
            {
                _selectedArtist = value;

                if (_selectedArtist != null)
                    DisplaySelectedElement();
            }
        }

        public ArtistPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            _navigationService = navigationService;
            _dialogService = pageDialogService;

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

        public async void DisplaySelectedElement()
        {
           await _dialogService.DisplayAlertAsync($"{AlertTextConstants.SelectedText}",$"Artist name: {_selectedArtist.Name}",$"{AlertTextConstants.OptionButtonText}");
        }

        public void LoadModelArtists()
        {
            ModelArtists.Add(new Artist() { Name = "Fifth Harmony", Picture = "FifthHarmony.jpg" });
            ModelArtists.Add(new Artist() { Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            ModelArtists.Add(new Artist() { Name = "Halsey", Picture = "Halsey.jpg" });
            ModelArtists.Add(new Artist() { Name = "Travis Scott", Picture = "TravisScott.jpg" });
            ModelArtists.Add(new Artist() { Name = "Troye Sivan", Picture = "TroyeSivan.jpg" });
            ModelArtists.Add(new Artist() { Name = "Dua Lipa", Picture = "DuaLipa.jpg" });
            ModelArtists.Add(new Artist() { Name = "The Weeknd", Picture = "TheWeeknd.jpg" });
        }

        
           
    }
}

       

