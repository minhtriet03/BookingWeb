using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using System.Security.AccessControl;

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
    }
}
