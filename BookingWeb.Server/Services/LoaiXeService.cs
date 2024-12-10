using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services
{
    public class LoaiXeService
    {   
        
        private readonly IUnitOfWork _unitOfWork;

        public LoaiXeService(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        
        public async Task<List<Loaixe>> GetTrangThaiByConditionAsync()
        {
            return await _unitOfWork.loaiXeRepository.GetByConditionAsync(lx => lx.TrangThai == true);
        }
        
        public async Task<Loaixe> GetByIdAsync(int id)
        {
            return await _unitOfWork.loaiXeRepository.GetByIdAsync(id);
        }
        
        public async Task<List<Loaixe>> GetAllLoaiXes()
        {
            return await _unitOfWork.loaiXeRepository.GetAllAsync();
        }
        


        public async Task<PagedLoaiXeVM> GetByPageAsync(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;

            var totalRecords = await _unitOfWork.loaiXeRepository.CountAsync();

            var loaiXes = await _unitOfWork.loaiXeRepository.GetPagedAsync(skip, pageSize);
            
            var data = loaiXes.Select(lx => new LoaiXeVM
            {
                IdLoai = lx.IdLoai,
                SoGhe = lx.SoGhe,
                TenLoai = lx.TenLoai,
                TrangThai = lx.TrangThai,
            }).ToList();

            return new PagedLoaiXeVM
            {
                LoaiXes = data,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        } 

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<Loaixe> GetLoaixe(int id)
        {
            return await _unitOfWork.loaiXeRepository.GetByIdAsync(id);
        }
        public async Task<bool> AddLoaixe(Loaixe loaixe)
        {
            await _unitOfWork.loaiXeRepository.AddAsync(loaixe);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateLoaixe(Loaixe loaixe)
        {
            var data = await _unitOfWork.loaiXeRepository.UpdateAsync(loaixe);
            if (data == null)
            {
                return false;
            }
            
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLoaixe(int id)
        {
            return await _unitOfWork.loaiXeRepository.DeleteAsync(id);
        }
        public async Task<bool> DeactivateLoaiXeAsync(int id)
        {
            var data = await _unitOfWork.loaiXeRepository.GetByIdAsync(id);
            
            var result = await _unitOfWork.loaiXeRepository.DeactivateAsync(
                id,
                lx => lx.TrangThai == false || lx.TrangThai == true,
                lx => lx.TrangThai = !lx.TrangThai
            );
        
            await  _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
