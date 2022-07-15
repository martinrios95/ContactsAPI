using ContactsAPI.DTOs;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService service;

        public AuthController(AuthService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserDTO model)
        {
            var response = service.Register(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return Unauthorized(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserDTO model)
        {
            var response = service.Login(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return Unauthorized(response.ResponseMessage);
            }

            return Ok(response.Response);
        }
    }
}
