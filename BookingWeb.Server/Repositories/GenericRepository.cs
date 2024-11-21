using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BookingBusContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(BookingBusContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
         return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> AddAsync(T entity)
    {
       try
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }

    }
    
    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }
}