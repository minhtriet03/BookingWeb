using BookingWeb.Server.Models;
using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Services;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Nguoidung user)
        {
            try
            {
                if (id != user.IdUser)
                {
                    return BadRequest("Id không khớp");
                }

                var result = await _userService.UpdateUserAsync(user);

                if (result)
                    return Ok("Cập nhật thành công");

                return NotFound("Không tìm thấy người dùng");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Có lỗi xảy ra khi cập nhật người dùng");
            }
        }
        
    }
}