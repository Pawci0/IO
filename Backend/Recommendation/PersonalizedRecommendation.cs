using Database;
using ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    class PersonalizedRecommendation : IRecommendation
    {
        private readonly IDBManager db;

        public PersonalizedRecommendation(IDBManager db)
        {
            this.db = db;
        }

        public IEnumerable<ProductDto> GetRecommendedProducts(int userId, int amount)
        {
            var ratings = GetUserRatings(userId);
            var bestRatings = ratings.OrderByDescending(rating => rating.Value).Take(amount);
            var bestRatedProducts = GetProductsFromRatings(bestRatings);
            return GetProductsFromBestCategories(bestRatedProducts, amount).Select(x => new ProductDto
            {
                productId = x.Product_Id,
                name = x.Name,
                categoryId = x.Category_Id.HasValue ? x.Category_Id.Value : -1,
                userId = x.User_Id,
                description = x.Description
            });
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

        private IEnumerable<Product> GetProductsFromBestCategories(IEnumerable<Product> best, int target)
        {
            var allProducts = db.GetAllProducts();
            List<Product> ret = new List<Product>();
            foreach (var item in best)
            {
                var temp = (from Product product in allProducts
                           where product.Category_Id.Equals(item.Category_Id)
                           select product).OrderByDescending(product => product.Ratings.Sum(rating => rating.Value)/(product.Ratings.Count == 0 ? 1 : product.Ratings.Count)).FirstOrDefault();
                if (!temp.Equals(null))
                {
                    allProducts.Remove(temp);
                    ret.Add(temp);
                }
            }
            if(ret.Count < target)
            {
                var rng = new Random();
                do
                {
                    if (allProducts.Count > 0)
                    {
                        int index = rng.Next(allProducts.Count);
                        ret.Add(allProducts.ElementAt(index));
                        allProducts.RemoveAt(index);
                    }
                    else
                    {
                        break;
                    }
                } while (ret.Count < target);
            }
            return ret;
        }
    }
}
