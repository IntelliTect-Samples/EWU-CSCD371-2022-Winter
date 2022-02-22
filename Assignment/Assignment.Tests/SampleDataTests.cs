using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        public SampleData? _sampleData;

        [TestInitialize]
        public void Initialize()
        {
            _sampleData = new();
        }


        [TestMethod]
        public void CsvRows_Returns_NonNull()
        {
            Assert.IsNotNull(_sampleData!.CsvRows);
            Assert.IsInstanceOfType(_sampleData!.CsvRows, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void CsvRows_Returns_IEnumerableListOfStrings()
        {
            Assert.IsInstanceOfType(_sampleData!.CsvRows, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void CsvRows_SkipsFirstLine()
        {
            Assert.AreEqual<int>(50, _sampleData!.CsvRows.Count());
        }
    }
}
