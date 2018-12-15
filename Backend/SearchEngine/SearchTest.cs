using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Model;
using static SearchEngine.SearchUtils;

namespace SearchEngine
{
    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void FuzzySearchTest()
        {
            var myList = new List<string>{"ala ma kota", "element"};

            var results = from value in myList
                where ContainsFuzzy(value, "kot")
                select value;

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void LevenshteinTest()
        { 
            Assert.AreEqual(6, LevenshteinDistance("element", "kot"));
        }

        [TestMethod]
        public void SearchClassTest()
        {
            UserSearch engine = new UserSearch();
            List<User> list = new List<User>
            {
                new User("Jan"), new User("Janusz"), new User("Abelard")
            };
            engine.Users = list;
            var result = engine.Search("Ja", ESortType.Ascending, 1);

            Assert.AreEqual(result.ToList().First(), "Jan");
            Assert.AreEqual(result.ToList().Count(), 1);
        }
    }
}
