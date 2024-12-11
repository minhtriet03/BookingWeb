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

        [HttpPost("user={id}")]
        public async Task<ActionResult<List<OrderVM>>> GetByIdUser(int id)
        {
            try
            {
                var data = await _orderService.GetByIdUser(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(int userId
            , [FromForm] decimal giaTien
            , [FromForm] decimal soLuong
            , [FromForm] Phieudat order
        )
        {
            if (order == null)
            {
                BadRequest("Dữ liệu không hợp lệ");
            }

            try
            {
                bool result = await _orderService.AddOrderAsync(userId, giaTien, soLuong, order);
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

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Phieudat order)
        {
            try
            {
                bool result = await _orderService.UpdateOrderAsync(order);

                if (result)
                    return Ok("Chỉnh sửa phiếu đặt thành công");

                return NotFound("Không tìm thấy thông tin phiếu đặt");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Có lỗi xảy ra khi cập nhật");
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