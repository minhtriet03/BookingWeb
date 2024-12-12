using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class ThanhToanRepository : GenericRepository<Thanhtoan>, IThanhToanRepository { 
    
     public ThanhToanRepository(BookingBusContext dbContext) : base(dbContext)
     {

     }

        public async Task<bool> AddAsync(Thanhtoan thanhtoan)
        {
            try
            {
                await _dbContext.Thanhtoans.AddAsync(thanhtoan);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

}

