using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Custom
{
    // Custom intermediate class used to temporarily store treasure data during randomization
    public class Treasure
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ContentNum { get; set; }
        public int ObjectId { get; set; }

    }
}
