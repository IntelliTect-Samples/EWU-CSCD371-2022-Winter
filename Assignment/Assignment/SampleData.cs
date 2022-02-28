using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1).ToList();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows.Select(l => l.Split(',')[6]).Where(x => x != null).Distinct()!.OrderBy(x => x);      

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => String.Join(',', GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(line =>
        {
            string[] row = line.Split(',');
            Address temp = new Address(row[4], row[5], row[6], row[7]);
            return new Person(row[1], row[2], temp, row[3]);
        });

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(l => filter(l.EmailAddress)).Select(l => (l.FirstName, l.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(l => l.Address.State).Distinct().Aggregate((p1, p2) => p1 + "," + p2);

    }
}
