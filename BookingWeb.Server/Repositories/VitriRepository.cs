using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class VitriRepository : GenericRepository<Vitri>, IVitriRepository
    {
        private IUnitOfWork _unitOfWork;

        public VitriRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Vitri>> getByIdXe(int id)
        {
            return await _unitOfWork.vitris.GetAllAsync();
        }
        public async Task<bool> AddAsync(Vitri vitri)
        {
            try
            {
                await _unitOfWork.vitris.AddAsync(vitri);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Vitri to database", ex);
            }
        }
        public async Task<bool> deleteVitri(int id)
        {
            try
            {
                var vitri = await _dbContext.Vitris.FirstOrDefaultAsync(u => u.IdViTriGhe == id);
                if (vitri != null)
                {
                    vitri.TrangThai = false;
                    await _unitOfWork.vitris.UpdateAsync(vitri);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
