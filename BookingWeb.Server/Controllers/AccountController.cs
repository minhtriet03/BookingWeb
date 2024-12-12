using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BookingWeb.Server.Dto;
using Microsoft.AspNetCore.Identity;


namespace BookingWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;
        private readonly UserService _userService;

        public AccountController(AccountService accountService, UserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            return Ok();
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult PutAccount(int id)
        {
            return Ok();
        }


        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return Ok();
        }


        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] RegisterModel acc)
        {
            if (await _accountService.getAccountByUsername(acc.UserName) != null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }



            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            var passwordHasher = new PasswordHasher<Taikhoan>();

            var taikhoan = new Taikhoan
            {
                UserName = acc.UserName,
                Password = null, 
                IdQuyen = 1,
                TrangThai = true
            };

            Console.WriteLine("Password: " + acc.Password);

            taikhoan.Password = passwordHasher.HashPassword(taikhoan, acc.Password);

            Console.WriteLine("Password Hashed: " + taikhoan.Password);

            var result = await _accountService.addAccount(taikhoan);
            if (!result)
            {
                return BadRequest("Đăng ký tài khoản thất bại");
            }

            var savedAccount = await _accountService.getAccountByUsername(acc.UserName);
            if (savedAccount == null)
            {
                return BadRequest("Không thể tạo tài khoản");
            }

            var newUser = new Nguoidung
            {
                HoTen = null,
                Email = acc.UserName,
                DiaChi = null,
                Phone = null,
                TrangThai = true,
                IdAccount = savedAccount.IdAccount 
            };

            Console.WriteLine("New User: " + newUser.IdAccount + "Email: " + newUser.Email);
            var test = await _userService.AddUserRegister(newUser);
            Console.WriteLine("Test: " + test);

            return Ok("Đăng ký thành công");
        }


        // POST: api/Account/login
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginModel loginModel)
        {
            var taikhoan = await _accountService.getAccountByUsername(loginModel.Email);

            if (taikhoan == null || taikhoan.IdQuyen == 2)
            {
                return NotFound("Tài khoản không tồn tại");
            }

            var isPasswordCorrect = await _accountService.Login(loginModel.Email, loginModel.Password);
            if (!isPasswordCorrect)
            {
                return BadRequest("Mật khẩu không đúng");
            }

            // Tạo JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("IdAccount", taikhoan.IdAccount.ToString()),
            new Claim("UserName", taikhoan.UserName)
        }),
                Expires = DateTime.UtcNow.AddHours(9),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Lưu JWT vào cookies
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            Response.Cookies.Append("jwt", tokenString, cookieOptions);

            return Ok("Đăng nhập thành công");
        }

        // POST: api/Account/logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok("Đăng xuất thành công");
        }

        [HttpPost("changePass")]
        public async Task<ActionResult<bool>> ChangePass([FromBody] changePass request)
        {
            try
            {
               
                return await _accountService.UpdatePassword(request.Id, request.OldPassword, request.NewPassword);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
