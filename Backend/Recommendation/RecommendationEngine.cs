using Database;
using ProductModule;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    public class RecommendationEngine : IRecommendation
    {
        private readonly IDBManager db;
        public RecommendationEngine()
        {
            db = new DBManager();
        }

        public RecommendationEngine(IDBManager db)
        {
            this.db = db;
        }

        public IEnumerable<ProductDto> GetRecommendedProducts(int userId, int amount)
        {
            return SelectEngine(userId).GetRecommendedProducts(userId, amount);
        }

        private IRecommendation SelectEngine(int userId)
        {            
            var ratings = db.GetAllRatings();
            ratings = (from Rating rating in ratings
                      where rating.User_id.Equals(userId)
                      select rating).ToList();
            return ratings.Count > 0 ? (IRecommendation)new PersonalizedRecommendation(db) : new RandomRecommendation(db);
        }
    }
}
