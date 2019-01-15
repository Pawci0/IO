﻿using Database;
using Recommendation;
using System.Collections.Generic;
using System.Web.Http;
using ProductModule;
using System.Web.Http.Cors;

namespace RecommendationAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RecommendationController : ApiController
    {
        // GET: api/Recommendation/5/5
        [Route("api/Recommendation/{userId}/{amount}")]
        public IEnumerable<ProductDto> Get(int userId, int amount)
        {
            return new RecommendationEngine().GetRecommendedProducts(userId, amount);
        }
    }
}
