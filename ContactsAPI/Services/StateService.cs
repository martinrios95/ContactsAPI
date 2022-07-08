using ContactsAPI.Data;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using ContactsAPI.Services.Interfaces;

namespace ContactsAPI.Services
{
    public class StateService: IService
    {
        private UnitOfWork unitOfWork;
        public StateService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<State> GetAllStates()
        {
            return unitOfWork.StatesRepository.GetAll();
        }

        public State GetState(int id)
        {
            return unitOfWork.StatesRepository.Read(id);
        }

        public State AddState(StateDTO dto)
        {
            State state = new State()
            {
                StateName = dto.StateName
            };

            unitOfWork.StatesRepository.Create(state);
            unitOfWork.Save();

            return state;
        }

        public State UpdateState(int id, StateDTO dto)
        {
            State state = GetState(id);

            if (state == null)
            {
                return null;
            }

            state.StateName = dto.StateName;

            unitOfWork.Save();

            return state;
        }

        public State DeleteState(int id)
        {
            State state = GetState(id);

            if (state == null)
            {
                return null;
            }

            unitOfWork.StatesRepository.Delete(id);

            unitOfWork.Save();

            return state;
        }
    }
}
