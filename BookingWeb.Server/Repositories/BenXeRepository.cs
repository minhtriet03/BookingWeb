using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookingWeb.Server.Repositories
{
    public class BenXeRepository : GenericRepository<Benxe>, IBenXeRepository
    {
 
        public BenXeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }
        

        public async Task<Benxe> GetByName(String name)
        {
            return await _dbContext.Set<Benxe>().FirstOrDefaultAsync(u => u.TenBenXe == name);
        }

        public async Task<List<Benxe>> GetByPageAsync(int skip, int take)
        {
            return await _dbContext.Benxes
                .Include(bx => bx.IdTinhThanhNavigation)
                .Skip(skip) 
                .Take(take)                  
                .ToListAsync();                   
        }

        public async Task<bool> deleteBenxe(int id)
        {
            try
            {
                Benxe benxe = await _dbContext.Benxes.FirstOrDefaultAsync(u => u.IdBenXe == id);
                if (benxe != null)
                {
                    benxe.TrangThai = false;
                    _dbContext.Benxes.Update(benxe);
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
