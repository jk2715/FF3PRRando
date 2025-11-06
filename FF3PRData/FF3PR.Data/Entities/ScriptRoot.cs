using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    // The root class containing all sub classes which correspond to data objects found in the scripting JSON files
    // Used to edit scripted in-game events
    public class ScriptRoot
    {
        [JsonProperty("SystemFlag")]
        public SystemFlag SystemFlag { get; set; }

        [JsonProperty("Segments")]
        public List<Segment> Segments { get; set; }

        [JsonProperty("ScriptLocal")]
        public List<object> ScriptLocal { get; set; }

        [JsonProperty("ScriptLocalValue")]
        public List<object> ScriptLocalValue { get; set; }

        [JsonProperty("Mnemonics")]
        public List<Mnemonic> Mnemonics { get; set; }

        [JsonProperty("Animations")]
        public List<object> Animations { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Title")]
        public Title Title { get; set; }
    }
}
