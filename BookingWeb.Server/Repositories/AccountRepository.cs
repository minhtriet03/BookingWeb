using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class AccountRepository : GenericRepository<Taikhoan>, IAccountRepository
    {
        private readonly PasswordHasher<Taikhoan> _passwordHasher;

        public AccountRepository(BookingBusContext dbContext) : base(dbContext)
        {
            _passwordHasher = new PasswordHasher<Taikhoan>();

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

        public async Task<bool> IsUsernameExist(string username)
        {
            return await _dbContext.Taikhoans.AnyAsync(u => u.UserName == username);
        }

        public async Task<bool> IsAccountExist(int id)
        {
            return await _dbContext.Taikhoans.AnyAsync(u => u.IdAccount == id);
        }

        public async Task<bool> Register(Taikhoan user)
        {
            try
            {
                user.Password = _passwordHasher.HashPassword(user, user.Password);
                await _dbContext.Taikhoans.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Login(string userName, string password)
        {
            var user = await _dbContext.Taikhoans.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return false;
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePassword(int id, string oldPassword, string newPassword)
        {
            var user = await _dbContext.Taikhoans.FirstOrDefaultAsync(u => u.IdAccount == id);

            if (user == null)
            {
                return false;
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, oldPassword) == PasswordVerificationResult.Success)
            {
                user.Password = _passwordHasher.HashPassword(user, newPassword);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}