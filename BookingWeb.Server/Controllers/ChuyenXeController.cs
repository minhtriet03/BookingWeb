using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChuyenXeController : ControllerBase
    {
        private readonly ChuyenXeService chuyenXeService;

        public ChuyenXeController(ChuyenXeService chuyenXeService)
        {
            this.chuyenXeService = chuyenXeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chuyenxe>>> GetAllChuyenXe()
        {
            try
            {
                var data = await chuyenXeService.GetAllChuyenXe();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chuyenxe>> GetChuyenXeById(int id)
        {
            try
            {
                   var data = await chuyenXeService.GetChuyenXeByID(id);
                if (data == null)
                {
                    return NotFound("Không tìm thấy chuyến xe.");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Chuyenxe>> AddChuyenXe(Chuyenxe newChuyenXe)
        {
            try
            {
                var data = await chuyenXeService.AddChuyenXe(newChuyenXe);
                if (data == null)
                {
                    return BadRequest("Không thể thêm chuyến xe.");
                }
                return CreatedAtAction(nameof(GetChuyenXeById), new { id = newChuyenXe.IdChuyenXe }, newChuyenXe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Chuyenxe>> UpdateChuyenXe(Chuyenxe newChuyenXe)
        {
            try
            {
                var data = await chuyenXeService.UpdateChuyenXe(newChuyenXe);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    } 
}
