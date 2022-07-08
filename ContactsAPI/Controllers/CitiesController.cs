using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly CityService service;

        public CitiesController(ContactsAPIDbContext context)
        {
            // TODO: Replace with a DI-container service
            service = new CityService(new UnitOfWork(context));
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(service.GetAllCities());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            City city = service.GetCity(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        public IActionResult GetCityDetails([FromRoute] int id)
        {
            CityDetailsDTO city = service.GetCityDetails(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
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
            City city = service.AddCity(model);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCity([FromRoute] int id, CityDTO model)
        {
            City city = service.UpdateCity(id, model);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            City city = service.DeleteCity(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
