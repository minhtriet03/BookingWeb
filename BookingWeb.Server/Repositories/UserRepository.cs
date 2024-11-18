using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class UserRepository : GenericRepository<Nguoidung>, IUserRepository
    {
        private IUserRepository _userRepositoryImplementation;

        public UserRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<Nguoidung> GetByUsername(string username)
        {
            return await _dbContext.Set<Nguoidung>().FirstOrDefaultAsync(u => u.HoTen == username);
        }
        
        public async Task<List<Nguoidung>> GetPagedAsync(int skip, int take)
        {
            return await _dbContext.Nguoidungs
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        
        public async Task<int> CountAsync()
        {
            return await _dbContext.Nguoidungs.CountAsync();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _dbContext.Set<Nguoidung>().AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsPhoneExist(string phone)
        {
            return await _dbContext.Set<Nguoidung>().AnyAsync(u => u.Phone == phone);
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