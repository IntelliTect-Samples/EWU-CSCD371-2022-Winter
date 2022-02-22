using System;
using System.Collections.Generic;
using System.IO;
using System.Ling;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private List<string> _CsvRows;

        public SampleData()
        {
            _CsvRows = File.ReadAllLines("People.csv").Skip(1).ToList();
            if (_CsvRows is null)
            {
                throw new ArgumentNullException("Error from reading lines, is null."); ;
            }
        }
        // 1.
        public IEnumerable<string> CsvRows
        {
            get { return _CsvRows; }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows(){
            List<string> states = new List<string>();
            states = CsvRows.Select(item => item.Split(",")).OrderBy(item => item[6]).Select(item => item[6]).Distinct().ToList();
            return states;
           }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows(){
            string states = "";
            IEnumerable<string> statesList = GetUniqueSortedListOfStatesGivenCsvRows();
            states = statesList.Aggregate((state1, state2) => state1 + ", " + state2);
            return states;
            }

        // 4.
        public IEnumerable<IPerson> People
        {
            get{
                IEnumerable<Person> people = CsvRows.Select(x => x.Split(",")).Select(x => new Person(x[1], x[2], new Address(x[4], x[5], x[6], x[7]), x[3])).ToList();
                return People;
                }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) =>
            People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people){
           IEnumerable<IPerson> people) => 
            people.Select(person => person.Address.State).Distinct().Aggregate((state1, state2) => state1 + ", " + state2);
        }
    }
}
