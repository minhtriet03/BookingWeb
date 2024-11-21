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

    [HttpPost]
    [Route("DeactivateXeAsync")]
    public async Task<IActionResult> DeactivateXeAsync([FromQuery] int id)
    {
        try
        {
            bool result = await _xeService.DeactivateXeAsync(id);

            if (result)
            {
                TempData["AleartMessage"] = "Đã khóa xe thành công";
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