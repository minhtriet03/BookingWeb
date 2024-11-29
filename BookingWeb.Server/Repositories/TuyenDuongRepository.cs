using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class TuyenDuongRepository : GenericRepository<Tuyenduong>, ITuyenDuongRepository
    {
        public TuyenDuongRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Tuyenduong>> GetPagedAsync(int skip, int take)
        {
            return await _dbContext.Tuyenduongs
                .Include(td => td.NoiKhoiHanhNavigation)
                    .ThenInclude(nkh => nkh.IdTinhThanhNavigation)
                .Include(td => td.NoiDenNavigation)
                    .ThenInclude(nd => nd.IdTinhThanhNavigation)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<List<Tuyenduong>> GetAllTuyenDuongVMAsync()
        {
            return await _dbContext.Tuyenduongs
                .Include(td => td.NoiKhoiHanhNavigation)
                    .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .Include(td => td.NoiDenNavigation)
                    .ThenInclude(bx => bx.IdTinhThanhNavigation)
                .ToListAsync();
        }
    }
}
