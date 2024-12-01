using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class XeAdminController : Controller
{
    private readonly XeService _xeService;

    public XeAdminController(XeService xeService)
    {
        _xeService = xeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        var viewModel = await _xeService.GetXesByPageAsync(pageNumber, pageSize);

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoaiXeAsync([FromForm] XeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["AlertMessage"] = "Dữ liệu không hợp lệ. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }

        try
        {
            if(model.LoaiXeVM == null)
            {
                TempData["AlertMessage"] = " Không nhận được loại xe";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }

            var data = new Xe
            {
                BienSo = model.BienSo,
                IdLoai = model.LoaiXeVM.IdLoai,
                TinhTrang = true

            };

            var result = await _xeService.Addxe(data);

            if (result)
            {
                TempData["AlertMessage"] = "Thêm thành công";
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }

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

    [HttpPost]
    [Route("DeactivateXeAsync")]
    public async Task<IActionResult> DeactivateXeAsync([FromQuery] int id)
    {
        try
        {
            bool result = await _xeService.DeactivateXeAsync(id);

            if (result)
            {
                TempData["AlertMessage"] = "Đã khóa xe thành công";
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra";
                TempData["AlertType"] = "error";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }
}