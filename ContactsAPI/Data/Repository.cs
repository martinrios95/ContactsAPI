using ContactsAPI.Data.Interfaces;

namespace ContactsAPI.Data
{
    public class Repository<T, K> : IRepository<T, K> where T : class
    {
        protected ContactsAPIDbContext dbContext;

        public Repository(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Delete(K id)
        {
            T entity = Read(id);

            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
            }

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T Read(K id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
