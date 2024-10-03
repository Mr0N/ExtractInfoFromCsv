using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractInfoFromCsv.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractInfoFromCsv.Interface;

namespace ExtractInfoFromCsv.Service.Tests
{
    [TestClass()]
    public class DataToFileTests
    {
        [TestMethod()]
        public void SaveDataToFileTest()
        {
            var ls = new List<Tag>();
            ls.Add(new Tag("12345", "tag"));
            ls.Add(new Tag("12345", "tag"));
            ls.Add(new Tag("12345", "tag"));
            ls.Add(new Tag("12345", "tag"));
             new List<Data>() { new Data("1234", ls) };
            var dataToFile = new DataToFile();
            dataToFile.SaveDataToFile("save", ls);
        }
    }
}