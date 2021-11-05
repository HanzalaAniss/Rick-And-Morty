using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Models
{
    public partial class Location
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }
    }
}
