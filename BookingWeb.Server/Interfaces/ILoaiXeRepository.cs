using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Interfaces
{
    public interface ILoaiXeRepository : IGenericRepository<Loaixe>
    {
        Task<bool> AddAsync(Loaixe entity);
        Task<List<Loaixe>> GetPagedAsync(int skip, int take);
    }
}
