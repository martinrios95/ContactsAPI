using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services.Enums;

namespace ContactsAPI.Services
{
    public class ContactService
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;
        public ContactService(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ServiceResponse<IEnumerable<Contact>> GetAllContacts()
        {
            return new ServiceResponse<IEnumerable<Contact>>()
            {
                Response = unitOfWork.ContactsRepository.GetAll(),
                ResponseType = ResponseTypes.SUCCESS
            };
        }

        public ServiceResponse<Contact> GetContact(Guid id)
        {
            var response = new ServiceResponse<Contact>()
            {
                Response = unitOfWork.ContactsRepository.Read(id),
                ResponseType = ResponseTypes.SUCCESS
            };

            if (response.Response == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "Contact not found!";
            }

            return response;
        }

        public ServiceResponse<City> GetCity(int id)
        {
            var response = new ServiceResponse<City>()
            {
                Response = unitOfWork.CitiesRepository.Read(id),
                ResponseType = ResponseTypes.SUCCESS
            };

            if (response.Response == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "City not found!";
            }

            return response;
        }

        public ServiceResponse<State> GetState(int id)
        {
            var response = new ServiceResponse<State>()
            {
                Response = unitOfWork.StatesRepository.Read(id),
                ResponseType = ResponseTypes.SUCCESS
            };

            if (response.Response == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
            }

            return response;
        }

        public ServiceResponse<IEnumerable<Contact>> GetContactsFromCity(int id)
        {
            City city = GetCity(id).Response;

            var response = new ServiceResponse<IEnumerable<Contact>>
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (city == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "City not found!";
                return response;
            }

            var contacts = unitOfWork.ContactsRepository.GetWhere(city => city.CityID == id);
            response.Response = contacts;

            return response;
        }

        public ServiceResponse<ContactDetailsDTO> GetContactDetails(Guid id)
        {
            Contact contact = GetContact(id).Response;

            var response = new ServiceResponse<ContactDetailsDTO>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (contact == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "Contact not found!";
                return response;
            }

            City city = GetCity(contact.CityID).Response;
            State state = GetState(city.StateID).Response;

            response.Response = new ContactDetailsDTO()
            {
                ContactName = contact.ContactName,
                ContactAddress = contact.ContactAddress,
                ContactPhone = contact.ContactPhone,
                CityName = city.CityName,
                StateName = state.StateName
            };

            return response;
        }

        public ServiceResponse<Contact> AddContact(ContactDTO dto)
        {
            City city = GetCity(dto.CityID).Response;

            var response = new ServiceResponse<Contact>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (city == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "City not found!";
                return response;
            }

            Contact contact = mapper.Map<Contact>(dto);

            unitOfWork.ContactsRepository.Create(contact);
            unitOfWork.Save();

            response.Response = contact;
            return response;
        }

        public ServiceResponse<Contact> UpdateContact(Guid id, ContactDTO model)
        {
            City city = GetCity(model.CityID).Response;

            var response = new ServiceResponse<Contact>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (city == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "City not found!";
                return response;
            }

            Contact contact = GetContact(id).Response;

            if (contact == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "Contact not found!";
                return response;
            }

            contact.ContactName = model.ContactName;
            contact.ContactAddress = model.ContactAddress;
            contact.ContactPhone = model.ContactPhone;
            contact.CityID = model.CityID;

            unitOfWork.Save();

            response.Response = contact;

            return response;
        }

        public ServiceResponse<Contact> DeleteContact(Guid id)
        {
            Contact contact = GetContact(id).Response;

            var response = new ServiceResponse<Contact>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (contact == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "Contact not found!";
                return response;
            }

            unitOfWork.ContactsRepository.Delete(id);
            unitOfWork.Save();

            return response;
        }
    }
}
