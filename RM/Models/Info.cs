using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Models
{
    public partial class Info
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("pages")]
        public int pages { get; set; }

        [JsonProperty("next")]
        public Uri next { get; set; }

        [JsonProperty("prev")]
        public Uri prev { get; set; }

    }
}
