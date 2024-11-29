using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using BookingWeb.Server.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
        }


        [HttpGet("user-login")]
        public async Task<IActionResult> FindById()
        {
            var idAccount = MiddleWare.GetUserIdFromCookie(Request);
            Console.WriteLine("day la Idaccount" + idAccount);
            if (idAccount == -1) return null;
            var user = await _userService.GetUserByIdAccount(idAccount);
            Console.WriteLine("day la user" + user);
            return Ok(new { userInfo = user});
        }

        [HttpGet]
        public async Task<ActionResult<List<UserVM>>> GetAllUsers()
        {
            try
            {
                var data = await _userService.GetAllUsers();
                /*var data = await _unitOfWork.userRepository.GetAllAsync();*/
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
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
        

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] Nguoidung user)
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