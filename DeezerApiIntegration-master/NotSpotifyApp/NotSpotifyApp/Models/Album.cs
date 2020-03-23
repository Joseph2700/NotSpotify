using Newtonsoft.Json;

namespace NotSpotifyApp.Models
{
    public class Album
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("cover_small")]
        public string CoverSmall { get; set; }

        [JsonProperty("cover_medium")]
        public string CoverMedium { get; set; }

        [JsonProperty("cover_big")]
        public string CoverBig { get; set; }

        [JsonProperty("cover_xl")]
        public string CoverXl { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("tracklist")]
        public string Tracklist { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("genres")]
        public Genre Genre { get; set; }

        [JsonProperty("nb_tracks")]
        public int NumberOfTracks { get; set; }

        [JsonProperty("fans")]
        public int Fans { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }


    }
}