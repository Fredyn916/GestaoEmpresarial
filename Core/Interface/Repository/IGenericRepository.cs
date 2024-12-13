namespace Core.Interface.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
        Task Remove(int id);
    }
}