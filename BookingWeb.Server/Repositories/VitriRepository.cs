using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class VitriRepository : GenericRepository<Vitri>, IVitriRepository
    {
        private IVitriRepository _vitriRepository;

        public VitriRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Vitri>> getByIdXe(int id)
        {
            return await _dbContext.Set<Vitri>()
                .Where(v => v.IdXe == id) 
                .ToListAsync();
        }
        public async Task<bool> AddAsync(Vitri vitri)
        {
            try
            {
                await _dbContext.Vitris.AddAsync(vitri);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Vitri to database", ex);
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                var vitri = await _dbContext.Vitris.FirstOrDefaultAsync(u => u.IdViTriGhe == id);
                if (vitri != null)
                {
                    _dbContext.Vitris.Remove(vitri);
                    await _dbContext.SaveChangesAsync();
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
