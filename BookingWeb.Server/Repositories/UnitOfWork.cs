using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly BookingBusContext _context;
  
    public IBenXeRepository benXes { get; set; }
    public ITinhRepository tinhs { get; set; }
    public IVitriRepository vitris { get; set; }
    public IVexeRepository vexes { get; set; }

    public UnitOfWork(BookingBusContext context,IBenXeRepository benxe, ITinhRepository tinh, IVitriRepository vitri, IVexeRepository vexe)
    {
        _context = context;
        benXes = benxe;
        vitris = vitri;
        tinhs = tinh;
        vexes = vexe;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
}