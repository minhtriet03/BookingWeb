using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class TinhRepository : GenericRepository<Tinhthanh>,ITinhRepository
    {
        private ITinhRepository _tinhRepository;
        public TinhRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<Tinhthanh> GetbyNameAsync(string name)
        {
            return await _dbContext.Set<Tinhthanh>().FirstOrDefaultAsync(u => u.TenTinhThanh == name);
        }

    }
}
