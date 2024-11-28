using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class XevitriRepository : GenericRepository<Xevitri>,IVitriXeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public XevitriRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Xevitri>> GetByPageAsync(int pageNumber,int pageSize)
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
      
    }
}
