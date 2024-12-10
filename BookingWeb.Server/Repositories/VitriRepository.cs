using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class VitriRepository : GenericRepository<Vitri>, IVitriRepository
    {

        public VitriRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

       
        public async Task AddRangeAsync(IEnumerable<Vitri> vitris)
        {
            await _dbContext.Vitris.AddRangeAsync(vitris);
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

        public async Task<bool> AnyAsync()
        {
            return await _dbContext.Vitris.AnyAsync();
        }
    }
}
