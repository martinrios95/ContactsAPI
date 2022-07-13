using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services.Enums;

namespace ContactsAPI.Services
{
    public class CityService
    {
        private UnitOfWork unitOfWork;
        public CityService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ServiceResponse<IEnumerable<City>> GetAllCities()
        {
            return new ServiceResponse<IEnumerable<City>>()
            {
                Response = unitOfWork.CitiesRepository.GetAll(),
                ResponseType = ResponseTypes.SUCCESS
            };
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

        public ServiceResponse<City> AddCity(CityDTO dto)
        {
            State state = GetState(dto.StateID).Response;

            var response = new ServiceResponse<City>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (state == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
                return response;
            }

            City city = new City()
            {
                CityName = dto.CityName,
                StateID = dto.StateID
            };

            unitOfWork.CitiesRepository.Create(city);
            unitOfWork.Save();


            response.Response = city;

            return response;
        }

        public ServiceResponse<IEnumerable<City>> GetCitiesFromState(int id)
        {
            State state = GetState(id).Response;

            var response = new ServiceResponse<IEnumerable<City>>
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (state == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
                return response;
            }

            var cities = unitOfWork.CitiesRepository.GetWhere(state => state.StateID == id);
            response.Response = cities;

            return response;
        }

        public ServiceResponse<CityDetailsDTO> GetCityDetails(int id)
        {
            City city = GetCity(id).Response;

            var response = new ServiceResponse<CityDetailsDTO>()
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

            State state = GetState(city.StateID).Response;

            CityDetailsDTO dto = new CityDetailsDTO()
            {
                CityName = city.CityName,
                StateName = state.StateName
            };

            response.Response = dto;

            return response;
        }

        public ServiceResponse<City> UpdateCity(int id, CityDTO dto)
        {
            State state = GetState(dto.StateID).Response;

            var response = new ServiceResponse<City>()
            {
                Response = null,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (state == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
                return response;
            }

            City city = GetCity(id).Response;

            if (city == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "City not found!";
                return response;
            }

            city.CityName = dto.CityName;
            city.StateID = dto.StateID;

            unitOfWork.Save();

            response.Response = city;

            return response;
        }

        public ServiceResponse<City> DeleteCity(int id)
        {
            City city = GetCity(id).Response;

            var response = new ServiceResponse<City>()
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

            unitOfWork.CitiesRepository.Delete(id);

            unitOfWork.Save();

            response.Response = city;

            return response;
        }
    }
}
