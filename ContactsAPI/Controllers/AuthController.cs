using ContactsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [Route("Register")]
        public IActionResult Register([FromRoute] UserDTO dto)
        {
            return Ok();
        }

        [Route("Login")]
        public IActionResult Login([FromRoute] UserDTO dto)
        {
            return Ok();
        }
    }
}
