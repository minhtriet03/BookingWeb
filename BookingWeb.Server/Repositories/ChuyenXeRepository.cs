using BookingWeb.Server.Dto;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
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

        public async Task<List<ChuyenxeDetailDto>> GetChuyenXeTheoTenTinhAsync(string tenTinhKhoiHanh, string tenTinhDen)
        {
            var chuyenXeList = await _dbContext.Chuyenxes
         .Include(cx => cx.IdTuyenDuongNavigation)
             .ThenInclude(td => td.NoiKhoiHanhNavigation)
                 .ThenInclude(bx => bx.IdTinhThanhNavigation)
         .Include(cx => cx.IdTuyenDuongNavigation)
             .ThenInclude(td => td.NoiDenNavigation)
                 .ThenInclude(bx => bx.IdTinhThanhNavigation)
         .Include(cx => cx.IdXeNavigation)
             .ThenInclude(xe => xe.IdLoaiNavigation)
         .Include(cx => cx.Vexes) // Include bảng Vexe để đếm số lượng vé
         .Where(cx => cx.IdTuyenDuongNavigation.NoiKhoiHanhNavigation.IdTinhThanhNavigation.TenTinhThanh == tenTinhKhoiHanh &&
                      cx.IdTuyenDuongNavigation.NoiDenNavigation.IdTinhThanhNavigation.TenTinhThanh == tenTinhDen)
         .ToListAsync();

            return chuyenXeList.Select(cx => new ChuyenxeDetailDto
            {
                NoiKhoiHanhTinhThanh = cx.IdTuyenDuongNavigation.NoiKhoiHanhNavigation.IdTinhThanhNavigation.TenTinhThanh,
                NoiDenTinhThanh = cx.IdTuyenDuongNavigation.NoiDenNavigation.IdTinhThanhNavigation.TenTinhThanh,
                GiaVe = cx.IdTuyenDuongNavigation.GiaVe ?? 0, // Lấy giá vé từ Tuyenduong
                KhoangCach = cx.IdTuyenDuongNavigation.KhoangCach ?? 0,
                TrangThai = cx.TrangThai,
                SoLuongVeDaDat = cx.Vexes.Count, // Đếm số lượng vé từ bảng Vexe
                LoaiXe = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai ?? "Không xác định",
                TongThoiGian = GetFormattedDuration(cx.ThoiGianKh, cx.ThoiGianDen),
                TGKH = cx.ThoiGianKh,
                TGKT = cx.ThoiGianDen
            }).ToList();
        }

        private string GetFormattedDuration(string startTimeString, string endTimeString)
        {
            if (DateTime.TryParse(startTimeString, out var startTime) &&
                DateTime.TryParse(endTimeString, out var endTime))
            {
                // Nếu thời gian kết thúc nhỏ hơn thời gian bắt đầu, thêm 1 ngày vào thời gian kết thúc
                if (endTime < startTime)
                {
                    endTime = endTime.AddDays(1);
                }

                var duration = endTime - startTime;

                if (duration.Minutes == 0) 
                return $"{(int)duration.TotalHours} giờ";
                else
                return $"{(int)duration.TotalHours} giờ {duration.Minutes} phút";
            }
            return "Không hợp lệ";
        }
    }
}
