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
                .Include(v => v.IdChuyenXeNavigation) // Chuyến xe mà vé thuộc về
                    .ThenInclude(c => c.IdTuyenDuongNavigation) // Tuyến đường của chuyến xe
                        .ThenInclude(t => t.NoiKhoiHanhNavigation) // Địa điểm khởi hành
                    .Include(v => v.IdChuyenXeNavigation)
                        .ThenInclude(c => c.IdTuyenDuongNavigation)
                        .ThenInclude(t => t.NoiDenNavigation) // Địa điểm đến
                    .Include(v => v.IdChuyenXeNavigation)
                        .ThenInclude(c => c.IdXeNavigation) // Xe của chuyến xe
                .ToListAsync();

            return vexeList;
        }

        public async Task CreateTickketByChuyen(int idChuyen)
        {
            // Lấy thông tin chuyến xe theo idChuyen
            var chuyenxe = await _dbContext.Chuyenxes
                .FirstOrDefaultAsync(c => c.IdChuyenXe == idChuyen);

            if (chuyenxe == null)
            {
                throw new Exception("Chuyến xe không tồn tại.");
            }


            var viTriGhe = GenerateTicketPositions();


            foreach (var pos in viTriGhe)
            {
                var newVexe = new Vexe
                {
                    IdChuyenXe = chuyenxe.IdChuyenXe, 
                    ViTriGhe = pos, 
                    TrangThai = true  
                };

                _dbContext.Vexes.Add(newVexe);  
            }

            await _dbContext.SaveChangesAsync();
        }

        private List<string> GenerateTicketPositions()
        {
            var positions = new List<string>();

            for (int i = 1; i <= 17; i++)
            {
                positions.Add($"A{i}");
                positions.Add($"B{i}");
            }

            return positions;
        }
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
        public async Task<List<Vexe>> GetByDateAsync()
        {
            var data = await _dbContext.Vexes
                .AsNoTracking()
                .Include(vx => vx.IdChuyenXeNavigation)
                    .ThenInclude(cx => cx.IdTuyenDuongNavigation)
                        .ThenInclude(td => td.NoiDenNavigation)
                            .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .Include(vx => vx.IdChuyenXeNavigation)
                    .ThenInclude(cx => cx.IdTuyenDuongNavigation)
                        .ThenInclude(td => td.NoiKhoiHanhNavigation)
                            .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .Include(vx => vx.IdChuyenXeNavigation)
                .ThenInclude(cx => cx.IdXeNavigation)
                .OrderByDescending(vx => vx.IdVe)

                .ToListAsync();

            return data;
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

        public async Task<List<int>> GetAllIDChuyenXeInVeXe()
        {
            return await _dbContext.Vexes
                .Select(vx => vx.IdChuyenXe)
                .Distinct()
                .ToListAsync();
        }
}
