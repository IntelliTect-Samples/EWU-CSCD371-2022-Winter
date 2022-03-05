using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private Dictionary<string, Person> _data;
        private List<string> _csv;
        public SampleData(string filename)
        {
            var content = System.IO.File.ReadAllText(filename);
            // List of csv strings
            _csv = new List<string>(content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1));
            // Get this into an list of arrays
            var splitData = new List<string[]>(_csv.Select(f => f.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)));
            // Convert to dictionary
            _data = new Dictionary<string, Person>(splitData
                .Select(f => new KeyValuePair<string, Person>(f[0], new Person(
                    firstName: f[1],
                    lastName: f[2],
                    address: new Address(streetAddress: f[4], city: f[5], state: f[6], zip: f[7]),
                    emailAddress: f[3]
                )))
            );

        }

        // 1.
        public IEnumerable<string> CsvRows => _csv;

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => _data.Values.Select(f => f.Address.State).Distinct().OrderBy(f => f);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People => _data.Values
            .OrderBy(f => f.Address.State)
            .ThenBy(f => f.Address.City)
            .ThenBy(f => f.Address.Zip)
            .ThenBy(f => f.Address.StreetAddress);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => _data.Values
            .Where(f => filter(f.EmailAddress))
            .Select(f => (f.FirstName, f.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) =>
            String.Join(",", people.Select(f => f.Address.State).Distinct());

        public IEnumerable<IGrouping<string,Person>> GetPeopleGroupedByState() => _data.Values.GroupBy(f => f.Address.State);
        
    }
}
