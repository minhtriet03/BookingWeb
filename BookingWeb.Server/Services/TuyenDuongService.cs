using BookingWeb.Server.Dto;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services
{
    public class TuyenDuongService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TuyenDuongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Toàn viết để Toàn lấy thêm mấy cái navigation
        public async Task<List<Tuyenduong>> GetAllTuyenDuongAsync()
        {
            try
            {
                var listTuyenDuong = await _unitOfWork.tuyenDuongRepository.GetAllTuyenDuongVMAsync();

                return listTuyenDuong;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Toàn sửa cái IEnumable thành List rồi nha Híu, do Toàn chạy thấy nó bị lỗi mà đổi sang List thì không lôỗi
        public async Task<List<Tuyenduong>> GetAllTuyenDuong()
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
            
            Console.WriteLine(totalRecords);
            
            var tuyenDuongs = await _unitOfWork.tuyenDuongRepository.GetPagedAsync(skip, pageSize);

            var data = tuyenDuongs.Select(td => new TuyenDuongVM
            {
                IdTuyenDuong = td.IdTuyenDuong,
                IdDiemDen = td.NoiDenNavigation.IdTinhThanh,
                IdDiemDi = td.NoiKhoiHanhNavigation.IdTinhThanh,
                IdBenXeDi = td.NoiKhoiHanh,
                IdBenXeDen = td.NoiDen,
                TenBenXeDi = td.NoiKhoiHanhNavigation.TenBenXe,
                TenBenXeDen = td.NoiDenNavigation.TenBenXe,
                NoiDen = td.NoiDenNavigation.IdTinhThanhNavigation.TenTinhThanh,
                NoiKhoiHanh = td.NoiKhoiHanhNavigation.IdTinhThanhNavigation.TenTinhThanh,
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


        public async Task<TuyenDuongVM> GetTuyenDuongById(int id)
        {
            try
            {
                var tuyenDuong = await _unitOfWork.tuyenDuongRepository.GetByIdAsync(td => td.IdTuyenDuong == id,
                                        td => td.NoiDenNavigation, 
                                                                    td=> td.NoiKhoiHanhNavigation);
                
                var tuyenDuongVM = new TuyenDuongVM
                {
                    IdTuyenDuong = tuyenDuong.IdTuyenDuong,
                    IdDiemDen = tuyenDuong.NoiDen,
                    IdDiemDi = tuyenDuong.NoiKhoiHanh,
                    IdBenXeDen = tuyenDuong.NoiDenNavigation.IdBenXe,
                    IdBenXeDi = tuyenDuong.NoiKhoiHanhNavigation.IdBenXe,
                    NoiDen = tuyenDuong.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                    NoiKhoiHanh = tuyenDuong.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                    KhoangCach = tuyenDuong.KhoangCach,
                    GiaVe = tuyenDuong.GiaVe,
                    TrangThai = tuyenDuong.TrangThai
                };
                
                return tuyenDuongVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TuyenDuongVM> GetTuyenDuongByConditionAsync(int idNoiDi, int idNoiDen)
        {
            try
            {
                var data = await _unitOfWork.tuyenDuongRepository.GetByConditionAsync(td => td.NoiDen == idNoiDen && td.NoiKhoiHanh == idNoiDi);
                if (data == null)
                {
                    return null;
                }

                var tuyenDuongVM =  data.Select(td => new TuyenDuongVM
                {
                    IdTuyenDuong = td.IdTuyenDuong,
                    IdDiemDen = td.NoiDen,
                    IdDiemDi = td.NoiKhoiHanh,
                    KhoangCach = td.KhoangCach,
                    GiaVe = td.GiaVe,
                    TrangThai = td.TrangThai
                }).FirstOrDefault();;

                return tuyenDuongVM;
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

        public async Task<bool> UpdateTuyenDuong(Tuyenduong tuyenduong)
        {
            try
            {
                var result =  await _unitOfWork.tuyenDuongRepository.UpdateAsync(tuyenduong);

                if (!result)
                {
                    return false;
                }

                await _unitOfWork.SaveChangesAsync();

                return true;

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

        public async Task<List<ChuyenxeDetailDto>> GetLichtrinhAsync(int skip, int take) { 
            return await _unitOfWork.tuyenDuongRepository.GetLichtrinhAsync(skip, take); 
        }
    }
}