using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IVexeRepository : IGenericRepository<Vexe>
    {
        Task<bool> deleteVexe(int id);
        Task<List<Vexe>> GetByPageAsync(int skip, int take);

    }
}
