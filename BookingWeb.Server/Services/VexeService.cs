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

        public async Task<List<Vexe>> GetVebyPhieuWithDetails(int id)
        {
            return await _unitOfWork.vexes.GetByIdPhieuAsync(id);
        }

        public async Task<List<Vexe>> getByPage(int page)
        {
            return await _unitOfWork.vexes.GetByPageAsync(page, 10);
        }
        public async Task<List<Vexe>> getByChuyenXe(int id_chuyenxe)
        {
            return await _unitOfWork.vexes.GetByConditionAsync(vx => vx.IdChuyenXe == id_chuyenxe);
        }
        public async Task<bool> addVeXe(Vexe vexe)
        {
            return await _unitOfWork.vexes.AddAsync(vexe);
        }
        public async Task<bool> deleteVexe(int id)
        {
            return await _unitOfWork.vexes.deleteVexe(id);
        }
        public async Task<List<VeXeVM>> GetByDate()
        {
            var data = await _unitOfWork.vexes.GetByDateAsync();

            if (data == null || !data.Any())
            {
                return null;
            }

            var veXe = data.Select(vx => new VeXeVM
            {
                IdVe = vx.IdVe,
                IdPhieu = vx.IdPhieu,
                IdChuyenXe = vx.IdChuyenXe,
                ViTriGhe = vx.ViTriGhe,
                TrangThai = vx.TrangThai,
                IdChuyenXeNavigation = vx.IdChuyenXeNavigation == null
                    ? null
                    : new ChuyenXeVM
                    {
                        IdChuyenXe = vx.IdChuyenXeNavigation.IdChuyenXe,
                        ThoiGianKh = vx.IdChuyenXeNavigation?.ThoiGianKh,
                        ThoiGianDen = vx.IdChuyenXeNavigation?.ThoiGianDen,
                        NgayKhoiHanh = vx.IdChuyenXeNavigation.NgayKhoiHanh,
                        TrangThai = vx.IdChuyenXeNavigation.TrangThai,
                        XeVM = vx.IdChuyenXeNavigation.IdXeNavigation == null ?  null : new XeVM
                        {
                            BienSo = vx.IdChuyenXeNavigation.IdXeNavigation.BienSo,
                            TinhTrang = vx.IdChuyenXeNavigation.IdXeNavigation.TinhTrang
                        },
                        TuyenDuongVM = vx.IdChuyenXeNavigation?.IdTuyenDuongNavigation == null
                            ? null
                            : new TuyenDuongVM
                            {
                                IdTuyenDuong = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.IdTuyenDuong,
                                NoiKhoiHanh = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiKhoiHanhNavigation.IdTinhThanhNavigation.TenTinhThanh,
                                KhoangCach = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.KhoangCach,
                                NoiDen = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiDenNavigation.IdTinhThanhNavigation.TenTinhThanh,
                                GiaVe = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.GiaVe,
                                TenBenXeDi = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiKhoiHanhNavigation.TenBenXe,
                                TenBenXeDen = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.NoiDenNavigation.TenBenXe,
                                TrangThai = vx.IdChuyenXeNavigation.IdTuyenDuongNavigation.TrangThai
                            },

                    }
                
            }).ToList();

            return veXe;
        }
        
        public async Task<List<int>> LayIDChuyenXeChuaCoVe()
        {
            var tatCaChuyenXe = await _unitOfWork.chuyenXeRepository.GetAllIDChuyenXe();
            var chuyenXeDaCoVe = await _unitOfWork.vexes.GetAllIDChuyenXeInVeXe();
            
            var chuyenXeChuaCoVe = tatCaChuyenXe
                .Except(chuyenXeDaCoVe)
                .ToList();
            
            return chuyenXeChuaCoVe;
        }
        
        public async Task<bool> CreateVeXe()
        {
            var chuyenXeChuaCoVe = await LayIDChuyenXeChuaCoVe();
            
            var viTriGhes = new List<string>();
            for (int i = 1; i <= 17; i++)
            {
                viTriGhes.Add($"A{i}");
            }
            for (int i = 1; i <= 17; i++)
            {
                viTriGhes.Add($"B{i}");
            }
            var danhSachVeXe = new List<Vexe>();
            
            foreach (var idChuyenXe in chuyenXeChuaCoVe)
            {
                foreach (var viTriGhe in viTriGhes)
                {
                    var veXe = new Vexe
                    {
                        IdChuyenXe = idChuyenXe,
                        ViTriGhe = viTriGhe,
                        TrangThai = true
                    };

                    danhSachVeXe.Add(veXe);
                }
            }
            try
            {
                foreach (var veXe in danhSachVeXe)
                {
                    await _unitOfWork.vexes.AddAsync(veXe);
                    await _unitOfWork.SaveChangesAsync(); // Lưu từng vé một

                }        
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }
}
