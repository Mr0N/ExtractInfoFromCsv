using ExtractInfoFromCsv.Interface;
using System.Text.RegularExpressions;

namespace ExtractInfoFromCsv.Service
{
    public class WorkingWithInfo(IInfoOfTags infoOfTags) : IWorkingWithInfo
    {
        public IEnumerable<Data> GetInfoFromFileProcessed()
        {
            List<Tag> tags = infoOfTags.GetInfoOfTags() as List<Tag>;

            yield return new Data("latinChars(1)", FilterAction(tags, a =>
            {
               string lowerCase =  a?.ToLower();
                return Regex.IsMatch(lowerCase, "[^a-zàáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿāăąćĉċčďđēĕėęěĝğġģĥħĩīĭįıĵķĺļńņňōŏőŕŗřśŝşšţťŧũūŭůűųŵŷźżž]");
            }));

            yield return new Data("oneChars(2)", Filter(tags, "^(.|\\s){1}$"));
            yield return new Data("more than 2 characters (3)", Filter(tags, "^(.|\\s){2}$"));
            yield return new Data("more than 3 characters (4)", Filter(tags, "^(.|\\s){3}$"));
            yield return new Data("more than 4 characters (5)", Filter(tags, "^(.|\\s){4}$"));
            yield return new Data("more than 5 characters (6)", Filter(tags, "^(.|\\s){5}$"));
            yield return new Data("more than 6 characters (7)", Filter(tags, "^(.|\\s){6}$"));
            yield return new Data("Plus(8)", Filter(tags, "\\+"));
            yield return new Data("Number(9)", Filter(tags, "^[0-9]+$"));
            yield return new Data("StartWidth(10)", Filter(tags, "^(@|,|\\.|&|\\*|#|@|a |free |the )(.|\\s)+$"));
            yield return new Data("ContainsWord(11)", Filter(tags, "(files|public domain|www.|http|&quot)"));
            yield return new Data("ContainsCharacters(12)", Filter(tags, "[ÄÃ©¾½Å¾¡Ø§ÙØ¬ØØ§Ø¦Ø±ÙŠØ©]"));
            yield return new Data("Length(13)", FilterAction(tags, a =>
            {
                if (a.Contains(" ")) return false;
                return a.Length > 6;
            }));

        }
        IEnumerable<Tag> Filter(List<Tag> tags, string regex)
        {
            var checker = new Regex(regex);
            foreach (Tag tag in tags)
            {
                if (checker.IsMatch(tag.tag))
                    yield return tag;
            }
        }
        IEnumerable<Tag> FilterAction(List<Tag> tags, Func<string,bool> action)
        {
 
            foreach (Tag tag in tags)
            {
                if (action(tag.tag))
                    yield return tag;
            }
        }
    }
}
