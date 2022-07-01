namespace ContactsAPI.Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        public T Create(T entity);

        public T Read(int id);

        public T Update(T entity);

        public T Delete(int id);

        public IEnumerable<T> GetAll();

        public void Save();
    }
}
