using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Interfaces
{
    public interface IXeRepository : IGenericRepository<Xe>
    {
        Task<List<XeVM>> GetAllXeVMsAsync();
        Task<int> CountAsync();
        Task<List<Xe>> GetPageAsync(int skip, int take);
    }
    

}
