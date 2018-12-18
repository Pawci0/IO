using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Tests
{
    [TestClass()]
    public class ProductNameSearchTests
    {
        private ProductNameSearch _sut;

        [TestMethod()]
        public void SearchTest()
        {
            _sut = new ProductNameSearch();
            _sut.Search("kot", Enums.SortTypeEnum.ignore , null);
        }
    }
}