using NotSpotifyApp.Models;
using NotSpotifyApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class ArtistInfoPageViewModel : IInitialize
    {
        public Artist ArtistInfo { get; set; }
        public IDeezerApiService apiService { get; set; }
        public DelegateCommand GetArtistInfoCommand { get; set; }
        public string Id { get; set; }

        public void Initialize(INavigationParameters parameters) 
        {
            Id = parameters["Artist id"].ToString();
        }

        public ArtistInfoPageViewModel()
        {
            GetArtistInfoCommand = new DelegateCommand(async () =>
            {
                await GetArtistData();
            });

            GetArtistInfoCommand.Execute();


        }

        async Task GetArtistData()
        {
            ArtistInfo = await apiService.GetArtistInfo(Id);
        }
    }
}
