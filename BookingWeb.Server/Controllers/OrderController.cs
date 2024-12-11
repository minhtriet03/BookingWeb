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
        public async Task<IActionResult> AddOrder( Phieudat order)
        {
            if (order == null)
            {
                BadRequest("Dữ liệu không hợp lệ");
            }

            try
            {
                bool result = await _orderService.AddOrderAsync(order);
                if (result)
                {
                    return Ok("Đặt vé thành công");
                }
                else
                {
                    return StatusCode(500, "Đỏ lè đỏ loét luôn");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromBody] int id)
        {
            try
            {
                bool result = await _orderService.DeleleOrderAsync(id);
                if (result)
                    return Ok("Xóa thành công");
                return NotFound("Không tìm thấy phiếu đặt");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}