using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class XeRepository : IXeRepository
    {
        private readonly BookingBusContext _context;

        public XeRepository(BookingBusContext context)
        {
            _context = context;
        }

        // Triển khai phương thức GetAllAsync
        public async Task<List<Xe>> GetAllAsync()
        {
            return await _context.Xes.ToListAsync();
        }

        // Triển khai phương thức GetByIdAsync
        public async Task<Xe> GetByIdAsync(int id)
        {
            return await _context.Xes.FindAsync(id);
        }

        // Triển khai phương thức AddAsync
        public async Task<bool> AddAsync(Xe entity)
        {
            _context.Xes.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        // Triển khai phương thức UpdateAsync
        public async Task<bool> UpdateAsync(Xe entity)
        {
            _context.Xes.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        // Triển khai phương thức DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Xes.FindAsync(id);
            if (entity == null) return false;

            _context.Xes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

