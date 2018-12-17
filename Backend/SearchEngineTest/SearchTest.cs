using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            float score = 0;
            var results = from value in myList
                          where value.ContainsFuzzy("kot", out score)
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
