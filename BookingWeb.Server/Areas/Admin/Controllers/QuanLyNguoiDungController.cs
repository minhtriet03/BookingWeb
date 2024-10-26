using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanLyNguoiDungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
