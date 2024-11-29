using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using BookingWeb.Server.Dto;
namespace BookingWeb.Server.Services
{
    public class TuyenDuongService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TuyenDuongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tuyenduong>> GetAllTuyenDuong()
        {
            try
            {
                var listTuyenDuong = await _unitOfWork.tuyenDuongRepository.GetAllAsync();

                return listTuyenDuong;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedTuyenDuongVM> GetTuyenDuongByPageAsync(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;

            var totalRecords = await _unitOfWork.tuyenDuongRepository.CountAsync();

            var tuyenDuongs = await _unitOfWork.tuyenDuongRepository.GetPagedAsync(skip, pageSize);

            var data = tuyenDuongs.Select(td => new TuyenDuongVM
            {
                IdTuyenDuong = td.IdTuyenDuong,
                TenBenXe = td.NoiKhoiHanhNavigation?.TenBenXe,
                NoiDen = td.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                NoiKhoiHanh = td.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                KhoangCach = td.KhoangCach,
                GiaVe = td.GiaVe,
                TrangThai = td.TrangThai
            }).ToList();

            return new PagedTuyenDuongVM
            {
                TuyenDuongs = data,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }


        public async Task<Tuyenduong> GetTuyenDuongById(int id)
        {
            try
            {
                var tuyenDuong = await _unitOfWork.tuyenDuongRepository.GetByIdAsync(id);
                return tuyenDuong;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddTuyenDuong(Tuyenduong tuyenduong)
        {
            try
            {
                await _unitOfWork.tuyenDuongRepository.AddAsync(tuyenduong);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateTuyenDuong(Tuyenduong tuyenduong)
        {
            try
            {
                await _unitOfWork.tuyenDuongRepository.UpdateAsync(tuyenduong);

                return await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            try
            {
                var td = await _unitOfWork.tuyenDuongRepository.GetByIdAsync(id);
                if (td == null)
                {
                    throw new InvalidOperationException("Id không tồn tại");
                }

                td.TrangThai = !td.TrangThai;

                await _unitOfWork.tuyenDuongRepository.UpdateAsync(td);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public async Task<bool> DeleteTuyenDuong(int id)
        {
            return await _unitOfWork.tuyenDuongRepository.DeleteAsync(id);
        }

        public async Task<List<ChuyenxeDetailDto>> GetLichtrinhAsync(int skip, int take)
        {
            return await _unitOfWork.tuyenDuongRepository.GetLichtrinhAsync( skip,take);
        }
    }
}
