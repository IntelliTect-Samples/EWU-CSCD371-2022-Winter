using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        [TestMethod]
        public void MethodTwo_ReturnsNonNull_EnumerableOfStrings()
        {
            IEnumerable<string> list = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void MethodThree_ReturnsNonNull_String()
        {
            string str = _sampleData!.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.IsNotNull(str);
            Assert.IsInstanceOfType(str, typeof(string));
        }

        [TestMethod]
        public void People_IsNonNull_IEnumerableOfIPersons()
        {
            IEnumerable<IPerson> people = _sampleData!.People;
            Assert.IsNotNull(people);
            Assert.IsInstanceOfType(people, typeof(IEnumerable<IPerson>));
        }

        [TestMethod]
        public void MethodSix_ReturnsNonNull_String()
        {
            string str = _sampleData!.GetAggregateListOfStatesGivenPeopleCollection(_sampleData!.People);
            Assert.IsNotNull(str);
            Assert.IsInstanceOfType(str, typeof(string));
        }

    }
}
