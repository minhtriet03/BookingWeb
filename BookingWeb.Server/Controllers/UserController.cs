using BookingWeb.Server.Models;
using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;

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

        [HttpGet]
        public async Task<ActionResult<List<UserVM>>> GetAllUsers()
        {
            try
            {
                var data = await _userService.GetAllUsers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Nguoidung user)
        {
            if (user == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ");
            }

            try
            {
                bool result = await _userService.AddUserAsync(user);
                if (result)
                {
                    return Ok("Thêm người dùng thành công");
                }
                else
                {
                    return StatusCode(500, "Lỗi đỏ chét luôn kìa thằng ngu");
                }
            }
            catch (InvalidOperationException ex)
            {
                // Trả lại lỗi khi email hoặc số điện thoại đã tồn tại
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Trả lại lỗi khi có lỗi ngoài ý muốn
                return StatusCode(500, "Đã xảy ra lỗi: " + ex.Message);
            }
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deleteuser(int userId)
        {
            try
            {
                bool result = await _userService.DeleteUserAsync(userId);

                if (result)
                    return Ok("Xóa người dùng thành công");

                return NotFound("Không tìm thấy người dùng");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}