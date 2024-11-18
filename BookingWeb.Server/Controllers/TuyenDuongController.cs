using Microsoft.AspNetCore.Mvc;
using BookingWeb.Server.Services;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.Interfaces;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TuyenDuongController : ControllerBase
    {
        private readonly TuyenDuongService _tuyenDuongService;

        public TuyenDuongController( TuyenDuongService tuyenDuongService)
        {
            _tuyenDuongService = tuyenDuongService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tuyenduong>>> GetAllTuyenDuong()
        {
            try
            {

                var tuyenDuongs = await _tuyenDuongService.GetAllTuyenDuong();
                return Ok(tuyenDuongs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tuyenduong>> GetTuyenDuongById(int id)
        {
            try
            {
                var tuyenDuong = await _tuyenDuongService.GetTuyenDuongById(id);
                if (tuyenDuong == null)
                {
                    return NotFound();
                }
                return Ok(tuyenDuong);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tuyenduong>> AddTuyenDuong(Tuyenduong newTuyenDuong)
        {
            try
            {
                var tuyenDuong = await _tuyenDuongService.AddTuyenDuong(newTuyenDuong);
                if (tuyenDuong == null)
                {
                    return BadRequest("Không thể thêm tuyến đường.");
                }
                return CreatedAtAction(nameof(GetTuyenDuongById), new { id = newTuyenDuong.IdTuyenDuong }, newTuyenDuong);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTuyenDuong(int id, Tuyenduong updatedTuyenDuong)
        {
            if (id != updatedTuyenDuong.IdTuyenDuong)
            {
                return BadRequest("ID tuyến đường không khớp.");
            }

            var result = await _tuyenDuongService.UpdateTuyenDuong(updatedTuyenDuong);
            if (result)
            {
                return Ok("Cập nhật tuyến đường thành công");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
