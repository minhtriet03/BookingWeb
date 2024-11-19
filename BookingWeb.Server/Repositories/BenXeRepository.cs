using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class BenXeRepository : GenericRepository<Benxe>, IBenXeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public BenXeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }
        public async Task<Benxe> GetByName(String name)
        {
            return await _dbContext.Set<Benxe>().FirstOrDefaultAsync(u => u.TenBenXe == name);
        }
     
       
        public async Task<bool> deleteBenxe(int id)
        {
            try
            {
                var benxe = await _dbContext.Benxes.FirstOrDefaultAsync(u => u.IdBenXe == id);
                if (benxe != null)
                {
                    benxe.TrangThai = false;
                    await _unitOfWork.benXes.UpdateAsync(benxe);
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
