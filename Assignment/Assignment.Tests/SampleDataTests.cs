using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_Read_Success()
        {
            SampleData sampleData = new();
            Assert.IsNotNull(sampleData.CsvRows);
        }
    }
}
