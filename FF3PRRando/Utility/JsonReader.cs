using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FF3PR.Data.Custom;
using FF3PR.Data.Entities;
using FF3PR.Data.Enums;
using Newtonsoft.Json;

namespace FF3PRRando.Utility
{
    public class JsonReader
    {
        private readonly string _magiciteExportDirectory;
        private readonly string _outputDirectory;

        public JsonReader(string magiciteExportDirectory, string outputDirectory, int seed)
        {
            _magiciteExportDirectory = magiciteExportDirectory;
            _outputDirectory = $@"{outputDirectory}\FF3PRR_{seed}";
        }

        // Gets a list of all maps in the game which contain treasure (be it through chests, pots etc.) as well as a list for each map which contains the contents of each treasure 
        public List<Map> GetMapEntitiesWithTreasure()
        {
            var mapEntities = new List<Map>();
            foreach (var mapName in Enum.GetNames<Maps>())
            {
                var subMaps = Enum.GetNames<SubMaps>().Where(x => x.Contains(mapName));
                foreach (var subMap in subMaps)
                {
                    var treasureList = new List<Treasure>();
                    var subMapPath = $@"{_magiciteExportDirectory}\{mapName.ToLower()}\Assets\GameAssets\Serial\Res\Map\{mapName}\{subMap}";
                    var subMapFilePath = $@"{subMapPath}\entity_default.json";
                    if (!Directory.Exists(subMapPath) || !File.Exists(subMapFilePath))
                        continue;
                    var rootObject = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(subMapFilePath));
                    var layers = rootObject?.Layers.Where(x => x.Objects.Where(y => y.Properties.Where(z => z.Name == "action_id" && z.Value == "6").Any()).Any());
                    foreach(var layer in layers ?? new List<Layer>())
                    {
                        int i = 1;
                        foreach(var mObject in layer.Objects)
                        {
                            var treasure = new Treasure();
                            if (mObject.Properties.Where(x => x.Name == "action_id" && x.Value == "6").Count() < 1)
                            {
                                continue;
                            }
                            treasure.Id = i;
                            treasure.ContentId = int.Parse(mObject.Properties.Where(x => x.Name == "content_id").Select(x => x.Value).FirstOrDefault());
                            treasure.ContentNum = int.Parse(mObject.Properties.Where(x => x.Name == "content_num").Select(x => x.Value).FirstOrDefault());
                            treasure.ObjectId = mObject.Id;
                            i++;
                            treasureList.Add(treasure);
                        }
                    }
                    mapEntities.Add(new Map
                    {
                        MapValue = Enum.Parse<SubMaps>(subMap),
                        Treasures = treasureList
                    });
                }
            }
            return mapEntities;
        }

        // Edit and save the script file for each map where with the newly randomized treasures
        public void WriteToMapEntities(List<Map> mapData)
        {
            foreach (var map in mapData) 
            {
                string mapName = Enum.GetName(map.MapValue);
                string upperDirectory = mapName.Split("_").Length > 2 ? $"{mapName.Split("_")[0]}_{mapName.Split("_")[1]}" : mapName;
                var entityDirectory = $@"{_magiciteExportDirectory}\{upperDirectory.ToLowerInvariant()}\Assets\GameAssets\Serial\Res\Map\{upperDirectory}\{mapName}\entity_default.json";
                var outputDirectory = $@"{_outputDirectory}\{upperDirectory.ToLowerInvariant()}\Assets\GameAssets\Serial\Res\Map\{upperDirectory}\{mapName}";
                var keysDirectory = $@"{_outputDirectory}\{upperDirectory.ToLowerInvariant()}\keys";
                var rootObject = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(entityDirectory));
                for(int i = 0; i < rootObject.Layers.Count; i++)
                {
                    for(int j = 0; j < rootObject.Layers[i].Objects.Count; j++)
                    {
                        if (rootObject.Layers[i].Objects[j].Properties.Where(x => x.Name == "action_id" && x.Value == "6").Count() < 1)
                        {
                            continue;
                        }
                        var treasureToUpdate = map.Treasures.Where(x => x.ObjectId == rootObject.Layers[i].Objects[j].Id).FirstOrDefault();
                        for(int k = 0; k < rootObject.Layers[i].Objects[j].Properties.Count; k++)
                        {
                            if (rootObject.Layers[i].Objects[j].Properties[k].Name == "content_id")
                            {
                                rootObject.Layers[i].Objects[j].Properties[k].Value = treasureToUpdate.ContentId.ToString();
                            }
                            if(rootObject.Layers[i].Objects[j].Properties[k].Name == "content_num")
                            {
                                rootObject.Layers[i].Objects[j].Properties[k].Value = treasureToUpdate.ContentNum.ToString();
                            }
                            if(rootObject.Layers[i].Objects[j].Properties[k].Name == "message_key")
                            {
                                if (treasureToUpdate.ContentId == 1)
                                    rootObject.Layers[i].Objects[j].Properties[k].Value = "t0001_02";
                                else
                                    rootObject.Layers[i].Objects[j].Properties[k].Value = "t0001_01";
                            }
                        }
                    }
                }
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }
                File.WriteAllText($@"{outputDirectory}\entity_default.json", JsonConvert.SerializeObject(rootObject));

