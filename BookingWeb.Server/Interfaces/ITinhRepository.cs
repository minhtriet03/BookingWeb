using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface ITinhRepository : IGenericRepository<Tinhthanh>
    {
        Task<Tinhthanh> GetbyNameAsync(string name);
        Task<bool> deleteTinh(int id);
        Task<List<Tinhthanh>> GetByPageAsync(int skip, int take);
    }
}
