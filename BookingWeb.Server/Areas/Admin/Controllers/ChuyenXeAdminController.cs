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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var viewModel = await _chuyenXeService.GetAllChuyenXeVM();
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