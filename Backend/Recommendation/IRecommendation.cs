using ProductModule;
using System.Collections.Generic;

namespace Recommendation
{
    interface IRecommendation
    {
        IEnumerable<ProductDto> GetRecommendedProducts(int userId, int amount);
    }
}
