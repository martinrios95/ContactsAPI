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
    public class StatesController : Controller
    {
        private readonly StateService service;

        public StatesController(StateService service)
        {
            this.service = service;
        }
        /// <summary>
        /// Obtener lista de provincias
        /// </summary>
        /// <returns>Una lista de provincias</returns>
        /// <response code="401">Si el usuario no inició sesión</response>
        [HttpGet]
        public IActionResult GetStates()
        {
            return Ok(service.GetAllStates());
        }

        /// <summary>
        /// Obtener una provincia mediante ID
        /// </summary>
        /// <param name="id">El ID de provincias</param>
        /// <returns>Una provincia</returns>
        /// <response code="200">Si la provincia existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la provincia no existe</response>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            var response = service.GetState(id);

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
        /// Agregar una provincia
        /// </summary>
        /// <param name="model">Los datos de la provincia</param>
        /// <returns>La provincia agregada</returns>
        /// <response code="401">Si el usuario no inició sesión</response>
        [HttpPost]
        public IActionResult AddState(StateDTO model)
        {
            return Ok(service.AddState(model).Response);
        }

        /// <summary>
        /// Actualizar los datos de una provincia
        /// </summary>
        /// <param name="id">El ID de la provincia</param>
        /// <param name="model">Los datos a actualizar de la provincia</param>
        /// <returns>La provincia modificada</returns>
        /// <response code="200">Si la provincia existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la provincia no existe</response>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateState([FromRoute] int id, StateDTO model)
        {
            var response = service.UpdateState(id, model);

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
        /// Borrar una provincia
        /// </summary>
        /// <returns>La provincia eliminada</returns>
        /// <response code="200">Si la provincia existe</response>
        /// <response code="401">Si el usuario no inició sesión</response>
        /// <response code="404">Si la provincia no existe</response>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteState([FromRoute] int id)
        {
            var response = service.DeleteState(id);

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
