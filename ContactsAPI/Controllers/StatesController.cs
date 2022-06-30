using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public StatesController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getStates()
        {
            return Ok(dbContext.States.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getState([FromRoute] int id)
        {
            State state = dbContext.States.Find(id);

            if (state != null)
            {
                return Ok(state);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult addState(AddStateModel model)
        {
            State state = new State()
            {
                StateName = model.StateName
            };

            dbContext.States.Add(state);
            dbContext.SaveChanges();

            return Ok(state);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateState([FromRoute] int id, UpdateStateModel model)
        {
            State state = dbContext.States.Find(id);

            if (state != null)
            {
                state.StateName = model.StateName;

                dbContext.SaveChanges();

                return Ok(state);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteState([FromRoute] int id)
        {
            State state = dbContext.States.Find(id);

            if (state != null)
            {
                dbContext.States.Remove(state);

                dbContext.SaveChanges();

                return Ok(state);
            }

            return NotFound();
        }
    }
}
