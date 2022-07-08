using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;

namespace ContactsAPI.Services
{
    public class CityService
    {
        private UnitOfWork unitOfWork;
        public CityService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<City> GetAllCities()
        {
            return unitOfWork.CitiesRepository.GetAll();
        }

        public City GetCity(int id)
        {
            return unitOfWork.CitiesRepository.Read(id);
        }

        public State GetState(int id)
        {
            return unitOfWork.StatesRepository.Read(id);
        }

        public City AddCity(CityDTO dto)
        {
            State state = GetState(dto.StateID);

            if (state == null)
            {
                return null;
            }

            City city = new City()
            {
                CityName = dto.CityName,
                StateID = dto.StateID
            };

            unitOfWork.CitiesRepository.Create(city);
            unitOfWork.Save();

            return city;
        }

        public CityDetailsDTO GetCityDetails(int id)
        {
            City city = GetCity(id);

            if (city == null)
            {
                return null;
            }

            State state = GetState(city.StateID);

            CityDetailsDTO dto = new CityDetailsDTO()
            {
                CityName = city.CityName,
                StateName = state.StateName
            };

            return dto;
        }

        public City UpdateCity(int id, CityDTO dto)
        {
            State state = GetState(dto.StateID);

            if (state == null)
            {
                return null;
            }

            City city = GetCity(id);

            if (city == null)
            {
                return null;
            }

            city.CityName = dto.CityName;
            city.StateID = dto.StateID;

            unitOfWork.CitiesRepository.Update(city);

            return city;
        }

        public City DeleteCity(int id)
        {
            City city = GetCity(id);

            if (city == null)
            {
                return null;
            }

            unitOfWork.CitiesRepository.Delete(id);

            unitOfWork.Save();

            return city;
        }
    }
}
