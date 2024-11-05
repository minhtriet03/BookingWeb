using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class UserRepository : GenericRepository<Nguoidung>, IUser
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Nguoidung> GetByUsername(string username)
        {
            return await _dbContext.Set<Nguoidung>().FirstOrDefaultAsync(u => u.HoTen == username);
        }

    }
}