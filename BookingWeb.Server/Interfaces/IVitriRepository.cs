using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IVitriRepository :IGenericRepository<Vitri>
    {
        Task<List<Vitri>> GetByPageAsync(int skip, int take);
        Task<bool> AnyAsync();
        Task AddRangeAsync(IEnumerable<Vitri> vitris);
    }
}
