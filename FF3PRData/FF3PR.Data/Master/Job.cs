using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Master
{
    public class Job
    {

        public Job(Job job)
        {
            id = job.id;
            mes_id_name = job.mes_id_name;
            mes_id_description = job.mes_id_description;
            change_command_1 = job.change_command_1;
            change_command_2 = job.change_command_2;
            change_command_3 = job.change_command_3;
            change_command_4 = job.change_command_4;
            change_command_5 = job.change_command_5;
            initial_condition = job.initial_condition;
            strength = job.strength;
            vitality = job.vitality;
            agility = job.agility;
            magic = job.magic;
        }
        public Job() { }

        public int id { get; set; }
        public string mes_id_name { get; set; }
        public string mes_id_description { get; set; }
        public int change_command_1 { get; set; }
        public int change_command_2 { get; set; }
        public int change_command_3 { get; set; }
        public int change_command_4 { get; set; }
        public int change_command_5 { get; set; }
        public int initial_condition { get; set; }
        public int strength { get; set; }
        public int vitality { get; set; }
        public int agility { get; set; }
        public int magic { get; set; }
    }
}
