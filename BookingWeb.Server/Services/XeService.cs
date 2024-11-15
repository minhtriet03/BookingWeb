using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using System.Security.AccessControl;

namespace BookingWeb.Server.Services
{
    public class XeService 
    {
        private readonly IXeRepository _xerepository;

        public XeService (IXeRepository repository)
        {
            _xerepository = repository;
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<List<Xe>> GetAllXes()
        {
            return await _xerepository.GetAllAsync();
        }

        // Sử dụng async để gọi phương thức bất đồng bộ trong repository
        public async Task<Xe> Getxe(int id)
        {
            return await _xerepository.GetByIdAsync(id);
        }
        public async Task<bool> Addxe(Xe xe)
        {
            return await _xerepository.AddAsync(xe);
        }
        public async Task<bool> Updatexe(Xe xe)
        {
            return await _xerepository.UpdateAsync(xe);
        }

        public async Task<bool> Deletexe(int id)
        {
            return await _xerepository.DeleteAsync(id);
        }
    }
}
