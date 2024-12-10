using BookingWeb.Server.Dto;
using BookingWeb.Server.Models;



namespace BookingWeb.Server.Interfaces
{
    public interface IChuyenXeRepository : IGenericRepository<Chuyenxe>
    {
        Task<List<Chuyenxe>> GetAllChuyenXeVM();
        Task<List<Chuyenxe>> GetPagedAsync(int skip, int take);
        Task<List<ChuyenxeDetailDto>> GetChuyenXeTheoTenTinhAsync(string idTinhKhoiHanh, string idTinhDen);
    }
}
