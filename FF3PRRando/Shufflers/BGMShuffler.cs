using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Master;
using FF3PRRando.Utility;

namespace FF3PRRando.Shufflers
{
    public class BGMShuffler
    {
        public static List<BGM_Asset> GetAllBGMs(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<BGM_Asset>("bgm_asset.csv");
        }

        public static List<BGM_Asset> ShuffleBGMs(List<BGM_Asset> bgms, int seed)
        {
            Random rand = new Random(seed);
            var bgmIds = bgms.Select(x => x.id).ToArray();
            rand.Shuffle(bgmIds);
            List<int> fanfares = [84, 50, 13];
            for(int i = 0; i < bgms.Count; i++)
            {
                // Don't randomize certain fanfares as that breaks things
                if (fanfares.Contains(bgms[i].id))
                    continue;
                bgms[i].id = bgmIds[i];
            }
            return bgms;
        }

        public static void WriteToBGMMasterFile(CsvProcessor csvHelper, List<BGM_Asset> bgms)
        {
            csvHelper.WriteToMasterFile(bgms, "bgm_asset.csv");
        }
    }
}
