using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IBenXeRepository : IGenericRepository<Benxe>
    {
        Task<Benxe> GetByName(string name);
        Task<bool> deleteBenxe(int id);
    }
}
