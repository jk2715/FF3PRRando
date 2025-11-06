using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Master;
using FF3PRRando.Utility;

namespace FF3PRRando.Shufflers
{
    public static class JobShuffler
    {
        public static List<Job> GetAllJobs(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<Job>("job.csv");
        }

        public static List<Job_Group> GetAllJobGroups(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<Job_Group>("job_group.csv");
        }

        public static List<Character_Asset> GetAllCharacterAssets(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<Character_Asset>("character_asset.csv");
        }

        public static List<Intermediate_Growth_Curve> GetAllIntermediateGrowthCurves(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<Intermediate_Growth_Curve>("intermediate_growth_curve.csv");
        }

        public static (List<Job>, List<Job_Group>, List<Character_Asset>, List<Intermediate_Growth_Curve>) ShuffleJobs(List<Job> jobs, List<Job_Group> jobGroups, List<Character_Asset> charAssets, List<Intermediate_Growth_Curve> igc, int seedNumber)
        {
            Random rand = new Random(seedNumber);
            jobs.Sort((x, y) => x.id.CompareTo(y.id));
            var jobIds = jobs.Where(i => i.id != 1).Select(x => x.id).OrderBy(x => x).ToArray();
            var originalJobIds = jobs.Where(i => i.id != 1).Select(x => x.id).OrderBy(x => x).ToArray();
            rand.Shuffle(jobIds);
            var newJobGroups = new List<Job_Group>();
            var newCharAssets = new List<Character_Asset>();
            var newIgc = new List<Intermediate_Growth_Curve>();
            foreach (var jobGroup in jobGroups)
            {
                newJobGroups.Add(new Job_Group(jobGroup));
            }
            foreach (var charAsset in charAssets)
            {
                newCharAssets.Add(new Character_Asset(charAsset));
            }
            foreach (var val in igc)
            {
                newIgc.Add(new Intermediate_Growth_Curve(val));
            }
            for (int i = 0; i < jobIds.Length; i++)
            {
                for (int j = 0; j < jobGroups.Count; j++)
                {
                    var propertyToUpdate = newJobGroups[j].GetType().GetProperty($"job{jobIds[i]}_accept");
                    propertyToUpdate.SetValue(newJobGroups[j], Convert.ToInt32(typeof(Job_Group).GetProperty($"job{originalJobIds[i]}_accept")?.GetValue(jobGroups[j])));
                }
                for (int j = 0; j < charAssets.Count; j++)
                {
                    if (charAssets[j].job_id != originalJobIds[i])
                        continue;
                    newCharAssets[j].job_id = jobIds[i];
                }

                for (int j = 0; j < igc.Count; j++)
                {
                    if (igc[j].job_id != originalJobIds[i])
                        continue;
                    newIgc[j].job_id = jobIds[i];
                }
                jobs[i + 1].id = jobIds[i];
            }
            return (jobs, newJobGroups, newCharAssets, newIgc);
        }

        public static void WriteToJobMasterFile(CsvProcessor csvHelper, List<Job> jobs)
        {
            csvHelper.WriteToMasterFile(jobs, "job.csv");
        }

        public static void WriteToJobGroupMasterFile(CsvProcessor csvHelper, List<Job_Group> jobGroups)
        {
            csvHelper.WriteToMasterFile(jobGroups, "job_group.csv");
        }

        public static void WriteToCharacterAssetMasterFile(CsvProcessor csvHelper, List<Character_Asset> charAssets)
        {
            csvHelper.WriteToMasterFile(charAssets, "character_asset.csv");
        }

        public static void WriteToGrowthCurveMasterFile(CsvProcessor csvHelper, List<Intermediate_Growth_Curve> igc)
        {
            csvHelper.WriteToMasterFile(igc, "intermediate_growth_curve.csv");
        }
    }
}
