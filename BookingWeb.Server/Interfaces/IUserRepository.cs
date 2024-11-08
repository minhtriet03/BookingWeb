using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IUserRepository : IGenericRepository<Nguoidung>
{
    Task<Nguoidung> GetByUsername(string username);
}