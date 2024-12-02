using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("/Admin/[controller]")]
public class ChuyenXeAdminController : Controller
{
    private readonly ChuyenXeService _chuyenXeService;
    private readonly XeService _xeService;
    private readonly TuyenDuongService _tuyenDuong;

    public ChuyenXeAdminController(ChuyenXeService chuyenXeService, XeService xeService , TuyenDuongService tuyenDuong)
    {
        _chuyenXeService = chuyenXeService;
        _xeService = xeService;
        _tuyenDuong = tuyenDuong;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        var viewModel = await _chuyenXeService.GetByPageAsync(pageNumber, pageSize);
        var xeList = await _xeService.GetTrangThaiByConditionAsync();
        var tuyenDuongList = await _tuyenDuong.GetAllTuyenDuongAsync();

        ViewBag.XeList = xeList;
        ViewBag.TuyenDuongList = tuyenDuongList;

        if(viewModel == null)
        {
            return BadRequest("Không tìm thấy");
        }
        return View(viewModel);
    }

    [HttpGet]
    [Route("Detail")]
    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            var chuyenXe = await _chuyenXeService.GetChuyenXeByID(id);

            if (chuyenXe == null)
            {
                TempData["AlertMessage"] = "Chuyến xe không tồn tại";
                TempData["AlertType"] = "warning";
                return RedirectToAction("Index");
            }

            var xeList = await _xeService.GetAllXes();
            var tuyenDuongList = await _tuyenDuong.GetAllTuyenDuongAsync();

            ViewBag.XeList = xeList;
            ViewBag.TuyenDuongList = tuyenDuongList;

            return View(chuyenXe);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateChuyenXe([FromForm] ChuyenXeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["AlertMessage"] = "Dữ liệu không hợp lệ";
            TempData["AlertType"] = "warning";
            return RedirectToAction("Detail");
        }

        try
        {
            if (model.TuyenDuongVM == null || model.XeVM == null)
            {
                TempData["AlertMessage"] = "Không nhận được tuyến đường hoặc xe";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }

            var data = new Chuyenxe
            {
                ThoiGianKh = model.ThoiGianKh,
                ThoiGianDen = model.ThoiGianDen,
                TrangThai = true,
                IdXe = model.XeVM.IdXe,
                IdTuyenDuong = model.TuyenDuongVM.IdTuyenDuong,
            };

            var result = await _chuyenXeService.UpdateChuyenXe(data);
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
            Console.WriteLine($"Lỗi: {ex.Message}");
            TempData["AlertMessage"] = "Có lỗi xảy ra khi thêm loại xe. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddChuyenXeAsync([FromForm] ChuyenXeVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["AlertMessage"] = "Dữ liệu không hợp lệ";
            TempData["AlertType"] = "warning";
            return RedirectToAction("Index");
        }

        try
        {
            if (model.TuyenDuongVM == null || model.XeVM == null)
            {
                TempData["AlertMessage"] = "Không nhận được tuyến đường hoặc xe";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Index");
            }

            var data = new Chuyenxe
            {
                ThoiGianKh = model.ThoiGianKh,
                ThoiGianDen = model.ThoiGianDen,
                TrangThai = true,
                IdXe = model.XeVM.IdXe,
                IdTuyenDuong = model.TuyenDuongVM.IdTuyenDuong,
            };

            var result = await _chuyenXeService.AddChuyenXe(data);
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
            Console.WriteLine($"Lỗi: {ex.Message}");
            TempData["AlertMessage"] = "Có lỗi xảy ra khi thêm loại xe. Vui lòng thử lại.";
            TempData["AlertType"] = "danger";
            return RedirectToAction("Index");
        }
    }
}

/*[HttpGet]
public async Task<IActionResult> Index()
{
    var viewModel = await _chuyenXeService.GetAllChuyenXeVM();
    return View(viewModel);
}*/

/*[HttpGet]
public async Task<IActionResult> Index(string searchString)
{
    var viewModel = await _chuyenXeService.GetAllChuyenXeVM();

    if (viewModel == null)
    {
        return Problem("Entity set is null.");
    }

    /*if (!String.IsNullOrEmpty(searchString))
    {
        viewModel = viewModel.Where(cx => (bool)cx.XeVM?.BienSo.Contains(searchString.ToUpper()));
    }#1#

    if (!String.IsNullOrEmpty(searchString))
    {
        viewModel = viewModel.Where(cx =>
                (cx.XeVM?.BienSo?.ToUpper().Contains(searchString.ToUpper()) ?? false) ||
                (cx.XeVM?.LoaiXeVM?.TenLoai?.ToUpper().Contains(searchString.ToUpper()) ?? false) ||
                (cx.TuyenDuongVM?.NoiDen?.ToUpper().Contains(searchString.ToUpper()) ?? false) ||
                (cx.TuyenDuongVM?.NoiKhoiHanh?.ToUpper().Contains(searchString.ToUpper()) ?? false) ||
                (cx.TuyenDuongVM?.KhoangCach?.ToString()?.Contains(searchString.ToUpper()) ?? false) ||
                (cx.TuyenDuongVM?.GiaVe?.ToString()?.Contains(searchString.ToUpper()) ?? false)
        );
    }

    return View(viewModel);
}*/