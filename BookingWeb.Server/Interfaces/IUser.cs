using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IUser : IGeneric<Nguoidung>
{
    Task<Nguoidung> GetByUsername(string username);
}