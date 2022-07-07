﻿using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Filters;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            unitOfWork = new UnitOfWork(dbContext);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(unitOfWork.ContactsRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            Contact contact = unitOfWork.ContactsRepository.Read(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet]
        [Route("Details/{id:guid}")]
        public IActionResult GetContactDetails([FromRoute] Guid id)
        {
            Contact contact = unitOfWork.ContactsRepository.Read(id);

            if (contact == null)
            {
                return NotFound();
            }

            City city = unitOfWork.CitiesRepository.Read(contact.CityID);

            State state = unitOfWork.StatesRepository.Read(city.StateID);

            ContactDetailsDTO dto = new ContactDetailsDTO()
            {
                ContactName = contact.ContactName,
                ContactAddress = contact.ContactAddress,
                ContactPhone = contact.ContactPhone,
                CityName = city.CityName,
                StateName = state.StateName
            };

            return Ok(dto);
        }

        [HttpPost]
        [ModelValidationFilter]
        public IActionResult AddContact(ContactDTO model)
        {
            City city = unitOfWork.CitiesRepository.Read(model.CityID);

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

            unitOfWork.ContactsRepository.Create(contact);
            unitOfWork.Save();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ModelValidationFilter]
        public IActionResult UpdateContact([FromRoute] Guid id, ContactDTO model)
        {
            City city = unitOfWork.CitiesRepository.Read(model.CityID);

            if (city == null)
            {
                return NotFound(Content("City not found"));
            }

            Contact contact = unitOfWork.ContactsRepository.Read(id);

            if (contact != null)
            {
                contact.ContactName = model.ContactName;
                contact.ContactAddress = model.ContactAddress;
                contact.ContactPhone = model.ContactPhone;
                contact.CityID = model.CityID;

                unitOfWork.Save();

                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact([FromRoute] Guid id)
        {
            Contact contact = unitOfWork.ContactsRepository.Read(id);

            if (contact != null)
            {
                unitOfWork.ContactsRepository.Delete(id);
                unitOfWork.Save();

                return Ok(contact);
            }

            return NotFound();
        }
    }
}
