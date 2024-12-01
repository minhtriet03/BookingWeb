using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface ITuyenDuongRepository : IGenericRepository<Tuyenduong>
    {
        Task<List<Tuyenduong>> GetPagedAsync(int skip, int take);
        Task<List<Tuyenduong>> GetAllTuyenDuongVMAsync();
    }
}
