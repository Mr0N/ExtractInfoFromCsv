namespace ExtractInfoFromCsv.Interface
{
    public interface ISaveDataToFile
    {
        public void SaveDataToFile(string filename,IEnumerable<Tag> en);
    }
}
