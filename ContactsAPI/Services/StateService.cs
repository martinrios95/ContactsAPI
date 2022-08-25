using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services.Enums;

namespace ContactsAPI.Services
{
    public class StateService
    {
        private UnitOfWork unitOfWork;
        private IMapper mapper;
        public StateService(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ServiceResponse<IEnumerable<State>> GetAllStates()
        {
            return new ServiceResponse<IEnumerable<State>>()
            {
                Response = unitOfWork.StatesRepository.GetAll(),
                ResponseType = ResponseTypes.SUCCESS
            };
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

        public ServiceResponse<State> AddState(StateDTO dto)
        {
            State state = mapper.Map<State>(dto);

            unitOfWork.StatesRepository.Create(state);
            unitOfWork.Save();

            return new ServiceResponse<State>()
            {
                Response = state,
                ResponseType = ResponseTypes.SUCCESS
            };
        }

        public ServiceResponse<State> UpdateState(int id, StateDTO dto)
        {
            State state = GetState(id).Response;

            var response = new ServiceResponse<State>()
            {
                Response = state,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (state == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
                return response;
            }

            state.StateName = dto.StateName;

            unitOfWork.Save();

            return response;
        }

        public ServiceResponse<State> DeleteState(int id)
        {
            State state = GetState(id).Response;

            var response = new ServiceResponse<State>()
            {
                Response = state,
                ResponseType = ResponseTypes.SUCCESS
            };

            if (state == null)
            {
                response.ResponseType = ResponseTypes.ERROR;
                response.ResponseMessage = "State not found!";
                return response;
            }

            unitOfWork.StatesRepository.Delete(id);

            unitOfWork.Save();

            return response;
        }
    }
}
