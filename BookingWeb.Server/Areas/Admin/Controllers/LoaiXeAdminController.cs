using BookingWeb.Server.Filters;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
[AuthorizeJWT]
public class LoaiXeAdminController : Controller
{
    private readonly LoaiXeService _loaiXeService;

    public LoaiXeAdminController(LoaiXeService loaiXeService)
    {
        _loaiXeService = loaiXeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        var viewModel = await _loaiXeService.GetByPageAsync(pageNumber, pageSize);
        return View(viewModel);
    }

    [HttpGet("Detail/{id}")]
    public async Task<IActionResult> Detail(string id)
    {
        if (!int.TryParse(id, out int parsedId))
        {
            return BadRequest("ID không hợp lệ.");
        }

        var loaiXe = await _loaiXeService.GetByIdAsync(parsedId);
        if (loaiXe == null)
        {
            return NotFound();
        }

        return View(loaiXe);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddLoaiXeAsync([FromForm] LoaiXeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng thử lại.";
            return RedirectToAction("Index");
        }

        try
        {

            var data = new Loaixe
            {
                TenLoai = model.TenLoai,
                SoGhe = model.SoGhe,
                TrangThai = true
            };

            await _loaiXeService.AddLoaixe(data);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            // Ghi log lỗi nếu cần
            Console.WriteLine($"Lỗi khi thêm Loại Xe: {ex.Message}");

            // Hiển thị thông báo lỗi cho người dùng
            TempData["ErrorMessage"] = "Có lỗi xảy ra khi thêm loại xe. Vui lòng thử lại.";
            return RedirectToAction("Index");

        }
    }

    [HttpPost("Change")]
    public async Task<IActionResult> DeactivateLoaiXe([FromQuery] int id)
    {
        try
        {
            var result = await _loaiXeService.DeactivateLoaiXeAsync(id);
            if (result)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
            TempData["AlertMessage"] = "Có lỗi xảy ra khi cập nhật loại xe. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> EditLoaiXe([FromForm] LoaiXeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng thử lại.";
            return RedirectToAction("Index");
        }

        try
        {
            var data = new Loaixe
            {
                IdLoai = model.IdLoai,
                TenLoai = model.TenLoai,
                SoGhe = model.SoGhe,
                TrangThai = model.TrangThai
            };

            var result = await _loaiXeService.UpdateLoaixe(data);

            if (!result)
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
}