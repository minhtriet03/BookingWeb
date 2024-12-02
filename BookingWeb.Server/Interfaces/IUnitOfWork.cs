namespace BookingWeb.Server.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBenXeRepository benXes { get; set; }
    ITinhRepository tinhs { get; set; }
    IVitriRepository vitris { get; set; }
    IVexeRepository vexes { get; set; }


    IUserRepository userRepository { get; }
    IOrderRepository orderRepository { get; }

    IAccountRepository accountRepository { get; }
    ILoaiXeRepository loaiXeRepository { get; }
    IXeRepository xeRepository { get; }
    IChuyenXeRepository chuyenXeRepository { get; }
    ITuyenDuongRepository tuyenDuongRepository { get; }
    Task<int> SaveChangesAsync();
    
}