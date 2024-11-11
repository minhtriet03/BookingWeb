using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class AccountRepository : GenericRepository<Taikhoan>, IAccountRepository
    {
        public AccountRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<Taikhoan> GetByUsername(string username)
        {
            return await _dbContext.Set<Taikhoan>().FirstOrDefaultAsync(u => u.UserName == username);
        }


        public async Task<bool> AddAsync(Taikhoan user)
        {
            try
            {
                await _dbContext.Taikhoans.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _dbContext.Taikhoans.FirstOrDefaultAsync(u => u.IdAccount == id);

                if (user == null)
                {
                    return false;
                }

                _dbContext.Taikhoans.Remove(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Taikhoan user)
        {
            try
            {
                var existingUser = await _dbContext.Taikhoans.FirstOrDefaultAsync(u => u.IdAccount == user.IdAccount);

                if (existingUser == null)
                {
                    return false;
                }

                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;

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