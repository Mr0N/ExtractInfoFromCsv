namespace ExtractInfoFromCsv.Interface
{
    public record Data(string nameTypeDataInfo,IEnumerable<Tag> Tags);
    public interface IWorkingWithInfo
    {
        public IEnumerable<Data> GetInfoFromFileProcessed();
    }
}
