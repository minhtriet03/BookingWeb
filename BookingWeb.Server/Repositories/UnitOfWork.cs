using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly BookingBusContext _context;
 
    public UnitOfWork(BookingBusContext context, 
                                  IBenXeRepository benxe, 
                                  ITinhRepository tinh, 
                                  IVitriRepository vitri,
                                  IVexeRepository vexe, 
                                  IUserRepository userRepository, 
                                  IOrderRepository orderRepository, 
                                  ILoaiXeRepository loaiXeRepository, 
                                  IXeRepository xeRepository, 
                                  IAccountRepository accountRepository,
                                  ITuyenDuongRepository tuyenDuongRepository,
                                IChuyenXeRepository chuyenXeRepository
        )
    {
        _context = context;
        this.benXes = benxe;
        this.vitris = vitri;
        this.tinhs = tinh;
        this.vexes = vexe;
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
        this.accountRepository = accountRepository;
        this.loaiXeRepository = loaiXeRepository;
        this.xeRepository = xeRepository;
        this.tuyenDuongRepository = tuyenDuongRepository;
        this.chuyenXeRepository = chuyenXeRepository;
    }
    public IBenXeRepository benXes { get; set; }
    public ITinhRepository tinhs { get; set; }
    public IVitriRepository vitris { get; set; }
    public IVexeRepository vexes { get; set; }

    public IUserRepository userRepository {get; private set; }
    public IOrderRepository orderRepository {get; private set; }

    public IAccountRepository accountRepository { get; private set; }

    public ILoaiXeRepository loaiXeRepository {get; private set; }

    public IXeRepository xeRepository {get; private set; }

    public IChuyenXeRepository chuyenXeRepository { get; private set; }

    public ITuyenDuongRepository tuyenDuongRepository { get; private set; }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}