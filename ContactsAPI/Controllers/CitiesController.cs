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

        /// <summary>
        /// Obtener todas las ciudades
        /// </summary>
        /// <returns>Una lista de ciudades</returns>
        /// <response code="401">Si el usuario no inició sesión</response>
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(service.GetAllCities().Response);
        }

        /// <summary>
        /// Obtener una ciudad mediante ID
        /// </summary>
        /// <returns>Una ciudad</returns>
        /// <response code="200">Si la ciudad existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la ciudad no existe</response>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            var response = service.GetCity(id);

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
        /// Obtener todas las ciudades de una provincia
        /// </summary>
        /// <returns>Las ciudades de una provincia</returns>
        /// <response code="200">Si la provincia existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la provincia no existe</response>
        [HttpGet]
        [Route("State/{id:int}")]
        public IActionResult GetCitiesFromState([FromRoute] int id)
        {
            var response = service.GetCitiesFromState(id);

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
        /// Obtener detalles de una ciudad mediante ID
        /// </summary>
        /// <returns>Los detalles de la ciudad</returns>
        /// <response code="200">Si la ciudad existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la ciudad no existe</response>
        [HttpGet]
        [Route("Details/{id:int}")]
        public IActionResult GetCityDetails([FromRoute] int id)
        {
            var response = service.GetCityDetails(id);

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
        /// KABOOM
        /// </summary>
        /// <returns>Nada, una excepción.</returns>
        [HttpGet]
        [Route("Kaboom")]
        public IActionResult Kaboom()
        {
            throw new Exception("KABOOM CON ESTILO");

            // It highlights as "never accesible" code, but...
            return Content("Never gets there");
        }

        /// <summary>
        /// Agregar una ciudad
        /// </summary>
        /// <returns>La ciudad agregada</returns>
        /// <response code="401">Si el usuario no inició sesión</response>
        [HttpPost]
        public IActionResult AddCity(CityDTO model)
        {
            var response = service.AddCity(model);

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
        /// Actualizar los datos de una ciudad
        /// </summary>
        /// <param name="id">El ID de ciudad</param>
        /// <param name="model">Los datos de la ciudad</param>
        /// <returns>La ciudad actualizada</returns>
        /// <response code="200">Si la ciudad existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la ciudad no existe</response>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCity([FromRoute] int id, CityDTO model)
        {
            var response = service.UpdateCity(id, model);

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
        /// Borrar una ciudad
        /// </summary>
        /// <returns>La ciudad eliminada</returns>
        /// <response code="200">Si la ciudad existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la ciudad no existe</response>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            var response = service.DeleteCity(id);

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
