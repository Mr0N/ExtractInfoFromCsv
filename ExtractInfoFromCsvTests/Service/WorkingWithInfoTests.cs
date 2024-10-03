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
    public class WorkingWithInfoTests
    {
        [TestMethod()]
        public void GetInfoFromFileProcessedTest()
        {
            var tags = new InfoOfTags(@"C:\Users\SERVER\Desktop\test\creazilla-resource.tags.csv");
            var obj = new WorkingWithInfo(tags);
            var en = obj.GetInfoFromFileProcessed()
                        .Select(a => new Data(a.nameTypeDataInfo,a.Tags.ToList()));
            foreach (var tag in en) 
            {
                ;
                foreach (var item in tag.Tags)
                {
                    ;
                }
            }
            
        }
    }
}