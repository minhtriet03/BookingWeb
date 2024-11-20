using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Interfaces
{
    public interface IXeRepository : IGenericRepository<Xe>
    {
        Task<List<XeVM>> GetAllXeVMsAsync();
    }
    

}
