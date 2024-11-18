namespace BookingWeb.Server.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; }
    IOrderRepository orderRepository { get; }

    ILoaiXeRepository loaiXeRepository { get; }
    IXeRepository xeRepository { get; }

    IAccountRepository accountRepository { get; }

    ITuyenDuongRepository tuyenDuongRepository { get; }
    Task<int> SaveChangesAsync();
    
}