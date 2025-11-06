using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FF3PR.Data.Entities
{
    // Part of the overall structure of the scripting files
    public class SystemFlag
    {
        [JsonProperty("SkipInitialize")]
        public int SkipInitialize { get; set; }

        [JsonProperty("KeepPlayerPuppet")]
        public int KeepPlayerPuppet { get; set; }

        [JsonProperty("KeepBadStatusVisual")]
        public int KeepBadStatusVisual { get; set; }

        [JsonProperty("RidingVehicle")]
        public int RidingVehicle { get; set; }
    }
}
