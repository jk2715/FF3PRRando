using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Corresponds to Export.json files
    // Used to tell magicite which files should be included as part of a mod for each directory
    public class Export
    {
        public Export() { }

        [JsonProperty("keys")]
        public List<string> Keys { get; set; } = [];
        [JsonProperty("values")]
        public List<string> Values { get; set; } = [];
    }
}
