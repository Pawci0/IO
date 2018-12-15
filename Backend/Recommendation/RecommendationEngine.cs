using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendation
{
    public class RecommendationEngine : IRecommendation
    {
        private readonly DBManager db;
        public RecommendationEngine()
        {
            db = new DBManager();
        }

        public IEnumerable<Product> GetRecommendedProducts(int userId, int amount)
        {
            return SelectEngine().GetRecommendedProducts(userId, amount);
        }

        private IRecommendation SelectEngine()
        {            
            var ratings = db.GetAllRatings();
            return ratings.Count > 0 ? (IRecommendation)new PersonalizedRecommendation(db) : new RandomRecommendation(db);
        }
    }
}
