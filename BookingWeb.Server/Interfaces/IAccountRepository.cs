using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IAccountRepository : IGenericRepository<Taikhoan>
{
    Task<Taikhoan> GetByUsername(string username);
}