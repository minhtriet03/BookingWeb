using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace BookingWeb.Server.Filters
{
    public class AuthorizeJWTAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("Login", "Login", new { area = "Admin" }, null);
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                var claims = principal.Claims;
                var idAccount = claims.FirstOrDefault(c => c.Type == "IdAccount")?.Value;
                var userName = claims.FirstOrDefault(c => c.Type == "UserName")?.Value;

                if (string.IsNullOrEmpty(idAccount) || string.IsNullOrEmpty(userName))
                {
                    context.Result = new RedirectToActionResult("Login", "Login", new { area = "Admin" }, null);
                    return;
                }
            }
            catch (SecurityTokenException)
            {
                context.Result = new RedirectToActionResult("Login", "Login", new { area = "Admin" }, null);
                return;
            }
        }
    }
}