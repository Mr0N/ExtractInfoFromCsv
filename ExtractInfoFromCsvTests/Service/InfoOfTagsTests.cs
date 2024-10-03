using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractInfoFromCsv.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractInfoFromCsv.Service.Tests
{
    [TestClass()]
    public class InfoOfTagsTests
    {
        [TestMethod()]
        public void GetInfoOfTagsTest()
        {
            var tags = new InfoOfTags(@"C:\Users\SERVER\Desktop\test\creazilla-resource.tags.csv");
            var query = tags.GetInfoOfTags();
        }
    }
}