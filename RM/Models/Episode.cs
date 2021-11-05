using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Models
{
    public class Episode
    {
        [JsonProperty("url")]
        public Uri url { get; set; }
    }
}
