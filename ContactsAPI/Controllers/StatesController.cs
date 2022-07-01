using ContactsAPI.Data;
using ContactsAPI.Data.Interfaces;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly IRepository<State> repository;

        public StatesController(ContactsAPIDbContext dbContext)
        {
            repository = new Repository<State>(dbContext);
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            State state = repository.Read(id);

            if (state != null)
            {
                return Ok(state);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddState(StateDTO model)
        {
            State state = new State()
            {
                StateName = model.StateName
            };

            repository.Create(state);
            repository.Save();

            return Ok(state);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateState([FromRoute] int id, StateDTO model)
        {
            State state = repository.Read(id);

            if (state != null)
            {
                state.StateName = model.StateName;

                repository.Save();

                return Ok(state);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteState([FromRoute] int id)
        {
            State state = repository.Read(id);

            if (state != null)
            {
                repository.Delete(id);

                repository.Save();

                return Ok(state);
            }

            return NotFound();
        }
    }
}
