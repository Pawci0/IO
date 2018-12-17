using Database;
using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class ProductNameSearch : ProductSearch
    {
        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            float score = 0;
            IEnumerable<ProductDTO> results = from Product product in dataContext.GetAllProducts()
                                            where product.Name.ContainsFuzzy(phrase, out score)
                                            select new ProductDTO(product, score);

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
