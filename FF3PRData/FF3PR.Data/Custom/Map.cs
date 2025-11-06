using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Enums;

namespace FF3PR.Data.Custom
{
    // Custom intermediate class used to temporarily store map and treasure data during randomization
    public class Map
    {
        public SubMaps MapValue { get; set; }
        public List<Treasure> Treasures { get; set; }
    }
}
