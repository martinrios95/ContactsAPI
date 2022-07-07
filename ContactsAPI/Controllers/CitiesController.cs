using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public CitiesController(ContactsAPIDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(unitOfWork.CitiesRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            City city = unitOfWork.CitiesRepository.Read(id);
            if (city != null)
            {
                return Ok(city);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        public IActionResult GetCityDetails([FromRoute] int id)
        {
            City city = unitOfWork.CitiesRepository.Read(id);

            if (city == null)
            {
                return NotFound();
            }

            State state = unitOfWork.StatesRepository.Read(city.StateID);

            CityDetailsDTO dto = new CityDetailsDTO()
            {
                CityName = city.CityName,
                StateName = state.StateName
            };

            return Ok(dto);
        }

        [HttpGet]
        [Route("Kaboom")]
        public IActionResult Kaboom()
        {
            throw new Exception("KABOOM");

            // It highlights as "never accesible" code, but...
            return Content("Never gets there");
        }

        [HttpPost]
        public IActionResult AddCity(CityDTO model)
        {
            State state = unitOfWork.StatesRepository.Read(model.StateID);

            if (state == null)
            {
                return NotFound(Content("State not found"));
            }

            City city = new City()
            {
                CityName = model.CityName,
                StateID = model.StateID
            };

            unitOfWork.CitiesRepository.Create(city);
            unitOfWork.Save();

            return Ok(city);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCity([FromRoute] int id, CityDTO model)
        {
            State state = unitOfWork.StatesRepository.Read(model.StateID);

            if (state == null)
            {
                return NotFound(Content("State not found"));
            }

            City city = unitOfWork.CitiesRepository.Read(id);

            if (city != null)
            {
                city.CityName = model.CityName;
                city.StateID = model.StateID;

                unitOfWork.CitiesRepository.Update(city);

                return Ok(city);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            City city = unitOfWork.CitiesRepository.Read(id);

            if (city != null)
            {

                unitOfWork.CitiesRepository.Delete(id);

                unitOfWork.Save();

                return Ok(city);
            }

            return NotFound();
        }
    }
}
