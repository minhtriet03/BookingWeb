using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IAccountRepository : IGenericRepository<Taikhoan>
{
    Task<Taikhoan> GetByUsername(string username);
    Task<bool> IsUsernameExist(string username);
    Task<bool> IsAccountExist(int id);
    Task<bool> Register(Taikhoan user);
    Task<bool> Login(string userName, string password);
    Task<bool> UpdatePassword(int id, string oldPassword, string newPassword);

    Task<List<Taikhoan>> GetByPageAsync(int skip, int pageSize);
}