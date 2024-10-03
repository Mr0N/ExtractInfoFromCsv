using CsvHelper;
using ExtractInfoFromCsv.Interface;
using System.Globalization;

namespace ExtractInfoFromCsv.Service
{
    public class InfoOfTags(string pathToFile) : IInfoOfTags
    {
        public IEnumerable<Tag> GetInfoOfTags()
        {
            using (var reader = new StreamReader(pathToFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Tag>().ToList();
            }
        }
        
    }
}
