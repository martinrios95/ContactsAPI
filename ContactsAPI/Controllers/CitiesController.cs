using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public CitiesController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(dbContext.Cities.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            City city = dbContext.Cities.Find(id);
            if (city != null)
            {
                return Ok(city);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCity(CityDTO model)
        {
            State state = dbContext.States.Find(model.StateID);

            if (state == null)
            {
                return NotFound(Content("State not found"));
            }

            City city = new City()
            {
                CityName = model.CityName,
                StateID = model.StateID
            };

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();

            return Ok(city);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCity([FromRoute] int id, CityDTO model)
        {
            State state = dbContext.States.Find(model.StateID);

            if (state == null)
            {
                return NotFound(Content("State not found"));
            }

            City city = dbContext.Cities.Find(id);

            if (city != null)
            {
                city.CityName = model.CityName;
                city.StateID = model.StateID;

                dbContext.SaveChanges();

                return Ok(city);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            City city = dbContext.Cities.Find(id);

            // TODO: The state's not gonna be wiped

            if (city != null)
            {

                dbContext.Remove(city);

                dbContext.SaveChanges();

                return Ok(city);
            }

            return NotFound();
        }
    }
}
