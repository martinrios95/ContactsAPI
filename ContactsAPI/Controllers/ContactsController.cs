using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(dbContext.Contacts.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            Contact contact = dbContext.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(ContactDTO model)
        {
            City city = dbContext.Cities.Find(model.CityID);

            if (city == null)
            {
                return NotFound(Content("City not found"));
            }

            Contact contact = new Contact()
            {
                ContactID = Guid.NewGuid(),
                ContactName = model.ContactName,
                ContactAddress = model.ContactAddress,
                ContactPhone = model.ContactPhone,
                CityID = model.CityID
            };

            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateContact([FromRoute] Guid id, ContactDTO model)
        {
            City city = dbContext.Cities.Find(model.CityID);

            if (city == null)
            {
                return NotFound(Content("City not found"));
            }

            Contact contact = dbContext.Contacts.Find(id);

            if (contact != null)
            {
                contact.ContactName = model.ContactName;
                contact.ContactAddress = model.ContactAddress;
                contact.ContactPhone = model.ContactPhone;
                contact.CityID = model.CityID;

                dbContext.SaveChanges();

                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult deleteContact([FromRoute] Guid id)
        {
            Contact contact = dbContext.Contacts.Find(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                dbContext.SaveChanges();

                return Ok(contact);
            }

            return NotFound();
        }
    }
}
