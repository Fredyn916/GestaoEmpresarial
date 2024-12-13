﻿using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task Create(T entity)
    {
        await _repository.Create(entity);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<T> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(T entity)
    {
        await _repository.Update(entity);
    }

    public async Task Remove(int id)
    {
        await _repository.Remove(id);
    }
}