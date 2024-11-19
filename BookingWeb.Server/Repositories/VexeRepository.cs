using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class VexeRepository : GenericRepository<Vexe>,IVexeRepository
    {
        private IUnitOfWork _unitOfWork;

        public VexeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Vexe>> getAll()
        {
            return await _unitOfWork.vexes.GetAllAsync();
        }

        public async Task<bool> addVeXe(Vexe vexe)
        {
            try
            {
                return await _unitOfWork.vexes.AddAsync(vexe);
            }
            catch
            {
                return false;
            }
        }

        public async Task<Vexe> getBydId(int id)
        {
            try
            {
                return await _unitOfWork.vexes.GetByIdAsync(id);
            }
            catch{
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
        
        public async Task<bool> update(Vexe vexe)
        {
            try
            {
                return await _unitOfWork.vexes.UpdateAsync(vexe);
            }
            catch (Exception ex)
            {
                return false;
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
                    await _unitOfWork.vexes.UpdateAsync(vexe);
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
