namespace Core.Interface.Repository.Generic;

public interface IGenericRepository<T> where T : class
{
    Task Create(T entity);
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task Update(T entity);
    Task Remove(int id);
}