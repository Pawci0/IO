using System.Collections.Generic;
using System.Linq;
using Database;
using ProductModule;

namespace Recommendation
{
    class RandomRecommendation : IRecommendation
    {
        private readonly IDBManager db;
        public RandomRecommendation(IDBManager db)
        {
            this.db = db;
        }

        public IEnumerable<ProductDto> GetRecommendedProducts(int userId, int amount)
        {
            return db.GetAllProducts().Shuffle().Take(amount).Select(x => new ProductDto
            {
                productId = x.Product_Id,
                name = x.Name,
                categoryId = x.Category_Id.HasValue ? x.Category_Id.Value : -1,
                userId = x.User_Id,
                description = x.Description                
            });
        }
    }
}
