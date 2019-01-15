using ProductModule;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using RestApi.Extensions;
using System.Web.Http;

namespace RatingApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Rating")]
    public class RatingController : ApiController
    {
        private RatingService _ratingService;

        public RatingController()
        {
            _ratingService = new RatingService();
        }

        // GET: api/Rating/5
        public int Get(int id)
        {
            var allRatings = _ratingService.GetAllRatings(id);
            var ratings = allRatings.Where(r => r.Product_Id == id);
            if (ratings.Count() != 0)
            {
                return ratings.Sum(r => r.Value) / ratings.Count();
            }
            else
            {
                return -1;
            }
        }

        // POST: api/Rating
        public void Post([FromBody]RatingDto value)
        {
            _ratingService.CreateRating(value);
        }

        // PUT: api/Rating/5
        public void Put(int id, [FromBody]RatingDto value)
        {
            _ratingService.UpdateRating(value);
        }

        // DELETE: api/Rating/5
        public void Delete(int id)
        {
            _ratingService.DeleteRating(id);
        }
    }
}