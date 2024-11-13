using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderVM>>> GetAllOrders()
        {
            try
            {
                var data = await _orderService.GetAllOrders();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(int userId, [FromForm] decimal soLuong, [FromForm] decimal giaTien, [FromForm] Phieudat order)
        {
            if (userId == null)
            {
                return BadRequest("Dũ liệu người dùng không hợp lệ");
            }

            try
            {
                bool result = await _orderService.AddOrderAsync(userId, soLuong, giaTien, order);
                if (result)
                {
                    return Ok("Đã đặt vé thành công");
                }
                else
                {
                    return StatusCode(500, "Lỗi đỏ lòm đỏ chét luôn");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}