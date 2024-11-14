using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.Server.Services
{
    public class LoaiXeService
    {
        private readonly ILoaiXeRepository _loaiXeRepository;

        public LoaiXeService(ILoaiXeRepository loaiXeRepository)
        {
            _loaiXeRepository = loaiXeRepository;
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<List<Loaixe>> GetAllLoaiXes()
        {
            return await _loaiXeRepository.GetAllAsync();
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<Loaixe> GetLoaixe(int id)
        {
            return await _loaiXeRepository.GetByIdAsync(id);
        }
        public async Task<bool> AddLoaixe(Loaixe loaixe)
        {
            return await _loaiXeRepository.AddAsync(loaixe);
        }
        public async Task<bool> UpdateLoaixe(Loaixe loaixe)
        {
            return await _loaiXeRepository.UpdateAsync(loaixe);
        }

        public async Task<bool> DeleteLoaixe(int id)
        {
            return await _loaiXeRepository.DeleteAsync(id);
        }
    }
}
