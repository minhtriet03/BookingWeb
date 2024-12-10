using System.Linq.Expressions;

namespace BookingWeb.Server.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<int> CountAsync();
    Task<bool> DeactivateAsync(int id, Func<T, bool> condition, Action<T> change);
}