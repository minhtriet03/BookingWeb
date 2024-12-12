using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookingWeb.Server.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("/Admin/[controller]")]
    public class LoginController : Controller
    {

        private readonly AccountService _accountService;
        
        public LoginController(AccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["Layout"] = "_LayoutLogin";
            return View();
        }
        
        [HttpPost("login")] 
        public async Task<IActionResult> PostLogin(LoginModel loginModel)
        {
            Console.WriteLine("Username: " + loginModel.Email);
            Console.WriteLine("Password: " + loginModel.Password);
            
            
            var taikhoan = await _accountService.getAccountByUsername(loginModel.Email);

            if (taikhoan == null)
            {
                TempData["AlertMessage"] = "Tài khoản không tồn tại";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Login");
            }
            
            if (taikhoan.IdQuyen != 2)
            {
                TempData["AlertMessage"] = "Tài khoản không tồn tại";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Login");
            }

            var isPasswordCorrect = await _accountService.Login(loginModel.Email, loginModel.Password);
            if (!isPasswordCorrect)
            {
                TempData["AlertMessage"] = "Sai thông tin";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Login");
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
            var cookie = Request.Cookies["jwt"];
            if (cookie != null)
            {
                Console.WriteLine("Cookie chứa JWT: " + cookie);
            }
            else
            {
                Console.WriteLine("Cookie không chứa JWT");
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login", "Login", new { area = "Admin" });
        }
    }
}