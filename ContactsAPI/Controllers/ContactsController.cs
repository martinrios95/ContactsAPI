using ContactsAPI.DTOs;
using ContactsAPI.Filters;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactService service;

        public ContactsController(ContactService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(service.GetAllContacts().Response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            var response = service.GetContact(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpGet]
        [Route("Details/{id:guid}")]
        public IActionResult GetContactDetails([FromRoute] Guid id)
        {
            var response = service.GetContactDetails(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpGet]
        [Route("City/{id:int}")]
        public IActionResult GetContactsFromCity([FromRoute] int id)
        {
            var response = service.GetContactsFromCity(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpPost]
        [PhoneValidationFilter]
        public IActionResult AddContact(ContactDTO model)
        {
            var response = service.AddContact(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [PhoneValidationFilter]
        public IActionResult UpdateContact([FromRoute] Guid id, ContactDTO model)
        {
            var response = service.UpdateContact(id, model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact([FromRoute] Guid id)
        {
            var response = service.DeleteContact(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound(response.ResponseMessage);
            }

            return Ok(response.Response);
        }
    }
}
