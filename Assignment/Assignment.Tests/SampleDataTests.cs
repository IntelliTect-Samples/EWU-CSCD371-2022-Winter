using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
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
        public void CsvRows_Set_Success()
        {
            SampleData data = new();

            string firstRow = data.CsvRows.First();
            string lastRow = data.CsvRows.Last();
            string expectedFirstRow = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
            string expectedLastRow = "50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930";

            Assert.AreEqual(expectedFirstRow, firstRow);
            Assert.AreEqual(expectedLastRow, lastRow);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedList_Success()
        {
            SampleData data = new();

            string[] statesArray = new string[] { "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV" };
            List<string> expectedStatesList = statesArray.ToList();

            IEnumerable<string> statesList = data.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.AreEqual(expectedStatesList.First(), statesList.First());
            Assert.AreEqual(expectedStatesList.Last(), statesList.Last());
            Assert.AreEqual(expectedStatesList.Count(), statesList.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_LinqList_Success()
        {
            SampleData data = new();

            IEnumerable<string> statesList = data.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> expectedStatesList = statesList.OrderBy(x => x);

            Assert.AreEqual(expectedStatesList.First(), statesList.First());
            Assert.AreEqual(expectedStatesList.Last(), statesList.Last());
            Assert.AreEqual(expectedStatesList.Count(), statesList.Count());
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_HardcodedString_Success()
        {
            SampleData data = new();

            string states = data.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedStates = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            Assert.AreEqual(expectedStates, states);
        }

        [TestMethod]
        public void People_ListOfPeople_Success()
        {
            SampleData data = new();

            Person firstPerson = (Person)data.People.First();
            int numOfPeople = data.People.Count();

            Address address = new Address("7884 Corry Way", "Helena", "MT", "70577");
            Person expectedFirstPerson = new Person("Priscilla", "Jenyns", address, "pjenyns0@state.gov");
            int expectedNumberOfPeople = 50;

            Assert.AreEqual(expectedFirstPerson.FirstName, firstPerson.FirstName);
            Assert.AreEqual(expectedFirstPerson.LastName, firstPerson.LastName);
            Assert.AreEqual(expectedFirstPerson.EmailAddress, firstPerson.EmailAddress);
            Assert.AreEqual(expectedFirstPerson.Address.StreetAddress, firstPerson.Address.StreetAddress);
            Assert.AreEqual(expectedFirstPerson.Address.City, firstPerson.Address.City);
            Assert.AreEqual(expectedFirstPerson.Address.State, firstPerson.Address.State);
            Assert.AreEqual(expectedFirstPerson.Address.Zip, firstPerson.Address.Zip);
            Assert.AreEqual(expectedNumberOfPeople, numOfPeople);   
        }

        [TestMethod]
        public void FilterByEmailAddress_Filter_Success()
        {
            SampleData data = new();

            Predicate<string> filter = s => s.Contains(".com");
            IEnumerable<(string firstName, string lastName)> filteredList = data.FilterByEmailAddress(filter);

            IEnumerable<(string firstName, string lastName)> expectedFilteredList = data.People.Where(p => p.EmailAddress.Contains(".com")).Select(l => (l.FirstName, l.LastName));

            Assert.AreEqual(expectedFilteredList.First().firstName, filteredList.First().firstName);
            Assert.AreEqual(expectedFilteredList.First().lastName, filteredList.First().lastName);
            Assert.AreEqual(expectedFilteredList.Last().firstName, filteredList.Last().firstName);
            Assert.AreEqual(expectedFilteredList.Last().lastName, filteredList.Last().lastName);
            Assert.AreEqual(expectedFilteredList.Count(), filteredList.Count());

        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_Success()
        {
            SampleData data = new();

            string states = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);
            string expectedStates = String.Join(",",data.People.Select(l => l.Address.State).Distinct());

            Assert.AreEqual(expectedStates, states);    
        }
    }
}
