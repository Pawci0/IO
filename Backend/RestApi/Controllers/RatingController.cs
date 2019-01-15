using ProductModule;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RatingApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RatingController : ApiController
    {
        private RatingService _ratingService;

        public RatingController()
        {
            _ratingService = new RatingService();
        }

        // GET: api/Rating/5
        public RatingDto Get(int id)
        {
            RatingDto ratingDto = _ratingService.GetRating(id);
            if (ratingDto != null)
                return ratingDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
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