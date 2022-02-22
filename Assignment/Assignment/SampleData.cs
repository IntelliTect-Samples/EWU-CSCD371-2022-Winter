using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                return File.ReadAllLines("People.csv").Skip(1);
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> stateList = 
                (
                    from line in CsvRows
                    let state = line.Split(',')
                    orderby state[6]
                    select state[6]
                )
                .Distinct().ToList();

            return stateList;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            return string.Join(", ", states);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<IPerson> people =
                    from line in CsvRows
                    let peopleInfo = line.Split(",")
                    orderby peopleInfo[5], 
                            peopleInfo[6], 
                            peopleInfo[7]
                    select new Person
                    (
                        peopleInfo[1],
                        peopleInfo[2], 
                        new Address
                        (
                            peopleInfo[5],
                            peopleInfo[4],
                            peopleInfo[6],
                            peopleInfo[7]
                        ),
                        peopleInfo[3]
                    );

                return people.ToList();
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            IEnumerable<(string FirstName, string LastName)> filteredList = 
                People.Where(item=>filter(item.EmailAddress))
                .Select(item=> (item.FirstName, item.LastName));

            return filteredList;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            return People.Select(item => item.Address.State)
                   .Distinct().Aggregate((current, next) => current + "," + next);
        }
    }
}
