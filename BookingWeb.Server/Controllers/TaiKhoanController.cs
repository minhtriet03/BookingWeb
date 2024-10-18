using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanController : ControllerBase
    {
        private readonly BookingBusContext _context;

        public TaikhoanController(BookingBusContext context)
        {
            _context = context;
        }

        // Đăng ký tài khoản
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Taikhoan taikhoan)
        {
            if (taikhoan == null || string.IsNullOrWhiteSpace(taikhoan.UserName) || string.IsNullOrWhiteSpace(taikhoan.Password))
            {
                return BadRequest("Invalid user data.");
            }

            // Kiểm tra xem tài khoản đã tồn tại hay chưa
            var existingUser = await _context.Taikhoans.AnyAsync(u => u.UserName == taikhoan.UserName);
            if (existingUser)
            {
                return Conflict("User already exists.");
            }

            // Thêm tài khoản vào cơ sở dữ liệu
            _context.Taikhoans.Add(taikhoan);
            await _context.SaveChangesAsync();

            return Ok(taikhoan);
        }

        // Đăng nhập
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Taikhoan taikhoan)
        {
            if (taikhoan == null || string.IsNullOrWhiteSpace(taikhoan.UserName) || string.IsNullOrWhiteSpace(taikhoan.Password))
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _context.Taikhoans
                .FirstOrDefaultAsync(u => u.UserName == taikhoan.UserName && u.Password == taikhoan.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(user);
        }
    }
}
