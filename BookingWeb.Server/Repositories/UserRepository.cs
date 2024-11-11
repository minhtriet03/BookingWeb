using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class UserRepository : GenericRepository<Nguoidung>, IUserRepository
    {
        public UserRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<Nguoidung> GetByUsername(string username)
        {
            return await _dbContext.Set<Nguoidung>().FirstOrDefaultAsync(u => u.HoTen == username);
        }

        //public async Task<bool> UpdateUserAsync(Nguoidung user)
        //{
        //    try
        //    {
        //        var existingUser = await _dbContext.Nguoidungs.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);

        //        if (existingUser == null)
        //        {
        //            return false;
        //        }

        //        existingUser.HoTen = user.HoTen;
        //        existingUser.DiaChi = user.DiaChi;
        //        existingUser.Email = user.Email;
        //        existingUser.Phone = user.Phone;
        //        existingUser.Role = user.Role;

        //        await _dbContext.SaveChangesAsync();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        
        

    }
}