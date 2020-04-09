using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSpotifyApp.Models
{
    public class Track
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
        [JsonProperty("track_position")]
        public int TrackPosition { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("share")]
        public string Share { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("album")]
        public Album Album { get; set; }
        [JsonProperty("artist")]
        public Artist Artist { get; set; }
        

       
            
    }
}
