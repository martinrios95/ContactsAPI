using ContactsAPI.DTOs;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly StateService service;

        public StatesController(StateService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            return Ok(service.GetAllStates());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            var response = service.GetState(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpPost]
        public IActionResult AddState(StateDTO model)
        {
            return Ok(service.AddState(model).Response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateState([FromRoute] int id, StateDTO model)
        {
            var response = service.UpdateState(id, model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteState([FromRoute] int id)
        {
            var response = service.DeleteState(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }
    }
}
