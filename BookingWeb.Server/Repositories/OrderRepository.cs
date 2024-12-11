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
}