using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Repositories;

public class OrderRepository : GenericRepository<Phieudat>, IOrderRepository
{
    public OrderRepository(BookingBusContext dbContext) : base(dbContext)
    {
    }
}