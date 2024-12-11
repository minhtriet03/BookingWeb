using BookingWeb.Server.Models;
using BookingWeb.Server.Dto;
namespace BookingWeb.Server.Interfaces
{
    public interface ITuyenDuongRepository : IGenericRepository<Tuyenduong>
    {
        Task<List<Tuyenduong>> GetPagedAsync(int skip, int take);
        Task<List<Tuyenduong>> GetAllTuyenDuongVMAsync();
        Task<List<ChuyenxeDetailDto>> GetLichtrinhAsync(int skip, int take);

    }
}
