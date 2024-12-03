using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;



namespace BookingWeb.Server.Helpers
{
	public static class MiddleWare
	{
		public static int GetUserIdFromCookie(HttpRequest request)
		{
			var token = request.Cookies["jwt"];
			if (string.IsNullOrEmpty(token))
			{
				return -1;
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtToken = tokenHandler.ReadJwtToken(token);
            var idAccount = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdAccount")?.Value;

            return int.Parse(idAccount);
		}

		public static async Task<string> GetFileHashAsync(IFormFile file)
		{
			using var sha256 = SHA256.Create();
			using var stream = file.OpenReadStream();
			var hashBytes = await sha256.ComputeHashAsync(stream);

			return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
		}
	}
}