using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Phanquyen>
    {
         Task<Phanquyen> GetByRoleName(string roleName);
    }
}
