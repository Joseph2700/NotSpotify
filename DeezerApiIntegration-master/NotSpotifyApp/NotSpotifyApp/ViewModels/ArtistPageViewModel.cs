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
           await _dialogService.DisplayAlertAsync($"{AlertTextConstants.SelectedText}",$"Artist name: {_selectedArtist.Name} \nArtist ID: {_selectedArtist.Id}",$"{AlertTextConstants.OptionButtonText}");
        }

        public void LoadModelArtists()
        {
            ModelArtists.Add(new Artist() { Id = 4974921, Name = "Fifth Harmony", Picture = "FifthHarmony.jpg" });
            ModelArtists.Add(new Artist() { Id = 7101343, Name = "Lil Uzi Vert", Picture = "LilUziVert.jpg" });
            ModelArtists.Add(new Artist() { Id = 5292512, Name = "Halsey", Picture = "Halsey.jpg" });
            ModelArtists.Add(new Artist() { Id = 4495513, Name = "Travis Scott", Picture = "TravisScott.jpg" });
            ModelArtists.Add(new Artist() { Id = 4746199, Name = "Troye Sivan", Picture = "TroyeSivan.jpg" });
            ModelArtists.Add(new Artist() { Id = 8706544, Name = "Dua Lipa", Picture = "DuaLipa.jpg" });

        }
       
    }
}

       

