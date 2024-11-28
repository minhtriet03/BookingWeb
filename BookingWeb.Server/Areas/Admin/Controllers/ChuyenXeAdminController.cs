using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("/Admin/[controller]")]
public class ChuyenXeAdminController : Controller
{
    private readonly ChuyenXeService _chuyenXeService;

    public ChuyenXeAdminController(ChuyenXeService chuyenXeService)
    {
        _chuyenXeService = chuyenXeService;
    }

    /*[HttpGet]
    public async Task<IActionResult> Index()
    {
        var viewModel = await _chuyenXeService.GetAllChuyenXeVM();
        return View(viewModel);
    }*/

    [HttpGet]
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
        }*/
        
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
    }
    /*[HttpGet]

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        var viewModel = await _chuyenXeService.GetByPageAsync(pageNumber, pageSize);

        if(viewModel == null)
        {
            return BadRequest("Không tìm thấy");
        }
        return View(viewModel);
    }*/
}