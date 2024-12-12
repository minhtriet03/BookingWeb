using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Interfaces;

public interface IOrderRepository : IGenericRepository<Phieudat>
{
    Task<List<Phieudat>> GetByIdUser(int id);
    
}