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
        public void CsvRows_VerifyDataFileExists()
        {
            Assert.IsTrue(File.Exists("People.csv"));
        }


        [TestMethod]
        public void CsvRows_Returns_NonNull()
        {
            Assert.IsNotNull(_sampleData!.CsvRows);
            Assert.IsInstanceOfType(_sampleData!.CsvRows, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void CsvRows_SkipsFirstLineProperly()
        {
            Assert.AreEqual<int>(50, _sampleData!.CsvRows.Count());
            Assert.IsTrue(_sampleData!.CsvRows.First().Equals("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577"));
            Assert.IsFalse(_sampleData!.CsvRows.First().Equals("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
        }

        [TestMethod]
        public void CsvRows_Returns_IEnumerableListOfStrings()
        {
            Assert.IsInstanceOfType(_sampleData!.CsvRows, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void MethodTwo_ReturnsNonNull_EnumerableOfStrings()
        {
            IEnumerable<string> list = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void MethodTwo_ReturnsOrderedListOfStates()
        {
            IEnumerable<string> stateList = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.AreEqual("AL", stateList.First());
            Assert.AreEqual("WV", stateList.Last());
            string str = "";
            string expectedResult =
                "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV,";
            foreach (var state in stateList)
            {
                str = str + state + ",";
            }
            Assert.AreEqual(expectedResult, str);
        }

        [TestMethod]
        public void MethodTwo_VerifyReturnsCorrectlySortedList()
        {
            IEnumerable<string> stateList1 = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> stateList2 = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> stateList3 = _sampleData!.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(stateList1.SequenceEqual(stateList2));
            Assert.IsTrue(stateList1.SequenceEqual(stateList3));
            Assert.IsTrue(stateList2.SequenceEqual(stateList3));
        }

        [TestMethod]
        public void MethodThree_ReturnsNonNull_String()
        {
            string str = _sampleData!.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.IsNotNull(str);
            Assert.IsInstanceOfType(str, typeof(string));
        }

        [TestMethod]
        public void MethodThree_ReturnsExpectedString()
        {
            string expectedResult = 
                "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            Assert.AreEqual(expectedResult, _sampleData!.GetAggregateSortedListOfStatesUsingCsvRows());
        }

        [TestMethod]
        public void People_IsNonNull_IEnumerableOfIPersons()
        {
            IEnumerable<IPerson> people = _sampleData!.People;
            Assert.IsNotNull(people);
            Assert.IsInstanceOfType(people, typeof(IEnumerable<IPerson>));
        }


        [TestMethod]
        public void MethodFive_GivenValidPredicate_ReturnsNonNull

        [TestMethod]
        public void MethodSix_ReturnsNonNull_String()
        {
            string str = _sampleData!.GetAggregateListOfStatesGivenPeopleCollection(_sampleData!.People);
            Assert.IsNotNull(str);
            Assert.IsInstanceOfType(str, typeof(string));
        }

        [TestMethod]
        public void MethodSix_ReturnsProperlySortedList()
        {
            SampleData sampleData = new();
            string sixResult = sampleData!.GetAggregateListOfStatesGivenPeopleCollection(sampleData!.People!);
            string threeResult = sampleData!.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(sixResult,threeResult);
        }

    }
}
