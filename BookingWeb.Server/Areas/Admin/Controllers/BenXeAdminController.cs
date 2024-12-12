using BookingWeb.Server.Filters;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]")]
    [AuthorizeJWT]
    public class BenXeAdminController : Controller
    {
        private readonly BenxeService _benXeService;
        private readonly TinhService _tinhThanhService;
        public BenXeAdminController(BenxeService benxeService, TinhService tinhThanhService)
        {
            _benXeService = benxeService;
            _tinhThanhService = tinhThanhService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 7)
        {
            var viewModel = await _benXeService.GetByPageAsync(pageNumber, pageSize);
            var tinhThanh = await _tinhThanhService.getAll();
            if(viewModel == null)
            {
                return BadRequest("Không tìm thấy");
            }

            ViewBag.TinhThanhList = tinhThanh;
            
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBenXe([FromForm] BenXeVM model)
        {
            
            Console.WriteLine(model.IdBenXe);
            Console.WriteLine(model.IdTinhThanh);
            
            var data = new Benxe
            {
                IdTinhThanh = model.IdTinhThanh,
                TenBenXe = model.TenBenXe,
                TrangThai = true
            };

            var result = await _benXeService.addBenXe(data);
            if (result)
            {
                TempData["AlertMessage"] = "Thêm bến xe thành công";
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }
            TempData["AlertMessage"] = "Thêm bến xe thất bại";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }
        
        [HttpPost("Change")]
        public async Task<IActionResult> Deactivate([FromQuery] int id)
        {
            var result = await _benXeService.DeactivateBenXeAsync(id);
            if (result)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "success";
                
                string previousUrl = Request.Headers["Referer"].ToString();

                // Kiểm tra xem URL trước có tồn tại không
                if (!string.IsNullOrEmpty(previousUrl))
                {
                    return Redirect(previousUrl);
                }
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}