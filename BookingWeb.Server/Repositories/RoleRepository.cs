using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class RoleRepository : GenericRepository<Phanquyen>, IRoleRepository
    {
        public RoleRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<Phanquyen> GetByRoleName(string roleName)
        {
            return await _dbContext.Set<Phanquyen>().FirstOrDefaultAsync(u => u.TenQuyen == roleName);
        }

        public async Task<bool> AddAsync(Phanquyen role)
        {
            try
            {
                await _dbContext.Phanquyens.AddAsync(role);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Phanquyen role)
        {
            try
            {
                var existingRole = await _dbContext.Phanquyens.FirstOrDefaultAsync(u => u.IdQuyen == role.IdQuyen);

                if (existingRole == null)
                {
                    return false;
                }

                existingRole.TenQuyen = role.TenQuyen;
                //existingRole.MoTa = role.MoTa;

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
                var role = await _dbContext.Phanquyens.FirstOrDefaultAsync(u => u.IdQuyen == id);
                if (role != null)
                {
                    _dbContext.Phanquyens.Remove(role);
                    await _dbContext.SaveChangesAsync();
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
