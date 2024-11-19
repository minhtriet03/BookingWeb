using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class BenXeRepository : GenericRepository<Benxe>,IBenXeRepository
    {
        private readonly IBenXeRepository _benxeRepository;
        public BenXeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }
        public async Task<Benxe> GetByName(String name)
        {
            return await _dbContext.Set<Benxe>().FirstOrDefaultAsync(u => u.TenBenXe == name);
        }
    }
