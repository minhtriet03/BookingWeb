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

        public async Task<List<Vitri>> GetByPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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
      
    }
}
