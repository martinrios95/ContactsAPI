namespace ContactsAPI.Data.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        public T Create(T entity);

        public T Read(K id);

        public T Update(T entity);

        public T Delete(K id);

        public IEnumerable<T> GetAll();
    }
}
