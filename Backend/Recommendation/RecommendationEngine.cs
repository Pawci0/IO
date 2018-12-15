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
        private DBManager db;
        public RecommendationEngine()
        {
            db = new DBManager();
        }

        public IEnumerable<Product> GetRecommendedProducts(int userId, int amount)
        {
            throw new NotImplementedException();
        }

        private IRecommendation SelectEngine()
        {            
            var ratings = db.GetAllRatings();
            if(ratings.Count == 0)
            {
                return new RandomRecommendation(db);
            }
            else
            {
                // personalized recommendation engine
            }
        }
    }
}
