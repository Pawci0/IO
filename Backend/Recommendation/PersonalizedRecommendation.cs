using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendation
{
    class PersonalizedRecommendation : IRecommendation
    {
        private DBManager db;

        public PersonalizedRecommendation(DBManager db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetRecommendedProducts(int userId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
