using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;

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
        public async Task<IActionResult> AddOrder([FromBody] Phieudat order)
        {
            // Kiểm tra nếu đối tượng order là null
            if (order == null)
            {
                // Trả về BadRequest nếu dữ liệu không hợp lệ
                return BadRequest("Dữ liệu không hợp lệ");
            }

            try
            {
                int result = await _orderService.AddOrderAsync(order);

                if (result > 0) // Kiểm tra nếu ID trả về lớn hơn 0
                {
                    return Ok(new { orderId = result });
                }
                else
                {
                    return StatusCode(500, "Đã xảy ra lỗi khi tạo phiếu đặt");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
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
        
        [HttpGet("ThongKe")]
        public async Task<IActionResult> LayThongKePhieuDat()
        {
            var thongKe = await _orderService.ThongKePhieuDatTheoThang();
    
            // Tạo dữ liệu cho biểu đồ
            var labels = thongKe.Select(x => $"Tháng {x.Thang}/{x.Nam}").ToList();
            var data = thongKe.Select(x => x.TongTien).ToList();

            return Ok(new IList[] { labels, data });
        }
    }
}