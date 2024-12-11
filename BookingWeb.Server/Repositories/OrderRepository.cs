using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories;

public class OrderRepository : GenericRepository<Phieudat>, IOrderRepository
{
    public OrderRepository(BookingBusContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Phieudat>> GetByIdUser(int id)
    {
        try
        {
            var phieudats = await _dbContext.Phieudats
                                    .Where(p => p.IdUser == id)
                                    .ToListAsync();

            return phieudats;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}