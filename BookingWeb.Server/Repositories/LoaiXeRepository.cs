using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.Server.Repositories
{
    public class LoaiXeRepository : ILoaiXeRepository
    {
        private readonly BookingBusContext _context;

        public LoaiXeRepository(BookingBusContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Loaixe entity)
        {
            try
            {
                await _context.Loaixes.AddAsync(entity);  // Thêm loại xe vào cơ sở dữ liệu
                await _context.SaveChangesAsync();  // Lưu thay đổi
                return true;  // Trả về true nếu thêm thành công
            }
            catch (Exception)
            {
                return false;  // Trả về false nếu có lỗi
            }
        }

        public async Task<bool> UpdateAsync(Loaixe entity)
        {
            try
            {
                _context.Loaixes.Update(entity);  // Cập nhật loại xe
                await _context.SaveChangesAsync();  // Lưu thay đổi
                return true;  // Trả về true nếu cập nhật thành công
            }
            catch (Exception)
            {
                return false;  // Trả về false nếu có lỗi
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Loaixes.FindAsync(id);  // Tìm đối tượng Loaixe theo id
                if (entity == null)
                {
                    return false; // Không tìm thấy Loaixe để xóa
                }

                _context.Loaixes.Remove(entity);  // Xóa loại xe
                await _context.SaveChangesAsync();  // Lưu thay đổi
                return true;  // Trả về true nếu xóa thành công
            }
            catch (Exception)
            {
                return false;  // Trả về false nếu có lỗi
            }
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<List<Loaixe>> GetAllAsync()
        {
            return await _context.Loaixes.Include(l => l.Xes).ToListAsync();  // Lấy tất cả loại xe
        }

        public async Task<Loaixe> GetByIdAsync(int id)
        {
            return await _context.Loaixes.Include(l => l.Xes).FirstOrDefaultAsync(l => l.IdLoai == id);  // Lấy loại xe theo id
        }
    }
}
