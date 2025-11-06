using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Part of the overall structure of the scripting files
    public class Mnemonic
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("mnemonic")]
        public string MnemonicName { get; set; }

        [JsonProperty("operands")]
        public Operands Operands { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
