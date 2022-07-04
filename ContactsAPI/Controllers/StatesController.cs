using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public StatesController(ContactsAPIDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            return Ok(unitOfWork.StatesRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            State state = unitOfWork.StatesRepository.Read(id);

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

            unitOfWork.StatesRepository.Create(state);
            unitOfWork.Save();

            return Ok(state);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateState([FromRoute] int id, StateDTO model)
        {
            State state = unitOfWork.StatesRepository.Read(id);

            if (state != null)
            {
                state.StateName = model.StateName;

                unitOfWork.Save();

                return Ok(state);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteState([FromRoute] int id)
        {
            State state = unitOfWork.StatesRepository.Read(id);

            if (state != null)
            {
                unitOfWork.StatesRepository.Delete(id);

                unitOfWork.Save();

                return Ok(state);
            }

            return NotFound();
        }
    }
}
