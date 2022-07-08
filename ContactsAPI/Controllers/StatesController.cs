using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly StateService service;

        public StatesController(ContactsAPIDbContext context)
        {
            // TODO: Replace with a DI-container service
            service = new StateService(new UnitOfWork(context));
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
            State state = service.GetState(id);

            if (state != null)
            {
                return Ok(state);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddState(StateDTO model)
        {
            return Ok(service.AddState(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateState([FromRoute] int id, StateDTO model)
        {
            State state = service.UpdateState(id, model);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteState([FromRoute] int id)
        {
            State state = service.DeleteState(id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }
    }
}
