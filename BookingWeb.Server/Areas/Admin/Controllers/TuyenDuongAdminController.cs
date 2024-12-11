using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class TuyenDuongAdminController : Controller
{
    private readonly TuyenDuongService _tuyenDuongService;
    private readonly TinhService _tinhService;
    private readonly BenxeService _benXeService;
    public TuyenDuongAdminController(TuyenDuongService tuyenDuongService, TinhService tinhService, BenxeService benXeService)
    {
        _tuyenDuongService = tuyenDuongService;
        _tinhService = tinhService;
        _benXeService = benXeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        var viewModel = await _tuyenDuongService.GetTuyenDuongByPageAsync(pageNumber, pageSize);
        var tinhThanh = await _tinhService.getAll();
        ViewBag.TinhThanhList = tinhThanh;
        return View(viewModel);
    }

    [HttpGet("Detail")]
    public async Task<IActionResult> Detail([FromQuery] int idTuyenDuong)
    {
        var tinhThanh = await _tinhService.getAll();
        var data = await _tuyenDuongService.GetTuyenDuongById(idTuyenDuong);
        ViewBag.TinhThanhList = tinhThanh;

        if (data == null)
            return NotFound();


        var benXeDi = await _benXeService.GetById(data.IdBenXeDi);
        var benXeDen = await _benXeService.GetById(data.IdBenXeDen);

        data.IdDiemDi = benXeDi?.IdTinhThanh ?? 0;
        data.IdDiemDen = benXeDen?.IdTinhThanh ?? 0;
        data.TenBenXeDi = benXeDi?.TenBenXe; // Gán tên bến xe đi
        data.TenBenXeDen = benXeDen?.TenBenXe;
        Console.WriteLine("===================================");
        Console.WriteLine(data.IdBenXeDi);
        Console.WriteLine(benXeDen);
        return View(data);
    }

    /*[HttpGet("DataViewBag")]
    public async Task<IActionResult> DataViewBag()
    {

        return View();
    }
    */
    [HttpPost]
    public async Task<IActionResult> AddTuyenDuong([FromForm] TuyenDuongVM model)
    {

        Console.WriteLine(model.IdDiemDi);
        Console.WriteLine(model.IdDiemDen);

        var tuyenDuong = new Tuyenduong
        {
            NoiKhoiHanh = model.IdDiemDi,
            NoiDen = model.IdDiemDen,
            KhoangCach = model.KhoangCach,
            GiaVe = model.GiaVe,
            TrangThai = true
        };

        var data = await _tuyenDuongService.AddTuyenDuong(tuyenDuong);

        if (data)
        {
            TempData["AlertMessage"] = "Thêm thành công";
            TempData["AlertType"] = "success";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("DeactivateAsync")]
    public async Task<IActionResult> DeactivateUserAsync([FromQuery]int id)
    {
        try
        {
            bool result = await _tuyenDuongService.DeactivateAsync(id);
        
            if (result)
            {
                // Nếu cập nhật thành công, chuyển hướng về trang Index
                TempData["AlertMessage"] = "Thay đổi thành công";
                TempData["AlertType"] = "success";
                return RedirectToAction("Index");
            }
            else
            {
                // Nếu không thành công, bạn có thể thêm thông báo lỗi ở đây
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi thay đổi trạng thái.";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi và thông báo cho người dùng
            TempData["ErrorMessage"] = "Lỗi: " + ex.Message;
            return RedirectToAction("Index");
        }
            
    }
}