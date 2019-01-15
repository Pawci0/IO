using System.Net;
using System.Web.Http;
using ProductModule;

namespace TagApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TagController : ApiController
    {
        private TagService _tagService;

        public TagController()
        {
            _tagService = new TagService();
        }

        // GET: api/Tag/5
        public TagDto Get(int id)
        {
            TagDto tagDto = _tagService.GetTag(id);
            if (tagDto != null)
                return tagDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST: api/Tag
        public void Post([FromBody]TagDto value)
        {
            _tagService.CreateTag(value);
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]TagDto value)
        {
            _tagService.UpdateTag(value);
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
            _tagService.DeleteTag(id);
        }
    }
}