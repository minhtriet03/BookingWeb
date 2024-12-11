
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using BookingWeb.Server.Dto;
namespace BookingWeb.Server.Interfaces
{
    public interface IChuyenXeRepository : IGenericRepository<Chuyenxe>
    {
        Task<List<Chuyenxe>> GetAllChuyenXeVM();
        Task<List<Chuyenxe>> GetPagedAsync(int skip, int take);

        Task<List<Chuyenxe>> GetChuyenXeByTime(int idXe ,string timeStart, string timeEnd, int IdTuyenDuong, DateOnly date);


        Task<List<ChuyenxeDetailDto>> GetChuyenXeTheoTenTinhAsync(string idTinhKhoiHanh, string idTinhDen, DateOnly date);

        Task AddRangeAsync(IEnumerable<Chuyenxe> chuyenXeList);
        Task<List<Chuyenxe>> LayChuyenXeCoNgayLonNhat();
        Task<List<int>> GetAllIDChuyenXe();
    }
}
