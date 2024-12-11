using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using BookingWeb.Server.Dto;

namespace BookingWeb.Server.Repositories
{
    public class TuyenDuongRepository : GenericRepository<Tuyenduong>, ITuyenDuongRepository
    {
        public TuyenDuongRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Tuyenduong>> GetPagedAsync(int skip, int take)
        {
            return await _dbContext.Tuyenduongs
                .Include(td => td.NoiKhoiHanhNavigation)
                    .ThenInclude(nkh => nkh.IdTinhThanhNavigation)
                .Include(td => td.NoiDenNavigation)
                    .ThenInclude(nd => nd.IdTinhThanhNavigation)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<List<ChuyenxeDetailDto>> GetLichtrinhAsync(int skip, int take)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu trước
            var chuyenXeList = await _dbContext.Chuyenxes
                .Include(cx => cx.IdTuyenDuongNavigation)
        .           ThenInclude(td => td.NoiKhoiHanhNavigation)
                     .ThenInclude(nkh => nkh.IdTinhThanhNavigation)
                .Include(cx => cx.IdTuyenDuongNavigation)
                    .ThenInclude(td => td.NoiDenNavigation)
                         .ThenInclude(nd => nd.IdTinhThanhNavigation)
                 .Include(cx => cx.IdXeNavigation)
                     .ThenInclude(xe => xe.IdLoaiNavigation)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            // Xử lý dữ liệu sau khi truy vấn
            return chuyenXeList.Select(cx => new ChuyenxeDetailDto
            {
                NoiKhoiHanhTinhThanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh ?? "Dữ liệu thiếu",
                NoiDenTinhThanh = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh ?? "Dữ liệu thiếu",
                KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach ?? 0,
                TrangThai = cx.TrangThai,
                LoaiXe = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai ?? "Không xác định",
                TongThoiGian = string.IsNullOrEmpty(cx.ThoiGianKh) || string.IsNullOrEmpty(cx.ThoiGianDen)
             ? "Không hợp lệ"
             : GetFormattedDuration(cx.ThoiGianKh, cx.ThoiGianDen)
              }).ToList();

        }

        // Phương thức tính toán thời gian di chuyển
        private string GetFormattedDuration(string startTimeString, string endTimeString)
        {
            if (DateTime.TryParse(startTimeString, out var startTime) &&
                DateTime.TryParse(endTimeString, out var endTime))
            {
                var duration = endTime - startTime;
                return $"{(int)duration.TotalHours} giờ {duration.Minutes} phút";
            }
            return "Không hợp lệ";
        }




        public async Task<List<Tuyenduong>> GetAllTuyenDuongVMAsync()
        {
            return await _dbContext.Tuyenduongs
                .Include(td => td.NoiKhoiHanhNavigation)
                    .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .Include(td => td.NoiDenNavigation)
                    .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .ToListAsync();
        }

    }
}
