using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace BookingWeb.Server.Repositories
{
    public class TinhRepository : GenericRepository<Tinhthanh>, ITinhRepository
    {
        private IUnitOfWork _unitOfWork;
        public TinhRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<Tinhthanh> GetbyNameAsync(string name)
        {
            return await _dbContext.Set<Tinhthanh>().FirstOrDefaultAsync(u => u.TenTinhThanh == name);
        }

        public async Task<List<Tinhthanh>> GetByPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> deleteTinh(int id)
        {

            try
            {
                var tinh = await _dbContext.Tinhthanhs.FirstOrDefaultAsync(u => u.IdTinhThanh == id);
                if (tinh != null)
                {
                    tinh.TrangThai = false;
                    await _unitOfWork.tinhs.UpdateAsync(tinh);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
