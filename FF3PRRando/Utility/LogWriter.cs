using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Custom;
using FF3PR.Data.Enums;
using FF3PR.Data.Master;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FF3PRRando.Utility
{
    public class LogWriter
    {
        private readonly string _logPath;
        private readonly int _seed;
        public LogWriter(int seed) 
        { 
            _logPath = Path.GetDirectoryName($@"{Application.StartupPath}\spoilerlog");
            _seed = seed;
        }

        public void WriteRandomizedJobsToLog(List<Job> jobs)
        {
            var spoilerPath = $@"{_logPath}";
            if (!Directory.Exists(spoilerPath)){
                Directory.CreateDirectory(spoilerPath);
            }
            using (StreamWriter sw = File.AppendText($@"{spoilerPath}\spoilerlog_{_seed}.txt"))
            {
                sw.WriteLine("-----JOBS-----");
                foreach(var i in new List<Jobs> { Jobs.Warrior, Jobs.Monk, Jobs.WhiteMage, Jobs.BlackMage, Jobs.RedMage, Jobs.Ranger, Jobs.Knight, Jobs.Thief, Jobs.Scholar, 
                    Jobs.Geomancer, Jobs.Dragoon, Jobs.Viking, Jobs.DakrKnight, Jobs.Evoker, Jobs.Bard, Jobs.BlackBelt, Jobs.Devout, Jobs.Magus, Jobs.Summoner, Jobs.Sage, Jobs.Ninja}) 
                {
                    switch (i)
                    {
                        case Jobs.Warrior:
                            sw.WriteLine("");
                            sw.WriteLine("Wind Crystal:");
                            break;
                        case Jobs.Ranger:
                            sw.WriteLine("");
                            sw.WriteLine("Fire Crystal:");
                            break;
                        case Jobs.Geomancer:
                            sw.WriteLine("");
                            sw.WriteLine("Water Crystal:");
                            break;
                        case Jobs.Devout:
                            sw.WriteLine("");
                            sw.WriteLine("Earth Crystal:");
                            break;
                        case Jobs.Sage:
                            sw.WriteLine("");
                            sw.WriteLine("Eureka:");
                            break;
                    }
                    var jobIndex = jobs.IndexOf(jobs.Where(x => x.id == (int)i).FirstOrDefault()) + 1;
                    sw.WriteLine(Enum.GetName(typeof(Jobs), jobIndex));
                }
            } 
        }

        public void WriteRandomizedProductsToLog(List<Product> products)
        {
            using (StreamWriter sw = File.AppendText($@"{_logPath}\spoilerlog_{_seed}.txt"))
            {
                sw.WriteLine("");
                sw.WriteLine("-----SHOPS-----");
                sw.WriteLine("");
                var weaponShops = products.Where(x => Enum.IsDefined(typeof(WeaponShops), x.group_id)).Select(x => x.group_id);
                var armorShops = products.Where(x => Enum.IsDefined(typeof(ArmorShops), x.group_id)).Select(x => x.group_id);
                var itemShops = products.Where(x => Enum.IsDefined(typeof(ItemShops), x.group_id)).Select(x => x.group_id);
                var magicShops = products.Where(x => Enum.IsDefined(typeof(MagicShops), x.group_id)).Select(x => x.group_id);
                for (int i = 0; i < products.Count; i++)
                {
                    switch (products[i].group_id)
                    {
                        case int p when weaponShops.Contains(p):
                            sw.WriteLine($"{Enum.GetName(typeof(WeaponShops), p)} Weapon: {Enum.GetName(typeof(Content), products[i].content_id)}");
                            break;

                        case int p when armorShops.Contains(p):
                            sw.WriteLine($"{Enum.GetName(typeof(ArmorShops), p)} Armor: {Enum.GetName(typeof(Content), products[i].content_id)}");
                            break;

                        case int p when itemShops.Contains(p):
                            sw.WriteLine($"{Enum.GetName(typeof(ItemShops), p)} Item: {Enum.GetName(typeof(Content), products[i].content_id)}");
                            break;

                        case int p when magicShops.Contains(p):
                            sw.WriteLine($"{Enum.GetName(typeof(MagicShops), p)} Magic: {Enum.GetName(typeof(Content), products[i].content_id)}");
                            break;
                    }
                }
            }
        }

        public void WriteRandomizedTreasureToLog(List<Map> maps)
        {
            using (StreamWriter sw = File.AppendText($@"{_logPath}\spoilerlog_{_seed}.txt"))
            {
                sw.WriteLine("");
                sw.WriteLine("-----CHESTS-----");
                sw.WriteLine("");
                foreach(var map in maps)
                {
                    var mapName = Enum.GetName(typeof(MapNames), int.Parse(Enum.GetName(typeof(SubMaps), map.MapValue).Replace("Map_", string.Empty).Replace("_", string.Empty)));
                    for (int i = 0; i < map.Treasures.Count; i++) 
                    {
                        if(map.Treasures[i].ContentId != 1)
                            sw.WriteLine($"{mapName} #{i + 1}: {Enum.GetName(typeof(Content), map.Treasures[i].ContentId)}");
                        else
                            sw.WriteLine($"{mapName} #{i + 1}: {map.Treasures[i].ContentNum} {Enum.GetName(typeof(Content), map.Treasures[i].ContentId)}");
                    }
                }
            }
        }
    }
}
