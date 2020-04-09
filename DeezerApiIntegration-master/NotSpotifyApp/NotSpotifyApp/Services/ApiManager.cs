using MonkeyCache.FileStore;
using NotSpotifyApp.Models;
using NotSpotifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;
using NotSpotifyApp.Utilities;
using System.Diagnostics;

namespace NotSpotifyApp.Services
{
    public class ApiManager : IApiManager
    {
        public ObservableCollection<Track> GetTracks { get; set; } = new ObservableCollection<Track>();
        public ObservableCollection<Album> GetAlbums { get; set; } = new ObservableCollection<Album>();
        

        public ApiManager()
        {
            Barrel.ApplicationId = "NotSpotifyApp";
        }

        public async Task<ObservableCollection<Album>> AddFavoriteAlbumAsync(string Id)
        {
            byte BarrelID = 20;
            byte ValidBarrel = 0;
            string AlbumBarrelKey;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: $"{ApiConfig.AlbumUrl},{ApiConfig.ApiKeyValue}"))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Please check your internet connection", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<ObservableCollection<Album>>(key: $"{ApiConfig.AlbumUrl},{ApiConfig.ApiKeyValue}");
                }

                HttpClient albumClient = new HttpClient();
                albumClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
                albumClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
                var result = await albumClient.GetStringAsync($"{ApiConfig.AlbumUrl}{Id}");
                var Albums = JsonConvert.DeserializeObject<Album>(result);

                do
                {
                    AlbumBarrelKey = BarrelID.ToString();
                    var barrelResult = Barrel.Current.Get<Album>(key: AlbumBarrelKey);

                    if (barrelResult == null)
                    {
                        Barrel.Current.Add(key: AlbumBarrelKey, data: Albums, expireIn: TimeSpan.FromDays(1));
                        ValidBarrel++;
                    }
                    BarrelID++;

                } while (ValidBarrel != 1);


                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API EXCEPTION {ex}");
            }
            return null;
        }

        public async Task<ObservableCollection<Track>> AddFavoriteTrackAsync(string Id)
        {
            byte BarrelID = 0;
            byte ValidBarrel = 0;
            string TrackBarrelKey;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: $"{ApiConfig.TrackUrl},{ApiConfig.ApiKeyValue}"))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Please check your internet connection", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<ObservableCollection<Track>>(key: $"{ApiConfig.TrackUrl},{ApiConfig.ApiKeyValue}");
                }

                HttpClient trackClient = new HttpClient();
                trackClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
                trackClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
                var result = await trackClient.GetStringAsync($"{ApiConfig.TrackUrl}{Id}");
                var Tracks = JsonConvert.DeserializeObject<Track>(result);

                do
                {
                    TrackBarrelKey = BarrelID.ToString();
                    var barrelResult = Barrel.Current.Get<Track>(key: TrackBarrelKey);

                    if (barrelResult == null)
                    {
                        Barrel.Current.Add(key: TrackBarrelKey, data: Tracks, expireIn: TimeSpan.FromDays(1));
                        ValidBarrel++;
                    }
                    BarrelID++;

                } while (ValidBarrel != 1);
               

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API EXCEPTION {ex}");
            }
            return null;
        }

        public async Task<ObservableCollection<Album>> ShowAlbumDataAsync()
        {
            byte KeyValue = 20;
            byte ValidCondition = 0;
            do
            {
                string BarrelKeyValue;
                BarrelKeyValue = KeyValue.ToString();
                var albumBarrelResult = Barrel.Current.Get<Album>(key: BarrelKeyValue);

                if (albumBarrelResult != null)
                {
                  GetAlbums.Add(albumBarrelResult);
                }

                else
                {
                    ValidCondition++;
                }
                KeyValue++;

            } while (ValidCondition != 1);

            return GetAlbums;
        }

        public async Task<ObservableCollection<Track>> ShowTrackDataAsync()
        {
            byte KeyValue = 0;
            byte ValidCondition = 0;
            do
            {
                string BarrelKeyValue;
                BarrelKeyValue = KeyValue.ToString();
                var trackBarrelResult = Barrel.Current.Get<Track>(key: BarrelKeyValue);

                if (trackBarrelResult != null)
                {
                    GetTracks.Add(trackBarrelResult);                
                }

                else
                {
                    ValidCondition++;
                }
                KeyValue++;

            } while (ValidCondition != 1);

            return GetTracks;
        }
       
    }
}


