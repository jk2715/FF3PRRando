using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Master
{
    public class Job_Group
    {
        public Job_Group(Job_Group jobGroup)
        {
            id = jobGroup.id;
            job1_accept = jobGroup.job1_accept;
            job2_accept = jobGroup.job2_accept;
            job3_accept = jobGroup.job3_accept;
            job4_accept = jobGroup.job4_accept;
            job5_accept = jobGroup.job5_accept;
            job6_accept = jobGroup.job6_accept;
            job7_accept = jobGroup.job7_accept;
            job8_accept = jobGroup.job8_accept;
            job9_accept = jobGroup.job9_accept;
            job10_accept = jobGroup.job10_accept;
            job11_accept = jobGroup.job11_accept;
            job12_accept = jobGroup.job12_accept;
            job13_accept = jobGroup.job13_accept;
            job14_accept = jobGroup.job14_accept;
            job15_accept = jobGroup.job15_accept;
            job16_accept = jobGroup.job16_accept;
            job17_accept = jobGroup.job17_accept;
            job18_accept = jobGroup.job18_accept;
            job19_accept = jobGroup.job19_accept;
            job20_accept = jobGroup.job20_accept;
            job21_accept = jobGroup.job21_accept;
            job22_accept = jobGroup.job22_accept;
        }

        public Job_Group() { }

        public int id { get; set; }
        public int job1_accept { get; set; }
        public int job2_accept { get; set; }
        public int job3_accept { get; set; }
        public int job4_accept { get; set; }
        public int job5_accept { get; set; }
        public int job6_accept { get; set; }
        public int job7_accept { get; set; }
        public int job8_accept { get; set; }
        public int job9_accept { get; set; }
        public int job10_accept { get; set; }
        public int job11_accept { get; set; }
        public int job12_accept { get; set; }
        public int job13_accept { get; set; }
        public int job14_accept { get; set; }
        public int job15_accept { get; set; }
        public int job16_accept { get; set; }
        public int job17_accept { get; set; }
        public int job18_accept { get; set; }
        public int job19_accept { get; set; }
        public int job20_accept { get; set; }
        public int job21_accept { get; set; }
        public int job22_accept { get; set; }
    }
}
