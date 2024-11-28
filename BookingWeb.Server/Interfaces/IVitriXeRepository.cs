using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IVitriXeRepository : IGenericRepository<Xevitri>
    {
        Task<List<Xevitri>> GetByPageAsync(int skip, int take);
    }
}
