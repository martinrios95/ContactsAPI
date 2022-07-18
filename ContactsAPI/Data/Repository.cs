using ContactsAPI.Data.Interfaces;
using System.Linq.Expressions;

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

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public T GetFirst(Expression<Func<T, bool>> expression)
        {
            return GetWhere(expression).FirstOrDefault();
        }

        public T GetLast(Expression<Func<T, bool>> expression)
        {
            return GetWhere(expression).LastOrDefault();
        }

        public T Read(K id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
