using Core.Entity;
using Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MyDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        var entity = await GetById(id);

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}