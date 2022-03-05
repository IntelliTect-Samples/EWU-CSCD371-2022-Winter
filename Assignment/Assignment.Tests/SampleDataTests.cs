using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SampleDataTests
    {
        private SampleData Sut = new SampleData("People.csv");

        [TestMethod]
        public void CreateTest()
        {
            Assert.AreEqual(50, Sut.CsvRows.Count());
        }

        [TestMethod]
        public void Csv()
        {
            Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", Sut.CsvRows.First());
        }

        [TestMethod]
        public void UniqueStates()
        {
            Assert.AreEqual(27, Sut.GetUniqueSortedListOfStatesGivenCsvRows().Count());
            Assert.AreEqual("AL", Sut.GetUniqueSortedListOfStatesGivenCsvRows().First());
            Assert.AreEqual("WV", Sut.GetUniqueSortedListOfStatesGivenCsvRows().Last());
        }

        [TestMethod]
        public void People()
        {
            Assert.AreEqual(50, Sut.People.Count());
            Assert.AreEqual("Arthur", Sut.People.First().FirstName);
            Assert.AreEqual("Amelia", Sut.People.Last().FirstName);
            // Make sure some tricky ones in the middle are in the right spots.            
            var indexOfFayette = Sut.People.Select(f => f.FirstName).ToList().IndexOf("Fayette");
            var indexOfJoly = Sut.People.Select(f => f.FirstName).ToList().IndexOf("Joly");
            Assert.AreEqual(indexOfFayette, indexOfJoly - 1);
        }

        [TestMethod]
        public void StateCsvList()
        {
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", Sut.GetAggregateListOfStatesGivenPeopleCollection(Sut.People));
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", Sut.GetAggregateSortedListOfStatesUsingCsvRows());
        }

        [TestMethod]
        public void Filter()
        {
            Assert.AreEqual(5, Sut.FilterByEmailAddress(f => f.Contains(".gov")).Count());
        }

        [TestMethod]
        public void GroupedByState()
        {
            Assert.AreEqual(27, Sut.GetPeopleGroupedByState().Count());
            Assert.AreEqual(3, Sut.GetPeopleGroupedByState().First(f=>f.Key == "WA").Count());

        }
    }

}
