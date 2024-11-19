using BookingWeb.Server.Models;

namespace BookingWeb.Server.Interfaces
{
    public interface IVitriRepository :IGenericRepository<Vitri>
    {
        Task<List<Vitri>> getByIdXe(int id);
      
    }
}
