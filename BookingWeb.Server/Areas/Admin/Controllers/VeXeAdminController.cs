using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class VeXeAdminController : Controller
    {
        private readonly VexeService _veXeService; 
        public VeXeAdminController(VexeService veXeService)
        {
            _veXeService = veXeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate))
            {
                startDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            }
            
            if (string.IsNullOrEmpty(endDate))
            {
                endDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            
            var viewModel = await _veXeService.GetByDate(startDate, endDate);
            return View(viewModel);
        }
        
    }
}