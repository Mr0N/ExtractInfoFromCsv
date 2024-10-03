namespace ExtractInfoFromCsv.Interface
{
    public record Tag(string uniqueId,string tag);
    public interface IInfoOfTags
    {
        public IEnumerable<Tag> GetInfoOfTags();
    }
}
