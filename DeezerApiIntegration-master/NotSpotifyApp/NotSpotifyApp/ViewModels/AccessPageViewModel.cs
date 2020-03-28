using NotSpotifyApp.Services;
using NotSpotifyApp.Utilities;
using Plugin.Fingerprint;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSpotifyApp.ViewModels
{
    public class AccessPageViewModel : BaseViewModel
    {
       
        public DelegateCommand FingerprintCommand { get; set; }
        public AccessPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService, IDeezerApiService apiService) : base(navigationService, apiService)
        {


            FingerprintCommand = new DelegateCommand(async() =>
            {
                await FingerprintMethod();
            });

             async Task FingerprintMethod()
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync("Use your fingerprint to access NotSpotifyApp!");
                if (result.Authenticated)
                {
                    await navigationService.NavigateAsync(new Uri(NavigationConstants.TabbedPageMenu, UriKind.Absolute));
                }
                else
                {
                    await pageDialogueService.DisplayActionSheetAsync("Something went wrong", "Invalid fingerprint, please try again.", "Ok");
                }
            }
        }

        

    }
}
