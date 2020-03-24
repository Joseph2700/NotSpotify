using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class ArtistInfoPageViewModel : BaseViewModel, IInitialize
    {
        public Artist ArtistInfo { get; set; }
        public DelegateCommand GetArtistInfoCommand { get; set; }
        public string Id { get; set; }

        public void Initialize(INavigationParameters parameters) 
        {
            if(parameters.ContainsKey("Artist id"))
            {
                Id = parameters["Artist id"].ToString();
            }
           
        }

        public ArtistInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeezerApiService apiService) : base(navigationService, apiService)
        {
            GetArtistInfoCommand = new DelegateCommand(async () =>
            {
                await GetArtistData();
            });

            GetArtistInfoCommand.Execute();

        }

        async Task GetArtistData()
        {
            ArtistInfo = await ApiService.GetArtistInfo(Id);
        }
    }
}
