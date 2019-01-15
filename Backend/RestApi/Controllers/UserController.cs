﻿using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using RestApi.Extensions;
using User;

namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private UserService _userService;
        
        public UserController()
        {
            _userService = new UserService();
        }
        
        // GET: api/User/5
        public UserDto Get(int id)
        {
            UserDto userDto = _userService.GetUser(id);
            if (userDto != null) 
                return userDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("GetCurrentId")]
        // GET: api/User/
        public int GetCurrentUserId()
        {
            return SessionContext.TryGetUserId();
        }

        [AllowAnonymous]
        // POST: api/User
        public void Post([FromBody]UserDto value)
        {
            _userService.CreateUser(value);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]UserDto value)
        {
            value.Id = id;
            _userService.UpdateUser(value);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            _userService.DisableUser(id);
        }
    }
}
