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
           await _dialogService.DisplayAlertAsync($"{AlertTextConstants.SelectedText}",$"Name: {_selectedArtist.Name}",$"{AlertTextConstants.OptionButtonText}");
        }

        public void LoadModelArtists()
        {
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

       

