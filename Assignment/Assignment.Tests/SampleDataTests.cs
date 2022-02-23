﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_LazyInitialize_Success()
        {
            SampleData sampleData = new();
            Assert.IsNotNull(sampleData.CsvRows);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_Success()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsNotNull(q);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_IsDistinct()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(q.SequenceEqual(q.Distinct()));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_IsSorted()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(q.SequenceEqual(q.OrderBy(item => item)));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_HardcodedSpokaneList()
        {
            List<string> list = new List<string>();
            list.Add("id,first,last,email,address,Spokane,WA");
            list.Add("id,first,last,email,address,Spokane,WA");
            list.Add("id,first,last,email,address,Spokane,WA");
            var mockIEnumerble = new Mock<SampleData>();
            /**
             * TODO: ask for clarification and finish
             */
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCorrectly()
        {
            SampleData s1 = new();
            SampleData s2 = new();

            Assert.AreEqual<string>(s1.GetAggregateSortedListOfStatesUsingCsvRows(), s2.GetAggregateSortedListOfStatesUsingCsvRows());
        }

        [TestMethod]
        public void People_SetCorrectly()
        {
            /**
            * Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
            * 0  1         2        3     4             5    6     7
            */
            SampleData s1 = new();
            var expected = s1.CsvRows.Select(item => item.Split(',')).Select(item => item[1] + "," + item[2] + "," + item[3] + "," + item[4] + "," + item[5] + "," + item[6] + "," + item[7]).OrderBy(item => item);
            var actual = s1.People.Select(item => item.FirstName + "," + item.LastName + "," + item.EmailAddress + "," + item.Address.StreetAddress + "," + item.Address.City + "," + item.Address.State + "," + item.Address.Zip).OrderBy(item => item);

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsCorrectly()
        {
            SampleData s1 = new();
            Predicate<string> pre = (word => word == "cstennine2@wired.com");
            IEnumerable<(string, string)> q = s1.FilterByEmailAddress(pre);
            Assert.IsTrue(q.Contains(("Chadd", "Stennine")));
        }
    }
}
