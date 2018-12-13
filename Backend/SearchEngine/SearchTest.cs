using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SearchEngine.Search;

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
    }
}
