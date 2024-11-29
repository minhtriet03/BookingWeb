using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
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
}