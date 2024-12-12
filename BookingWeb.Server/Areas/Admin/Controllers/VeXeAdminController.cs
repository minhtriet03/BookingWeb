using BookingWeb.Server.Filters;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [AuthorizeJWT]
    public class VeXeAdminController : Controller
    {
        private readonly VexeService _veXeService; 
        public VeXeAdminController(VexeService veXeService)
        {
            _veXeService = veXeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _veXeService.GetByDate();
            return View(viewModel);
        }
        
    }
}