                if (!Directory.Exists(keysDirectory)) 
                {
                    Directory.CreateDirectory(keysDirectory);
                }
                var export = new Export();
                string exportPath = $@"{keysDirectory}\Export.json";
                if (File.Exists(exportPath))
                {
                    export = JsonConvert.DeserializeObject<Export>(File.ReadAllText(exportPath));
                }
                export?.Keys.Add($"{mapName}/entity_default");
                export?.Values.Add($"Assets/GameAssets/Serial/Res/Map/{upperDirectory}/{mapName}/entity_default");
                File.WriteAllText(exportPath, JsonConvert.SerializeObject(export));
            }   
        }

        // Initial steps to eventually enable an open world playthrough
        // Still very much incomplete
        public void InitializeOpenGameState()
        {
            var scriptDirectory = $@"{_magiciteExportDirectory}\map_10010\Assets\GameAssets\Serial\Res\Map\Map_10010\Map_10010";
            var keyDirectory = $@"{_outputDirectory}\map_10010\keys";
            var outputPath = $@"{_outputDirectory}\map_10010\Assets\GameAssets\Serial\Res\Map\Map_10010\Map_10010";
            // Set the enterprise to be available after the wind crystal
            SetAirShip(scriptDirectory, outputPath);
            // Remove the boulder blocking the way to Canaan
            RemoveBlockingBoulder(scriptDirectory, outputPath);
            // Disable flag check to spawn Aria
            SetAria();
            var export = new Export
            {
                Keys = ["Map_10010/sc_e_0206_1", "Map_10010/sc_map_10010"],
                Values = ["Assets/GameAssets/Serial/Res/Map/Map_10010/Map_10010/sc_e_0206_1", "Assets/GameAssets/Serial/Res/Map/Map_10010/Map_10010/sc_map_10010"]
            };
            WriteToExportFile(keyDirectory, export);
        }

        private void SetAirShip(string scriptDirectory, string outputDirectory)
        {
            var initialScript = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{scriptDirectory}\sc_e_0206_1.json"));
            var setVehicle = new Mnemonic
            {
                MnemonicName = "SetVehicle",
                Type = 1,
                Operands = new Operands
                {
                    IValues = [6, 1, 96, 36, 2, 2, 0, 0],
                    RValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    SValues = ["", "", "", "", "", "", "", ""]
                },
                Label = "",
                Comment = ""
            };
            var vehicleMnemonicIndex = initialScript.Mnemonics.IndexOf(initialScript.Mnemonics.Where(x => x.MnemonicName == "ChangeScript").FirstOrDefault());
            initialScript.Mnemonics.Insert(vehicleMnemonicIndex + 1, setVehicle);
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            File.WriteAllText($@"{outputDirectory}\sc_e_0206_1.json", JsonConvert.SerializeObject(initialScript));
        }

        private void RemoveBlockingBoulder(string scriptDirectory, string outputDirectory)
        {
            var initialMap = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{scriptDirectory}\sc_map_10010.json"));
            var boulderMnemonic = initialMap.Mnemonics.IndexOf(initialMap.Mnemonics.Where(x => x.Label == "ev_e_0067").FirstOrDefault());
            initialMap.Mnemonics.RemoveRange(boulderMnemonic, 3);
            var boatMnemonic = initialMap.Mnemonics.IndexOf(initialMap.Mnemonics.Where(x => x.Label == "ev_e_0184").FirstOrDefault());
            initialMap.Mnemonics.RemoveRange(boatMnemonic, 4);
            int removeRange = 3;
            for (int i = 0; i < initialMap.Mnemonics.Count; i++)
            {
                if (initialMap.Mnemonics[i].Label == "ev_e_0067")
                {
                    initialMap.Mnemonics.RemoveRange(i, 3);
                }

                else if (initialMap.Mnemonics[i].Label == "ev_e_0184")
                {
                    initialMap.Mnemonics.RemoveRange(i, 4);
                }
                else if (initialMap.Mnemonics[i].Label == "ev_e_0183")
                    removeRange += 4;
                if (initialMap.Mnemonics[i].MnemonicName == "Branch")
                    initialMap.Mnemonics[i].Operands.IValues[2] -= removeRange;
                else if (initialMap.Mnemonics[i].MnemonicName == "Call")
                    initialMap.Mnemonics[i].Operands.IValues[0] -= removeRange;
                else if (initialMap.Mnemonics[i].MnemonicName == "SetPuppet")
                    initialMap.Mnemonics[i].Operands.IValues[2] -= removeRange;
                else if (initialMap.Mnemonics[i].MnemonicName == "Jump")
                    initialMap.Mnemonics[i].Operands.IValues[0] -= removeRange;
            }
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            File.WriteAllText($@"{outputDirectory}\sc_map_10010.json", JsonConvert.SerializeObject(initialMap));
        }


        private void SetAria()
        {
            var script = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{_magiciteExportDirectory}\map_20181\Assets\GameAssets\Serial\Res\Map\Map_20181\Map_20181_2\sc_map_20181_2.json"));
            var outputPath = $@"{_outputDirectory}\map_20181\Assets\GameAssets\Serial\Res\Map\Map_20181\Map_20181_2";
            var keyDirectory = $@"{_outputDirectory}\map_20181\keys";
            var branchIndex = script.Mnemonics.IndexOf(script.Mnemonics.Where(x => x.MnemonicName == "Branch" && x.Operands.IValues[0] == 62).FirstOrDefault());
            script.Mnemonics.RemoveAt(branchIndex);
            var mnemonic = new Mnemonic
            {
                Label = "",
                MnemonicName = "Call",
                Type = 1,
                Operands = new Operands
                {
                    IValues = [3, 0, 0, 0, 0, 0, 0, 0],
                    RValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    SValues = ["", "", "", "", "", "", "", ""]
                },
                Comment = ""
            };
            script.Mnemonics.Insert(branchIndex, mnemonic);
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            File.WriteAllText($@"{outputPath}\sc_map_20181_2.json", JsonConvert.SerializeObject(script));
            var export = new Export
            {
                Keys = ["Map_20181_2/sc_map_20181_2"],
                Values = ["Assets/GameAssets/Serial/Res/Map/Map_20181/Map_20181_2/sc_map_20181_2"]
            };
            WriteToExportFile(keyDirectory, export);
        }

        // Remove the requirement to be in Toad status for various story sequences
        public void DisableFrogRequirement(string map, string subMap, string scriptName, int callPosition)
        {
           // var script = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{_magiciteExportDirectory}\map_30071\Assets\GameAssets\Serial\Res\Map\Map_30071\Map_30071_1\sc_e_0040.json"));
            var script = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{_magiciteExportDirectory}\{map.ToLower()}\Assets\GameAssets\Serial\Res\Map\{map}\{subMap}\{scriptName}.json"));
            var outputPath = $@"{_outputDirectory}\{map}\Assets\GameAssets\Serial\Res\Map\{map}\{subMap}";
            var keyDirectory = $@"{_outputDirectory}\{map.ToLower()}\keys";
            var newMnemonic = new Mnemonic
            {
                MnemonicName = "Call",
                Label = "",
                Operands = new Operands
                {
                    IValues = [callPosition, 0, 0, 0, 0, 0, 0, 0],
                    RValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    SValues = ["", "", "", "", "", "", "", ""]
                },
                Type = 1,
                Comment = ""
            };
            var branchIndex = script.Mnemonics.IndexOf(script.Mnemonics.Where(x => x.MnemonicName == "Branch").FirstOrDefault());
            script.Mnemonics.RemoveAt(branchIndex);
            script.Mnemonics.Insert(branchIndex, newMnemonic);
            if(!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            File.WriteAllText($@"{outputPath}\{scriptName}.json", JsonConvert.SerializeObject(script));
            var export = new Export
            {
                Keys = [$"{subMap}/{scriptName}"],
                Values = [$"Assets/GameAssets/Serial/Res/Map/{map}/{subMap}/{scriptName}"]
            };
            WriteToExportFile(keyDirectory, export);
        }

        // Add free mallets to the specified map to allow access to the Mini status regardless of whether or not there are magic users in the party
        // Currently used for the healing spring before Tozus and the first room in Castle Hein
        public void AddMallets(string map, string subMap, string scriptName)
        {
            var script = JsonConvert.DeserializeObject<ScriptRoot>(File.ReadAllText($@"{_magiciteExportDirectory}\{map.ToLower()}\Assets\GameAssets\Serial\Res\Map\{map}\{subMap}\{scriptName}.json"));
            var outputPath = $@"{_outputDirectory}\{map.ToLower()}\Assets\GameAssets\Serial\Res\Map\{map}\{subMap}";
            var keyDirectory = $@"{_outputDirectory}\{map}\keys";
            var getItem = new Mnemonic
            {
                MnemonicName = "GetItem",
                Type = 1,
                Operands = new Operands
                {
                    IValues = [9, 8, 0, 0, 0, 0, 0, 0],
                    RValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    SValues = ["", "", "", "", "", "", "", ""]
                },
                Label = "",
                Comment = ""
            };
            var msgMallet = new Mnemonic
            {
                MnemonicName = "Msg",
                Type = 1,
                Operands = new Operands
                {
                    IValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    RValues = [0, 0, 0, 0, 0, 0, 0, 0],
                    SValues = ["E0250_00_999_a_01", "", "", "", "", "", "", ""]
                },
                Label = "",
                Comment = ""
            };
            var msgIndex = script.Mnemonics.IndexOf(script.Mnemonics.Where(x => x.MnemonicName == "Msg").LastOrDefault());
            script.Mnemonics.Insert(msgIndex, getItem);
            script.Mnemonics.Insert(msgIndex + 1, msgMallet);
            for (int i = 0; i < script.Mnemonics.Count; i++) 
            {
                if (script.Mnemonics[i].MnemonicName == "Call")
                    script.Mnemonics[i].Operands.IValues[0] += 2;
                else if (script.Mnemonics[i].MnemonicName == "SetPuppet")
                    script.Mnemonics[i].Operands.IValues[2] += 2;
            }
            if(!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            File.WriteAllText($@"{outputPath}\{scriptName}.json", JsonConvert.SerializeObject(script));
            var export = new Export
            {
                Keys = [$"{subMap}/{scriptName}"],
                Values = [$"Assets/GameAssets/Serial/Res/Map/{map}/{subMap}/{scriptName}"]
            };
            WriteToExportFile(keyDirectory, export);
        }

        public void WriteToExportFile(string keyDirectory, Export exportToWrite)
        {
            string exportPath = $@"{keyDirectory}\Export.json";
            if (!Directory.Exists(keyDirectory))
            {
                Directory.CreateDirectory(keyDirectory);
            }
            var export = new Export();
            if (File.Exists(exportPath))
            {
                export = JsonConvert.DeserializeObject<Export>(File.ReadAllText(exportPath));
            }
            export?.Keys.AddRange(exportToWrite.Keys);
            export?.Values.AddRange(exportToWrite.Values);
            File.WriteAllText(exportPath, JsonConvert.SerializeObject(export));
        }
    }
}
