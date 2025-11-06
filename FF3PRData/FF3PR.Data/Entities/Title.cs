using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Part of the overall structure of the scripting files
    public class Title
    {
        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("sub")]
        public string Sub { get; set; }
    }
}
