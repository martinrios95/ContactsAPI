using ContactsAPI.DTOs;
using ContactsAPI.Services;
using ContactsAPI.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly CityService service;

        public CitiesController(CityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(service.GetAllCities().Response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            var response = service.GetCity(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpGet]
        [Route("State/{id:int}")]
        public IActionResult GetCitiesFromState([FromRoute] int id)
        {
            var response = service.GetCitiesFromState(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        public IActionResult GetCityDetails([FromRoute] int id)
        {
            var response = service.GetCityDetails(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpGet]
        [Route("Kaboom")]
        public IActionResult Kaboom()
        {
            throw new Exception("KABOOM CON ESTILO");

            // It highlights as "never accesible" code, but...
            return Content("Never gets there");
        }

        [HttpPost]
        public IActionResult AddCity(CityDTO model)
        {
            var response = service.AddCity(model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCity([FromRoute] int id, CityDTO model)
        {
            var response = service.UpdateCity(id, model);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            var response = service.DeleteCity(id);

            if (response.ResponseType == ResponseTypes.ERROR)
            {
                return NotFound();
            }

            return Ok(response.Response);
        }
    }
}
