using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

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
                var data = await _unitOfWork.chuyenXeRepository.GetAllAsync();

                return data;
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
