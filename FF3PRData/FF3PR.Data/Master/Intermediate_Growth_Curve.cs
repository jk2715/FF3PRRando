using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Master
{
    public class Intermediate_Growth_Curve
    {
        public Intermediate_Growth_Curve(Intermediate_Growth_Curve igc)
        {
            id = igc.id;
            character_id = igc.character_id;
            job_id = igc.job_id;
            growth_curve_group_id = igc.growth_curve_group_id;
            exp_table_group_id = igc.exp_table_group_id;
        }

        public Intermediate_Growth_Curve() { }

        public int id {  get; set; }
        public int character_id {  get; set; }
        public int job_id { get; set; }
        public int growth_curve_group_id { get; set; }
        public int exp_table_group_id { get; set; }
    }
}
