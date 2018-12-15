using Database;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    internal class RatingSearch : ProductSearch
    {

        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            IEnumerable<Product> results = from Product product in dataContext.GetAllProducts()
                                           where AverageRatings(product.Ratings).ToString().ContainsFuzzy(phrase)
                                           select product;

            if (searchResult is null)
            {
                searchResult = OrderBy(results, sortType).ToList();
            }
            else
            {
                searchResult.AddRange(OrderBy(results, sortType));
            }
        }

        private double AverageRatings(ICollection < Database.Rating > ratings)
        {
            double avg = 0;
            foreach (var value in ratings)
            {
                avg += value.Value;
            }

            return Math.Round(avg/ratings.Count, 2);
        }

    }
}
