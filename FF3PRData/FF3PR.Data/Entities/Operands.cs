using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Part of the overall structure of the scripting files
    public class Operands
    {
        [JsonProperty("iValues")]
        public List<int> IValues { get; set; }

        [JsonProperty("rValues")]
        public List<double> RValues { get; set; }

        [JsonProperty("sValues")]
        public List<string> SValues { get; set; }
    }
}
