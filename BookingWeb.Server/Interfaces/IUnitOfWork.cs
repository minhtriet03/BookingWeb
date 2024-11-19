namespace BookingWeb.Server.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBenXeRepository benXes { get; set; }
    ITinhRepository tinhs { get; set; }
    IVitriRepository vitris { get; set; }
    Task<int> Complete();
}