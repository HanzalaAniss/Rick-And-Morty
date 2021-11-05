using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Models
{
    public class Results
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("species")]
        public string species { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("origin")]

        public Origin origin { get; set; }

        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("image")]
        public Uri image { get; set; }

        [JsonProperty("episode"), JsonIgnore]
        public Episode[] episode { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }

        [JsonProperty("created")]
        public string created { get; set; }

    }
}
