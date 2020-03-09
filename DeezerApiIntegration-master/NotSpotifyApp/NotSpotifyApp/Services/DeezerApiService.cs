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
				HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Add($"{ApiConfig.ApiHost}", $"{ApiConfig.ApiHostValue}");
				client.DefaultRequestHeaders.Add($"{ApiConfig.ApiKey}", $"{ApiConfig.ApiKeyValue}");
				var result = await client.GetStringAsync($"{ApiConfig.ArtistUrl}{Id}");
				return JsonConvert.DeserializeObject<Artist>(result);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"API EXCEPTION {ex}");
			}
			return default;
        }
    }
}
