using ContactsAPI.Data.Interfaces;
using ContactsAPI.DTOs;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ContactsAPIDbContext dbContext;

        public Repository<State, int> StatesRepository { get; set; }
        public Repository<City, int> CitiesRepository { get; set; }
        public Repository<Contact, Guid> ContactsRepository { get; set; }
        public Repository<User, Guid> UsersRepository { get; set; }

        public UnitOfWork(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

            StatesRepository = new Repository<State, int>(this.dbContext);
            CitiesRepository = new Repository<City, int>(this.dbContext);
            ContactsRepository = new Repository<Contact, Guid>(this.dbContext);
            UsersRepository = new Repository<User, Guid>(this.dbContext);
        }

        public List<City> GetCitiesFromState(string state)
        {
            return dbContext.Cities.FromSqlRaw($"dbo.GetCitiesFromState '{state}'").ToList();
        }

        public List<Contact> GetContactsFromCity(string city)
        {
            return dbContext.Contacts.FromSqlRaw($"dbo.GetContactsFromCity '{city}'").ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
