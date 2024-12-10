using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("/Admin/[controller]")]
    public class PhieuDatAdminController : Controller
    {
        private readonly OrderService _orderService;
        
        public PhieuDatAdminController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /*[HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _orderService.GetAllOrders();
            return View(viewModel);
        }*/
        
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
            
            var viewModel = await _orderService.GetByDate(startDate, endDate);
            return View(viewModel);
        }        
    }
}