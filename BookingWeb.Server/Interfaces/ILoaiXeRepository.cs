using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface ILoaiXeRepository : IGenericRepository<Loaixe>
    {
        Task<List<Loaixe>> GetPagedAsync(int skip, int take);
    }
}
