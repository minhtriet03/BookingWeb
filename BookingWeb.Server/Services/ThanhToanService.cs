using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Services
{
    public class ThanhToanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThanhToanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Thanhtoan thanhtoan)
        {
            try
            {
                await _unitOfWork.thanhToanRepository.AddAsync(thanhtoan);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
