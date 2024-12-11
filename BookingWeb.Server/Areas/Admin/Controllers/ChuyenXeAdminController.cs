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
    public async Task<IActionResult> Index()
    {
        var viewModel = await _chuyenXeService.GetAllChuyenXeVM();
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
    
    /*[HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 7)
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
    }*/

    [HttpGet]
    [Route("Detail")]
    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            
            TempData["PreviousUrl"] = Request.Headers["Referer"].ToString();
            var chuyenXe = await _chuyenXeService.GetChuyenXeByID(id);

            if (chuyenXe == null)
            {
                TempData["AlertMessage"] = "Chuyến xe không tồn tại";
                TempData["AlertType"] = "warning";
                return RedirectToAction("Index");
            }
            
            Console.WriteLine("Trang Thái: " + chuyenXe.TrangThai);


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

    [HttpPost("Edit")]
    public async Task<IActionResult> UpdateChuyenXe([FromForm] ChuyenXeVM model)
    {
        
        Console.WriteLine("==============================");
        Console.WriteLine("IdChuyenXe: " + model.IdChuyenXe);
        Console.WriteLine("IdXe: " + model.XeVM.IdXe);
        Console.WriteLine("IdTuyenDuong:" + model.TuyenDuongVM.IdTuyenDuong);
        Console.WriteLine("ThoiGianKh: " + model.ThoiGianKh);
        Console.WriteLine("ThoiGianDen: " + model.ThoiGianDen);
        Console.WriteLine("Trang Thái: " + model.TrangThai);
        Console.WriteLine("==============================");
        try
        {
            if (model.TuyenDuongVM == null || model.XeVM == null)
            {
                TempData["AlertMessage"] = "Không nhận được tuyến đường hoặc xe";
                TempData["AlertType"] = "danger";
                {
                    // Chuyển hướng đến URL trước đó
                    return Redirect(TempData["PreviousUrl"].ToString());
                }
                return RedirectToAction("Index");
            }

            var data = new Chuyenxe
            {
                IdChuyenXe = model.IdChuyenXe,
                ThoiGianKh = model.ThoiGianKh,
                ThoiGianDen = model.ThoiGianDen,
                TrangThai = model.TrangThai,
                IdXe = model.XeVM.IdXe,
                IdTuyenDuong = model.TuyenDuongVM.IdTuyenDuong,
                NgayKhoiHanh = model.NgayKhoiHanh
            };

            var result = await _chuyenXeService.UpdateChuyenXe(data);
            if (result)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "success";
                if (TempData["PreviousUrl"] != null)
                {
                    // Chuyển hướng đến URL trước đó
                    return Redirect(TempData["PreviousUrl"].ToString());
                }
                
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

        Console.WriteLine("==============================");
        Console.WriteLine(model.ThoiGianKh);
        Console.WriteLine(model.ThoiGianDen);
        Console.WriteLine(model.XeVM.IdXe);
        Console.WriteLine(model.TuyenDuongVM.IdTuyenDuong);
        Console.WriteLine("==============================");
        
        
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
                NgayKhoiHanh = model.NgayKhoiHanh
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
    
    [HttpPost("DeactivateAsync")]
    public async Task<IActionResult> DeactivateAsync([FromQuery] int id)
    {
        try
        {
            var result = await _chuyenXeService.DeactivateChuyenXe(id);
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