using ContactsAPI.Data.Interfaces;

namespace ContactsAPI.Data
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected ContactsAPIDbContext dbContext;

        public Repository(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            Save();
            return entity;
        }

        public T Delete(int id)
        {
            T entity = Read(id);

            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                Save();
            }

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T Read(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
