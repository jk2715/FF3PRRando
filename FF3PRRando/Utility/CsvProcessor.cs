using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using FF3PR.Data.Entities;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FF3PRRando.Utility
{
    public class CsvProcessor
    {
        private readonly string _masterDirectory;
        private readonly string _outputDirectory;
        private readonly string _keysDirectory;

        public CsvProcessor(string magiciteExportDirectory, string outputDirectory, int seed)
        {
            _masterDirectory = @$"{magiciteExportDirectory}\master\Assets\GameAssets\Serial\Data\Master";
            _outputDirectory = $@"{outputDirectory}\FF3PRR_{seed}\master\Assets\GameAssets\Serial\Data\Master";
            _keysDirectory = $@"{outputDirectory}\FF3PRR_{seed}\master\keys";
        }

        public List<T> GetMasterFileContents<T>(string csvName)
        {
            var records = new List<T>();
            using (var reader = new StreamReader(@$"{_masterDirectory}\{csvName}"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var values = csv.GetRecord<T>();
                    records.Add(values);
                }
            }
            return records;
        }

        public void WriteToMasterFile<T>(List<T> records, string csvName)
        {
            if (!Directory.Exists(_outputDirectory))
            {
                Directory.CreateDirectory(_outputDirectory);
            }
            using (var writer = new StreamWriter(@$"{_outputDirectory}\{csvName}"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
            var exportFile = new Export();
            if (!Directory.Exists(_keysDirectory))
            {
                Directory.CreateDirectory(_keysDirectory);
            }
            var exportPath = $@"{_keysDirectory}\Export.json";
            if (File.Exists(exportPath))
            {
                exportFile = JsonConvert.DeserializeObject<Export>(File.ReadAllText(exportPath));
            }
            exportFile?.Keys.Add(csvName.Split(".csv")[0]);
            exportFile?.Values.Add($@"Assets/GameAssets/Serial/Data/Master/{csvName.Split(".csv")[0]}");
            File.WriteAllText(exportPath, JsonConvert.SerializeObject(exportFile));
        }
    }
}
