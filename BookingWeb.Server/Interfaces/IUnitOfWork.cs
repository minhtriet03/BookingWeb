namespace BookingWeb.Server.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; }
    IOrderRepository orderRepository { get; }

    IAccountRepository accountRepository { get; }
    ILoaiXeRepository loaiXeRepository { get; }
    IXeRepository xeRepository { get; }
    IChuyenXeRepository chuyenXeRepository { get; }
    ITuyenDuongRepository tuyenDuongRepository { get; }
    Task<int> SaveChangesAsync();
    
}