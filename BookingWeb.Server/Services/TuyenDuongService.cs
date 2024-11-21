using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Services
{
    public class TuyenDuongService
    {
        IUnitOfWork _unitOfWork;
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

        public async Task<bool> DeleteTuyenDuong(int id)
        {
            return await _unitOfWork.tuyenDuongRepository.DeleteAsync(id);
        }
    }
}
