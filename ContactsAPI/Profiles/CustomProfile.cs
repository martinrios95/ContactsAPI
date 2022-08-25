using AutoMapper;
using ContactsAPI.DTOs;
using ContactsAPI.Models;

namespace ContactsAPI.Profiles
{
    public class CustomProfile: Profile
    {
        public CustomProfile()
        {
            CreateMap<StateDTO, State>();
            CreateMap<CityDTO, City>();
            CreateMap<ContactDTO, Contact>();
        }
    }
}
