using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Models
{
    public class Character
    {
        [JsonProperty("info")]
        public Info info { get; set; }

        [JsonProperty("results")]
        public List<Results> results { get; set; }
    }
}
