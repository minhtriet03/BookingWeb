using BookingWeb.Server.Controllers;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("/Admin/[controller]")]
    public class TaiKhoanAdminController : Controller
    {
        private readonly AccountService _accountService;

        public TaiKhoanAdminController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 8)
        {
            var viewModel = await _accountService.GetByPageAsync(pageNumber, pageSize);
            if (viewModel == null)
            {
                return BadRequest("Khong tim thay");
            }
            return View(viewModel);
        }

        [HttpPost("DeactivateAsync")]
        public async Task<IActionResult> DeactivateAsync(int id)
        {
            var result = await _accountService.DeactivateAsync(id);
            if (result)
            {
                TempData["AlertMessage"] = "Thay đổi trang thái thành công";
                TempData["AlertType"] = "success";
            }
            else
            {
                TempData["AlertMessage"] = "Deactivated failed";
                TempData["AlertType"] = "danger";
            }
            return RedirectToAction("Index");
        }
    }
}