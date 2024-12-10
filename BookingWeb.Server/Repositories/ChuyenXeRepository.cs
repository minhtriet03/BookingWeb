using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class ChuyenXeRepository : GenericRepository<Chuyenxe>, IChuyenXeRepository
    {
        public ChuyenXeRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Chuyenxe>> GetAllChuyenXeVM()
        {
            return await _dbContext.Chuyenxes
                .Include(cx => cx.IdXeNavigation) // Nạp thông tin Xe
                    .ThenInclude(x => x.IdLoaiNavigation) // Nạp thông tin Loại Xe
                .Include(cx => cx.IdTuyenDuongNavigation) // Nạp thông tin Tuyến Đường
                    .ThenInclude(td => td.NoiKhoiHanhNavigation) // Nạp thông tin Nơi Khởi Hành
                        .ThenInclude(nkh => nkh.IdTinhThanhNavigation) // Nạp thông tin Tỉnh Thành (Nơi Khởi Hành)
                .Include(cx => cx.IdTuyenDuongNavigation.NoiDenNavigation) // Nạp thông tin Nơi Đến
                    .ThenInclude(nd => nd.IdTinhThanhNavigation) // Nạp thông tin Tỉnh Thành (Nơi Đến)
                .ToListAsync();
        }
        
        public async Task<List<Chuyenxe>> GetPagedAsync(int skip, int take)
        {
            return await _dbContext.Chuyenxes
                .Include(cx => cx.IdXeNavigation) // Nạp thông tin Xe
                    .ThenInclude(x => x.IdLoaiNavigation) // Nạp thông tin Loại Xe
                .Include(cx => cx.IdTuyenDuongNavigation) // Nạp thông tin Tuyến Đường
                    .ThenInclude(td => td.NoiKhoiHanhNavigation) // Nạp thông tin Nơi Khởi Hành
                        .ThenInclude(nkh => nkh.IdTinhThanhNavigation) // Nạp thông tin Tỉnh Thành (Nơi Khởi Hành)
                .Include(cx => cx.IdTuyenDuongNavigation.NoiDenNavigation) // Nạp thông tin Nơi Đến
                    .ThenInclude(nd => nd.IdTinhThanhNavigation) // Nạp thông tin Tỉnh Thành (Nơi Đến)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        public async Task<List<Chuyenxe>> GetChuyenXeByTime(string timeStart, string timeEnd, int IdTuyenDuong)
        {

            if (string.Compare(timeStart, timeEnd) >= 0)
            {
                var data = await _dbContext.Chuyenxes
                    .Where(cx => cx.IdTuyenDuong == IdTuyenDuong &&
                                 (string.Compare(cx.ThoiGianKh, timeStart) >= 0 && string.Compare(cx.ThoiGianKh, timeEnd) <= 0) ||
                                 (string.Compare(cx.ThoiGianKh, timeStart) >= 0 && string.Compare(cx.ThoiGianKh, timeEnd) >= 0) ||
                                 (string.Compare(cx.ThoiGianDen, timeStart) >= 0 && string.Compare(cx.ThoiGianDen, timeEnd) <= 0) ||
                                 (string.Compare(cx.ThoiGianKh, timeStart) <= 0 && string.Compare(cx.ThoiGianDen, timeEnd) >= 0)
                                 
                    )
                    .Include(cx => cx.IdXeNavigation)
                    .Include(cx => cx.IdTuyenDuongNavigation)
                    .ToListAsync();

                return data;
            }
            else
            {
                var data = await _dbContext.Chuyenxes
                    .Where(cx => cx.IdTuyenDuong == IdTuyenDuong &&
                                 (string.Compare(cx.ThoiGianKh, timeStart) >= 0 && string.Compare(cx.ThoiGianKh, timeEnd) <= 0) ||
                                 (string.Compare(cx.ThoiGianDen, timeStart) >= 0 && string.Compare(cx.ThoiGianDen, timeEnd) <= 0) ||
                                 (string.Compare(cx.ThoiGianKh, timeStart) <= 0 && string.Compare(cx.ThoiGianDen, timeEnd) >= 0)
                                 
                    )
                    .Include(cx => cx.IdXeNavigation)
                    .Include(cx => cx.IdTuyenDuongNavigation)
                    .ToListAsync();
                return data;

            }
            return null;
        }
    }
}
