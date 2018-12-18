using Database;
using System.Collections.Generic;

namespace Recommendation
{
    interface IRecommendation
    {
        IEnumerable<Product> GetRecommendedProducts(int userId, int amount);
    }
}
