using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSpotifyApp.Models
{
	public class Genre
	{
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty( "name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("picture_small")]
        public string PictureSmall { get; set; }

        [JsonProperty("picture_medium")]
        public string PictureMedium { get; set; }

        [JsonProperty("picture_big")]
        public string PictureBig { get; set; }

        [JsonProperty("picture_xl")]
        public string PictureXl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
