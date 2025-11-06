using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Entities
{
    // Part of the overall structure of the scripting files
    public class Segment
    {
        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("EntryPoint")]
        public int EntryPoint { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
