using ContactsAPI.DTOs;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Registrarse
        /// </summary>
        /// <response code="401">Si el e-mail ya está registrado en el sistema.</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(UserDTO model)
        {
            var response = service.Register(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return Unauthorized(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <returns>Un token Bearer JWT</returns>
        /// <response code="401">Si el e-mail no existe o la contraseña es incorrecta.</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(UserDTO model)
        {
            var response = service.Login(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return Unauthorized(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }
    }
}
