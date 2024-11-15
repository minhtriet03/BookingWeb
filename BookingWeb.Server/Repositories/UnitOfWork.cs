using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly BookingBusContext _context;
    public IUserRepository userRepository {get; private set; }
    public IOrderRepository orderRepository {get; private set; }

    public UnitOfWork(BookingBusContext context, IUserRepository userRepository, IOrderRepository orderRepository)
    {
        _context = context;
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}