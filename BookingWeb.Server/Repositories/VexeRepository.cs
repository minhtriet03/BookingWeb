using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class VexeRepository : GenericRepository<Vexe>, IVexeRepository
    {

        public VexeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Vexe>> getAll()
        {
            return await _dbContext.Vexes.ToListAsync();
        }

        public async Task<List<Vexe>> GetByIdPhieuAsync(int idPhieu)
        {
            var vexeList = await _dbContext.Vexes
                .Where(v => v.IdPhieu == idPhieu)
                .Include(v => v.IdChuyenXeNavigation)
                    .ThenInclude(c => c.IdTuyenDuongNavigation)
                        .ThenInclude(t => t.NoiKhoiHanhNavigation)
                    .Include(v => v.IdChuyenXeNavigation)
                        .ThenInclude(c => c.IdTuyenDuongNavigation)
                        .ThenInclude(t => t.NoiDenNavigation)
                    .Include(v => v.IdChuyenXeNavigation)
                        .ThenInclude(c => c.IdXeNavigation)
                .ToListAsync();

            return vexeList;
        }

        //public async Task CreateTickketByChuyen(int idChuyen)
        //{

        //}

        public async Task<List<Vexe>> GetByPageAsync(int pageNumber, int pageSize)
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


        public async Task<Vexe> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Vexes
                    .FirstOrDefaultAsync(v => v.IdVe == id); 
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Vexe>> getbyStatus(bool Status)
        {
            try
            {
                var data = await _dbContext.Vexes
                .Where(v => v.TrangThai == Status)
                .ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
        public async Task<bool> deleteVexe(int id)
        {
            try
            {
                var vexe = await _dbContext.Vexes.FirstOrDefaultAsync(u => u.IdVe == id);
                if (vexe != null)
                {
                    vexe.TrangThai = false;
                    _dbContext.Vexes.Update(vexe);
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
