using BookingWeb.Server.Services;
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
}