using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class TuyenDuongAdminController : Controller
{
    private readonly TuyenDuongService _tuyenDuongService;

    public TuyenDuongAdminController(TuyenDuongService tuyenDuongService)
    {
        _tuyenDuongService = tuyenDuongService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        var viewModel = await _tuyenDuongService.GetTuyenDuongByPageAsync(pageNumber, pageSize);

        return View(viewModel);
    }
    
    /*[HttpGet("DataViewBag")]
    public async Task<IActionResult> DataViewBag()
    {
        
        return View();
    }
    */
    
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