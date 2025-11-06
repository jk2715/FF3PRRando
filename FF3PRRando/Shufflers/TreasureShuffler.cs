using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Custom;
using FF3PRRando.Utility;

namespace FF3PRRando.Shufflers
{
    public static class TreasureShuffler
    {
        public static List<Map> ShuffleTreasure(JsonReader jsonReader, int seedNumber) 
        { 
            Random random = new Random(seedNumber);
            var mapEntities = jsonReader.GetMapEntitiesWithTreasure();
            var treasures = mapEntities.SelectMany(x => x.Treasures.Select(x => Tuple.Create(x.ContentId, x.ContentNum))).ToArray();
            random.Shuffle(treasures);
            var randomTreasureList = treasures.ToList();
            for (int i = 0; i < mapEntities.Count; i++) 
            {
                for (int j = 0; j < mapEntities[i].Treasures.Count; j++) 
                { 
                    if(treasures.Length > 0)
                    {
                        var nextTreasure = randomTreasureList[0];
                        mapEntities[i].Treasures[j].ContentId = nextTreasure.Item1;
                        mapEntities[i].Treasures[j].ContentNum = nextTreasure.Item2;
                        randomTreasureList.RemoveAt(0);
                    }
                }
            }
            jsonReader.WriteToMapEntities(mapEntities);
            return mapEntities;
        }
    }
}
