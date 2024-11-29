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

        public TuyenDuongController(TuyenDuongService tuyenDuongService)
        {
            _tuyenDuongService = tuyenDuongService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tuyenduong>>> GetAllTuyenDuong()
        {
            try
            {

                var data = await _tuyenDuongService.GetAllTuyenDuong();
                return Ok(data);
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
                var data = await _tuyenDuongService.GetTuyenDuongById(id);
                if (data == null)
                {
                    return NotFound("Không tìm thấy tuyến đường.");
                }
                return Ok(data);
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
                var data = await _tuyenDuongService.AddTuyenDuong(newTuyenDuong);
                if (data == false)
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

        [HttpPut]
        public async Task<IActionResult> UpdateTuyenDuong(Tuyenduong updateTuyenDuong)
        {
            try
            {
                //var check = await _tuyenDuongService.GetTuyenDuongById(updateTuyenDuong.IdTuyenDuong);
                //if (check == null)
                //{
                //    return BadRequest("Không thể chỉnh sửa thông tin.");
                //}

                var result = await _tuyenDuongService.UpdateTuyenDuong(updateTuyenDuong);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
        [HttpGet("lichtrinh")]
        public async Task<IActionResult> GetLichtrinh(int skip = 0, int take = 20)
        {
            try
            {
                var result = await _tuyenDuongService.GetLichtrinhAsync(skip, take);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
