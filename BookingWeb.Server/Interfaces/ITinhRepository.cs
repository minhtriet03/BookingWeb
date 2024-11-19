using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface ITinhRepository : IGenericRepository<Tinhthanh>
    {
        Task<Tinhthanh> GetbyNameAsync(string name);
    }
}
