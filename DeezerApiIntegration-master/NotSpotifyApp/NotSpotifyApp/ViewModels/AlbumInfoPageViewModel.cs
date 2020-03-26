using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class AlbumInfoPageViewModel : BaseViewModel,IInitialize, INotifyPropertyChanged
    {
        public Album AlbumInfo { get; set; }
        public DelegateCommand GetAlbumInfoCommand { get; set; }
        public DelegateCommand ReturnToAlbumPageCommand { get; set; }
        public DelegateCommand ShareAlbumCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Id { get; set; }

        public AlbumInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            GetAlbumInfoCommand = new DelegateCommand(async () =>
            {
                await GetAlbumData();
            });

            ReturnToAlbumPageCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });

            ShareAlbumCommand = new DelegateCommand(async () =>
            {
               await CrossShare.Current.Share(new ShareMessage
               {
                    Title = $"Hey check this album out! - {AlbumInfo.Title}",
                    Url = $"{AlbumInfo.SharingLink}"
               });
            });
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Album id"))
            {
                Id = parameters["Album id"].ToString();
                GetAlbumInfoCommand.Execute();
            }
        }
        
        
        async Task GetAlbumData()
        {
            AlbumInfo = await ApiService.GetAlbumInfo(Id);
        }

    }
}
