using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.DTO;
using static SearchEngine.SearchUtils;

namespace SearchEngine
{
    [TestClass]
    public class SearchUtilsTest
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

        [TestMethod]
        public void GetAllSearchEnginesTest()
        {
            IEnumerable<ISearch<ISearchItemDTO>> engines = SearchUtils.GetAllSearchEngines();
            Assert.AreEqual(5, engines.Count());
            foreach(ISearch<ISearchItemDTO> engine in engines)
            {
                Assert.IsNotNull(engine);
            }
        }
    }
}
