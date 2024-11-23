using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services
{
    public class ChuyenXeService 
    {
        IUnitOfWork _unitOfWork;

        public ChuyenXeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Chuyenxe>> GetAllChuyenXe()
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetAllChuyenXeVM();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ChuyenXeVM>> GetAllChuyenXeVM()
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetAllChuyenXeVM();
                var result = data.Select(cx => new ChuyenXeVM
                {
                    IdChuyenXe = cx.IdChuyenXe,
                    ThoiGianKh = cx.ThoiGianKh,
                    ThoiGianDen = cx.ThoiGianDen,
                    TrangThai = cx.TrangThai,
                
                    XeVM = cx.IdXeNavigation == null ? null : new XeVM
                    {
                        BienSo = cx.IdXeNavigation?.BienSo,
                        TinhTrang = cx.IdXeNavigation?.TinhTrang,
                    
                        LoaiXeVM = cx.IdXeNavigation?.IdLoaiNavigation == null ? null : new LoaiXeVM
                        {
                            TenLoai = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai,
                            SoGhe = cx.IdXeNavigation?.IdLoaiNavigation?.SoGhe
                        } 
                    },
                
                    TuyenDuongVM = cx.IdXeNavigation == null ? null : new TuyenDuongVM
                    {
                        TenBenXe = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe,
                        NoiDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        NoiKhoiHanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach,
                        GiaVe = cx.IdTuyenDuongNavigation?.GiaVe
                    } 
                });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Chuyenxe> GetChuyenXeByID(int id)
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<ChuyenXeVM>> GetByPageAsync(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;

            var totalRecords = await _unitOfWork.chuyenXeRepository.CountAsync();
            
            var chuyenXes = await _unitOfWork.chuyenXeRepository.GetPagedAsync(skip, pageSize);

            var data = chuyenXes.Select(cx => new ChuyenXeVM
            {
                IdChuyenXe = cx.IdChuyenXe,
                ThoiGianKh = cx.ThoiGianKh,
                ThoiGianDen = cx.ThoiGianDen,
                TrangThai = cx.TrangThai,
                
                XeVM = cx.IdXeNavigation == null ? null : new XeVM
                {
                    BienSo = cx.IdXeNavigation?.BienSo,
                    TinhTrang = cx.IdXeNavigation?.TinhTrang,
                    
                    LoaiXeVM = cx.IdXeNavigation?.IdLoaiNavigation == null ? null : new LoaiXeVM
                    {
                        TenLoai = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai,
                        SoGhe = cx.IdXeNavigation?.IdLoaiNavigation?.SoGhe
                    } 
                },
                
                TuyenDuongVM = cx.IdXeNavigation == null ? null : new TuyenDuongVM
                {
                    TenBenXe = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe,
                    NoiDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                    NoiKhoiHanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                    KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach,
                    GiaVe = cx.IdTuyenDuongNavigation?.GiaVe
                } 
            }).ToList();
        
            return new PagedList<ChuyenXeVM>(data, pageNumber, (int)Math.Ceiling((double)totalRecords / pageSize));
        }

        public async Task<bool> AddChuyenXe(Chuyenxe chuyenxe)
        {
            try
            {
                await _unitOfWork.chuyenXeRepository.AddAsync(chuyenxe);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateChuyenXe(Chuyenxe chuyenxe)
        {
            try
            {
                await _unitOfWork.chuyenXeRepository.UpdateAsync(chuyenxe);
                return await _unitOfWork.SaveChangesAsync()>0;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteChuyenXe(int id)
        {
            return await _unitOfWork.chuyenXeRepository.DeleteAsync(id);
        }
    }
}
