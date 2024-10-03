using CsvHelper;
using ExtractInfoFromCsv.Interface;
using System.Diagnostics;
using System.Globalization;

namespace ExtractInfoFromCsv.Service
{
    public class DataToFile : ISaveDataToFile
    {
        public void SaveDataToFile(string filename, IEnumerable<Tag> en)
        {
            string saveDirectory = Path.Combine(_exePathToDirectory, _dirName);
            Directory.CreateDirectory(saveDirectory);
            using (var writer = new StreamWriter(Path.Combine(saveDirectory, filename) + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Tag>();
                csv.NextRecord();
                csv.WriteRecords(en);
            }

        }
        string _dirName;
        string _exePathToDirectory;
        public DataToFile()
        {
            _dirName = Guid.NewGuid().ToString();
            _exePathToDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }
    }
}
