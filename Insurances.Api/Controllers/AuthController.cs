using Insurances.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insurances.Api.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController()
        {
        }

        [HttpGet, HttpPost]
        [Route("api/Login/GetAuth")]
        public HttpResponseMessage GetAuth([FromBody]UserDto User)
        {
            /*
             * Always returns a fake client with grant access
             * It means that this is a fake Auth only for test purposes. 
             * This is not a real valid user and this not comes from db.
             */
            return Request.CreateResponse(HttpStatusCode.OK,
                new UserDto
                {
                    UserId = 1,
                    UserName = User.UserName,
                    Administrator = true,
                    Password = "password",
                    Email = "fakeemail@insurances.com",
                    RefreshTokenLifeTime = new Random().Next(500, 999999),
                });
        }
    }
}
