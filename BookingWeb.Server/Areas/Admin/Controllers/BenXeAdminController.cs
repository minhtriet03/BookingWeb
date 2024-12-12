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
        
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            if (!int.TryParse(id, out int parsedId))
            {
                return BadRequest("ID không hợp lệ.");
            }
            
            var tinhThanh = await _tinhThanhService.getAll();
            ViewBag.TinhThanhList = tinhThanh;
            var benXe = await _benXeService.GetByIdAsync(parsedId);
            if (benXe == null)
            {
                return NotFound();
            }

            return View(benXe);
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
        
        [HttpPost("Edit")]
        public async Task<IActionResult> EditLoaiXe([FromForm] BenXeVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng thử lại.";
                return RedirectToAction("Index");
            }

            try
            {
                var data = new Benxe
                {
                    IdBenXe = model.IdBenXe,
                    TenBenXe = model.TenBenXe,
                    IdTinhThanh = model.IdTinhThanh,
                    TrangThai = model.TrangThai
                };

                var result = await _benXeService.updateBenxe(data);

                if (result < 0)
                {
                    TempData["AlertMessage"] = "Có lỗi xảy ra khi cập nhật loại xe. Vui lòng thử lại.";
                    TempData["AlertType"] = "danger";

                    return RedirectToAction("Detail");
                }
            
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "success";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine($"Lỗi khi thêm Loại Xe: {ex.Message}");

                // Hiển thị thông báo l}
                return RedirectToAction("Detail");
            }
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