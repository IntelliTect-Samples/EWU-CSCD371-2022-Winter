﻿namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        //Figure out the relative path for now manually change it
        //Relative path
        public IEnumerable<string> CsvRows => File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory+"People.csv")
            .Skip(1);

        // 2.decide whether we should make this nullable while we may not need to 
        //Since we know that the file will not make it null idkdksk double check. 
        public IOrderedEnumerable<string?> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows
                .Select(x => x.Split(',').GetValue(6)?.ToString())
                .Distinct()
                .OrderBy(x=> x);
        }

        // 3.
        //idk if we want to have states being null.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            //grab the states 
            string?[] states = CsvRows
                .Select(x => x.Split(',').GetValue(6)?.ToString())
                .Distinct()
                .OrderBy(x => x)
                .ToArray();
            
            return string.Join(",", states);
        }

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            throw new NotImplementedException();
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            throw new NotImplementedException();
        }
    }
}
