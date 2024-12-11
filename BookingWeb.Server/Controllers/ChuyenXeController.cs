using BookingWeb.Server.Dto;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
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

        //get chuyen xe by tuyen duong
        [HttpGet("tuyenduong/{id}")]
        public async Task<ActionResult<List<Chuyenxe>>> GetChuyenXeByTuyenDuong(int id)
        {
            try
            {
                var data = await chuyenXeService.GetAllChuyenXeByTuyenDuong(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //get chuyen xe by tinh
        [HttpGet("tinh/{noidi}/{noiden}/{date}")]
        public async Task<ActionResult<List<ChuyenxeDetailDto>>> GetChuyenXeByTinh(string noidi, string noiden, DateOnly date)
        {
            try
            {
                var data = await chuyenXeService.GetAllChuyenXeByTinh(noidi, noiden, date);
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

        
        //Cai nay cua Toan nha
        [HttpGet("GetByTime")]
        public async Task<ActionResult<List<ChuyenXeVM>>> GetByTime([FromQuery] int idXe ,[FromQuery]string timeStart,[FromQuery] string timeEnd,[FromQuery] int IdTuyenDuong, [FromQuery] DateTime ngayKhoiHanh)
        {
            
            DateOnly ngayKhoiHanhOnly = DateOnly.FromDateTime(ngayKhoiHanh);
            
            var data = await chuyenXeService.GetByTime(idXe ,timeStart, timeEnd, IdTuyenDuong, ngayKhoiHanhOnly);

            if (data == null)
            {
                return null;
            }

            return Ok(data);
        }
        
        [HttpGet("NgayLonNhat")]
        public async Task<IActionResult> LayTheoNgayLonNhat()
        {
            var data = await chuyenXeService.GetChuyenXeTheoNgayLonNhat();
            if (data != null)
            {
                return Ok(data);
            }
            
            return null;
        }

        [HttpPost("AddChuyenXeTheoNgay")]
        public async Task<IActionResult> AddChuyenXeTheoNgay()
        {
            var data = await chuyenXeService.AddChuyenXeTheoNgay();
            if (data)
            {
                return Ok(data);
            }
            
            return BadRequest();
        }
    } 
}
