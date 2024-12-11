using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services
{
    public class VexeService
    {
        private readonly UnitOfWork _unitOfWork;

        public VexeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Vexe>> getAll()
        {
            return await _unitOfWork.vexes.GetAllAsync();
        }

        public async Task<List<Vexe>> getByPage(int page)
        {
            return await _unitOfWork.vexes.GetByPageAsync(page, 10);
        }
        public async Task<bool> addVeXe(Vexe vexe)
        {
            return await _unitOfWork.vexes.AddAsync(vexe);
        }
        public async Task<bool> deleteVexe(int id)
        {
            return await _unitOfWork.vexes.deleteVexe(id);
        }
        public async Task<List<VeXeVM>> GetByDate(string startDate, string endDate)
        {
            if (!DateTime.TryParse(startDate, out DateTime startParsedDate))
            {
                throw new ArgumentException("Ngày bắt đầu không hợp lệ", nameof(startDate));
            }

            if (!DateTime.TryParse(endDate, out DateTime endParsedDate))
            {
                throw new ArgumentException("Ngày kết thúc không hợp lệ", nameof(endDate));
            }

            var startDateOnly = DateOnly.FromDateTime(startParsedDate);
            var endDateOnly = DateOnly.FromDateTime(endParsedDate);

            // Debug input dates
            Console.WriteLine($"Start Date: {startDateOnly}, End Date: {endDateOnly}");

            var data = await _unitOfWork.vexes.GetByDateAsync(startDateOnly, endDateOnly);

            if (data == null || !data.Any())
            {
                Console.WriteLine("Không có dữ liệu trả về từ GetByDateAsync.");
                return new List<VeXeVM>();
            }

            var veXe = data.Select(vx => new VeXeVM
            {
                IdVe = vx.IdVe,
                IdPhieu = vx.IdPhieu,
                IdChuyenXe = vx.IdChuyenXe,
                ViTriGhe = vx.ViTriGhe,
                NgayKhoiHanh = vx.NgayKhoiHanh,
                TrangThai = vx.TrangThai,
                IdChuyenXeNavigation = vx.IdChuyenXeNavigation == null
                    ? null
                    : new ChuyenXeVM
                    {
                        IdChuyenXe = vx.IdChuyenXeNavigation.IdChuyenXe,
                        ThoiGianKh = vx.IdChuyenXeNavigation.ThoiGianKh,
                        ThoiGianDen = vx.IdChuyenXeNavigation.ThoiGianDen,
                        TuyenDuongVM = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation == null
                            ? null
                            : new TuyenDuongVM
                            {
                                IdTuyenDuong = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.IdTuyenDuong,
                                NoiKhoiHanh = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                                KhoangCach = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.KhoangCach,
                                NoiDen = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                                GiaVe = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.GiaVe,
                                TenBenXeDi = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiKhoiHanhNavigation?.TenBenXe,
                                TenBenXeDen = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiDenNavigation?.TenBenXe,
                                TrangThai = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.TrangThai
                            },
                        XeVM = vx.IdChuyenXeNavigation == null ? null : new XeVM
                        {
                            BienSo = vx.IdChuyenXeNavigation.IdXeNavigation.BienSo,
                        }
                    }
                
            }).ToList();

            return veXe;
        }
    }


}
