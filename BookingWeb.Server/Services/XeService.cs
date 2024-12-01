using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using System.Security.AccessControl;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services
{
    public class XeService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public XeService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<List<Xe>> GetAllXes()
        {
            return await _unitOfWork.xeRepository.GetAllAsync();
        }

        public async Task<PagedXeVM> GetXesByPageAsync(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;

            var totalRecords = await _unitOfWork.xeRepository.CountAsync();

            var xes = await _unitOfWork.xeRepository.GetPageAsync(skip, pageSize);
            var loaiXes = await _unitOfWork.loaiXeRepository.GetByConditionAsync(lx => lx.TrangThai == true);

            var data = xes.Select(x => new XeVM
            {
                IdXe = x.IdXe,
                BienSo = x.BienSo,
                TinhTrang = x.TinhTrang,
                LoaiXeVM = x.IdLoaiNavigation == null
                    ? null
                    : new LoaiXeVM
                    {
                        IdLoai = x.IdLoaiNavigation.IdLoai,
                        TenLoai = x.IdLoaiNavigation.TenLoai,
                        SoGhe = x.IdLoaiNavigation.SoGhe,
                        TrangThai = x.IdLoaiNavigation.TrangThai,
                    }
            }).ToList();
            
            var loaiXeVM = loaiXes.Select(lx => new LoaiXeVM
            {
                IdLoai = lx.IdLoai,
                SoGhe = lx.SoGhe,
                TenLoai = lx.TenLoai,
                TrangThai = lx.TrangThai,
            }).ToList();

            return new PagedXeVM
            {
                Xes = data,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                Loaixes = loaiXeVM
            };
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<Xe> Getxe(int id)
        {
            return await _unitOfWork.xeRepository.GetByIdAsync(id);
        }
        public async Task<bool> Addxe(Xe xe)
        {
            return await _unitOfWork.xeRepository.AddAsync(xe);
        }
        public async Task<bool> Updatexe(Xe xe)
        {
            return await _unitOfWork.xeRepository.UpdateAsync(xe);
        }

        public async Task<bool> Deletexe(int id)
        {
            return await _unitOfWork.xeRepository.DeleteAsync(id);
        }

        public async Task<bool> DeactivateXeAsync(int id)
        {
            try
            {
                var xe = await _unitOfWork.xeRepository.GetByIdAsync(id);
                if (xe == null)
                {
                    throw new InvalidOperationException("Id không tồn tại");
                }

                if (xe.TinhTrang == true)
                {
                    xe.TinhTrang = false;
                }
                else if (xe.TinhTrang == false)
                {
                    xe.TinhTrang = true;
                }
                await _unitOfWork.xeRepository.UpdateAsync(xe);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
