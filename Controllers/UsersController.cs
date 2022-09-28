using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerIntegration_CoreWebApi.Model;
using SwaggerIntegration_CoreWebApi.Repository;
using System.Collections.Generic;
//using System.Web.Http;

namespace SwaggerIntegration_CoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
