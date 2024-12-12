using BookingWeb.Server.Filters;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
[AuthorizeJWT]
public class XeAdminController : Controller
{
    private readonly XeService _xeService;
    private readonly LoaiXeService _loaiXeService;
    

    public XeAdminController(XeService xeService, LoaiXeService loaiXeService )
    {
        _xeService = xeService;
        _loaiXeService = loaiXeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 7)
    {
        var viewModel = await _xeService.GetXesByPageAsync(pageNumber, pageSize);
        var loaiXe = await _loaiXeService.GetTrangThaiByConditionAsync();

        if (loaiXe == null || !loaiXe.Any())
        {
            Console.WriteLine("Không có dữ liệu LoaiXe");
        }
        ViewBag.LoaiXeList = loaiXe;

        foreach (var xe in ViewBag.LoaiXeList)
        {
            Console.WriteLine($"ID: {xe.IdLoai}, Tên Loại: {xe.TenLoai} View Bag");
        }
        return View(viewModel);
    }

    [HttpGet("Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            var loaiXe = await _loaiXeService.GetTrangThaiByConditionAsync();
            var xe = await _xeService.Getxe(id);
            if (xe == null)
            {
                TempData["AlertMessage"] = "Xe không tồn tại";
                TempData["AlertType"] = "warning";
                return RedirectToAction("Index");
            }
            
            ViewBag.LoaiXeList = loaiXe;    

            return View(xe);

        }
        catch (Exception ex)
        {
            TempData["AlertMessage"] = ex.Message;
            TempData["AlertType"] = "danger";   
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddXe([FromForm] XeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["AlertMessage"] = "Dữ liệu không hợp lệ. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }
        try
        {

            var isExistBienSo = await _xeService.GetBienSoByConditionAsync(model.BienSo);
            if(isExistBienSo!=null && isExistBienSo.Count > 0)
            {
                TempData["AlertMessage"] = "Biển số đã tồn tại";
                TempData["AlertType"] = "warning";
                return RedirectToAction("Index");
            }
            
            
            if(model.LoaiXeVM == null)
            {
                TempData["AlertMessage"] = " Không nhận được loại xe";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }

            Console.WriteLine($"Loại xe: {model.LoaiXeVM.IdLoai}");
            Console.WriteLine($"Biển số: {model.BienSo}");
            
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

    [HttpPost("Edit")]
    public async Task<IActionResult> EditXe([FromForm] Xe model)
    {
        Console.WriteLine(model.IdLoai);
        
        var data = await _xeService.Updatexe(model);
        if (!data)
        {
            TempData["AlertMessage"] = "Có lỗi xảy ra khi cập nhật xe. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Detail");
        }
        TempData["AlertMessage"] = "Cập nhật thành công";
        TempData["AlertType"] = "success";
        return RedirectToAction("Index");
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
                TempData["AlertMessage"] = "Hoạt động thành công";
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