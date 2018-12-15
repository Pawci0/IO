using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Recommendation
{
    class RandomRecommendation : IRecommendation
    {
        private DBManager db;
        public RandomRecommendation(DBManager db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetRecommendedProducts(int userId, int amount)
        {
            return db.GetAllProducts().Shuffle().Take(amount);
        }
    }
}
