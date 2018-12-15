using Database;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    class PersonalizedRecommendation : IRecommendation
    {
        private readonly DBManager db;

        public PersonalizedRecommendation(DBManager db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetRecommendedProducts(int userId, int amount)
        {
            var ratings = GetUserRatings(userId);
            var bestRatings = ratings.OrderBy(rating => rating.Value).Take(amount);
            var bestRatedProducts = GetProductsFromRatings(bestRatings);
            return GetProductsFromBestCategories(bestRatedProducts);
        }

        private IEnumerable<Rating> GetUserRatings(int userId)
        {
            return from Rating rating in db.GetAllRatings()
                   where rating.User_id.Equals(userId)
                   select rating;
        }

        private IEnumerable<Product> GetProductsFromRatings(IEnumerable<Rating> ratings)
        {
            List<Product> ret = new List<Product>();
            foreach (var item in ratings)
            {
                ret.Add(db.GetProductById(item.Product_Id));
            }
            return ret;
        }

        private IEnumerable<Product> GetProductsFromBestCategories(IEnumerable<Product> best)
        {
            var allProducts = db.GetAllProducts();
            List<Product> ret = new List<Product>();
            foreach (var item in best)
            {
                var temp = (from Product product in allProducts
                           where product.Category_Id.Equals(item.Category_Id)
                           select product).OrderBy(product => product.Ratings.Sum(rating => rating.Value)/product.Ratings.Count).First();
                allProducts.Remove(temp);
                ret.Add(temp);
            }
            return ret;
        }
    }
}
