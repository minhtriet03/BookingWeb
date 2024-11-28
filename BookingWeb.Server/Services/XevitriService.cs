using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;

namespace BookingWeb.Server.Services
{
    public class XevitriService
    {
        private UnitOfWork _unitOfWork;
        public XevitriService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> addXeVtri(Xevitri xevitri)
        {
            try
            {
                await _unitOfWork.xevitris.AddAsync(xevitri);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Xevitri>> getByPage(int page)
        {
            try
            {
                return await _unitOfWork.xevitris.GetByPageAsync(page, 10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
