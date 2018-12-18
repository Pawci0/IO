using Database;
using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine
{
    public class RatingSearch : ProductSearch
    {

        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            float score = 0;
            IEnumerable<ProductDTO> results = from Product product in dataContext.GetAllProducts()
                                           where AverageRatings(product.Ratings).ToString().ContainsFuzzy(phrase, out score)
                                           select new ProductDTO(product, AverageRatings(product.Ratings), score);

            if(filters != null && filters.Any())
            {
                results = ApplyFilters(results, filters);
            }

            if (searchResult is null)
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
