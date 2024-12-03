using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaixeController : ControllerBase
    {
        private readonly LoaiXeService _loaixeService;

        public LoaixeController(LoaiXeService loaixeService)
        {
            _loaixeService = loaixeService;
        }

        // Lấy tất cả loại xe
        [HttpGet]
        public async Task<ActionResult<List<Loaixe>>> GetAllLoaixes()
        {
            var loaixes = await _loaixeService.GetAllLoaiXes();
            return Ok(loaixes);
        }
        
        [HttpGet("GetByCondition")]
        public async Task<ActionResult<List<Loaixe>>> GetByCondition()
        {
            var loaixes = await _loaixeService.GetTrangThaiByConditionAsync();
            return Ok(loaixes);
        }

        // Lấy loại xe theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Loaixe>> GetLoaixeById(int id)
        {
            var loaixe = await _loaixeService.GetLoaixe(id);
            if (loaixe == null)
            {
                return NotFound();
            }
            return Ok(loaixe);
        }

        // Thêm loại xe mới
        [HttpPost]
        public async Task<ActionResult> AddLoaixe([FromBody] Loaixe newLoaixe)
        {
            var isAdded = await _loaixeService.AddLoaixe(newLoaixe);
            if (isAdded)
            {
                return CreatedAtAction(nameof(GetLoaixeById), new { id = newLoaixe.IdLoai }, newLoaixe);
            }
            return BadRequest("Không thể thêm loại xe");
        }

        // Cập nhật loại xe
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLoaixe(int id, [FromBody] Loaixe updatedLoaixe)
        {
            if (id != updatedLoaixe.IdLoai)
            {
                return BadRequest("ID không khớp");
            }

            var isUpdated = await _loaixeService.UpdateLoaixe(updatedLoaixe);
            if (isUpdated)
            {
                return NoContent(); // Trả về 204 nếu cập nhật thành công
            }
            return NotFound("Không tìm thấy loại xe");
        }

        // Xóa loại xe
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoaixe(int id)
        {
            var isDeleted = await _loaixeService.DeleteLoaixe(id);
            if (isDeleted)
            {
                return NoContent(); // Trả về 204 nếu xoá thành công
            }
            return NotFound("Không tìm thấy loại xe");
        }
    }
}
