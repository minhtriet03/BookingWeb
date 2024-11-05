using Microsoft.AspNetCore.Mvc;
using BookingWeb.Services;

namespace BookingWeb.Server.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        
    }
}