using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IUserRepository : IGenericRepository<Nguoidung>
{
    Task<Nguoidung> GetByUsername(string username);

    Task<bool> IsEmailExist(string email);

    Task<bool> IsPhoneExist(string phone);
    //Task<bool> UpdateUserAsync(Nguoidung user);
}