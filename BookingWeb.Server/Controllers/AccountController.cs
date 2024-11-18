using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace BookingWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
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


        //POST: api/Account/register
        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] Taikhoan acc)
        {
            if ( await _accountService.getAccountByUsername(acc.UserName) != null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            Taikhoan taikhoan = new Taikhoan
            {
                UserName = acc.UserName,
                Password = acc.Password,
                IdQuyen = 1,
            };

            Console.WriteLine(taikhoan.IdAccount + taikhoan.IdQuyen +taikhoan.UserName + taikhoan.Password);

            bool result = await _accountService.Register(taikhoan);

            if (result)
            {
                return Ok("Đăng ký thành công");
            }

            return BadRequest("Đăng ký thất bại");
        }


        // POST: api/Account/login
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginModel loginModel)
        {
            Taikhoan taikhoan = await _accountService.getAccountByUsername(loginModel.Email);

            if (taikhoan == null)
            {
                return NotFound("Tài khoản không tồn tại");
            }

            var isPasswordCorrect = await _accountService.Login(loginModel.Email, loginModel.Password);
            if (!isPasswordCorrect)
            {
                return BadRequest("Mật khẩu không đúng");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, taikhoan.IdAccount.ToString()),
            new Claim(ClaimTypes.Name, taikhoan.UserName),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Lưu JWT vào cookies
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, 
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1) // Thời hạn cookies
            };

            Response.Cookies.Append("jwt_token", tokenString, cookieOptions);

            return Ok("Đăng nhập thành công");
        }

        // POST: api/Account/logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return Ok("Đăng xuất thành công");
        }


    }
}
