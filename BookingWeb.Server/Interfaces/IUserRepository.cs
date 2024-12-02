using BookingWeb.Server.Models;
namespace BookingWeb.Server.Interfaces;

public interface IUserRepository : IGenericRepository<Nguoidung>
{
    Task<Nguoidung> GetByUsername(string username);

    Task<Nguoidung> GetByIdAccount(int IdAccount);

    Task<List<Nguoidung>> GetPagedAsync(int skip, int take);
    
    Task<int> CountAsync();
    
    Task<bool> IsEmailExist(string email);

    Task<bool> IsPhoneExist(string phone);
}