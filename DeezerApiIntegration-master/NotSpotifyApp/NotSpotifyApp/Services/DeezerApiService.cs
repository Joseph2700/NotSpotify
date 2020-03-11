using Newtonsoft.Json;
using NotSpotifyApp.Models;
using NotSpotifyApp.Utilities;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotSpotifyApp.Services
{
   public class DeezerApiService : IDeezerApiService
    {
        public async Task<Artist> GetArtistInfo(string Id)
        {
			try
			{
				HttpClient artistClient = new HttpClient();
				artistClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
				artistClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
				var result = await artistClient.GetStringAsync($"{ApiConfig.ArtistUrl}{Id}");
				return JsonConvert.DeserializeObject<Artist>(result);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"API EXCEPTION {ex}");
			}
			return default;
        }

		public async Task<Track> GetTrackInfo(string Id)
		{
			try
			{
				HttpClient trackClient = new HttpClient();
				trackClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
				trackClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
				var result = await trackClient.GetStringAsync($"{ApiConfig.TrackUrl}{Id}");
				return JsonConvert.DeserializeObject<Track>(result);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"API EXCEPTION {ex}");
			}
			return default;
		}

		public async Task<Genre> GetGenreInfo(string Id)
		{
			try
			{
				HttpClient genreClient = new HttpClient();
				genreClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
				genreClient.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
				var result = await genreClient.GetStringAsync($"{ApiConfig.GenreUrl}{Id}");
				return JsonConvert.DeserializeObject<Genre>(result);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"API EXCEPTION {ex}");
			}
			return default;
		}
	}
}
