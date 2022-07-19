using ContactsAPI.DTOs;
using ContactsAPI.Filters;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactService service;

        public ContactsController(ContactService service)
        {
            this.service = service;
        }
        /// <summary>
        /// Obtener todos los contactos
        /// </summary>
        /// <returns>Todos los contactos</returns>
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(service.GetAllContacts().Response);
        }

        /// <summary>
        /// Obtener un contacto mediante ID
        /// </summary>
        /// <param name="id">El Guid del contacto</param>
        /// <returns>Un contacto</returns>
        /// <response code="200">Si el contacto existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si el contacto no existe</response>
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            var response = service.GetContact(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Obtener los detalles de un contacto mediante ID
        /// </summary>
        /// <param name="id">El Guid del contacto</param>
        /// <returns>Detalles del contacto</returns>
        /// <response code="200">Si el contacto existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si el contacto no existe</response>
        [HttpGet]
        [Route("Details/{id:guid}")]
        public IActionResult GetContactDetails([FromRoute] Guid id)
        {
            var response = service.GetContactDetails(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Obtener un contacto en base al ID de ciudad
        /// </summary>
        /// <param name="id">El ID de la ciudad</param>
        /// <returns>Una lista de contactos</returns>
        /// <response code="200">Si el contacto existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si el contacto no existe</response>
        [HttpGet]
        [Route("City/{id:int}")]
        public IActionResult GetContactsFromCity([FromRoute] int id)
        {
            var response = service.GetContactsFromCity(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Agregar un contacto
        /// </summary>
        /// <param name="model">Los datos del contacto</param>
        /// <returns>El contacto añadido</returns>
        /// <response code="401">Si el usuario no inició sesión</response>
        [HttpPost]
        [PhoneValidationFilter]
        public IActionResult AddContact(ContactDTO model)
        {
            var response = service.AddContact(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Actualizar los datos de un contacto
        /// </summary>
        /// <param name="id">El Guid del contacto a actualizar</param>
        /// <param name="model">Los datos a actualizar en el contacto</param>
        /// <returns>El contacto actualizado</returns>
        /// <response code="200">Si el contacto existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si el contacto no existe</response>
        [HttpPut]
        [Route("{id:guid}")]
        [PhoneValidationFilter]
        public IActionResult UpdateContact([FromRoute] Guid id, ContactDTO model)
        {
            var response = service.UpdateContact(id, model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }

        /// <summary>
        /// Borrar un contacto
        /// </summary>
        /// <param name="id">El Guid del contacto</param>
        /// <returns>El contacto eliminado</returns>
        /// <response code="200">Si el contacto existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si el contacto no existe</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact([FromRoute] Guid id)
        {
            var response = service.DeleteContact(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(new
                {
                    message = response.ResponseMessage
                });
            }

            return Ok(response.Response);
        }
    }
}
