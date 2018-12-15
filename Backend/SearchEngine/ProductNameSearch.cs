﻿using Database;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    internal class ProductNameSearch : ProductSearch
    {
        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            IEnumerable<Product> results = from Product product in dataContext.GetAllProducts()
                                            where product.Name.ContainsFuzzy(phrase)
                                            select product;

            if(searchResult is null)
            {
                searchResult = OrderBy(results, sortType).ToList();
            }
            else
            {
                searchResult.AddRange(OrderBy(results, sortType));
            }
        }
    }
}
