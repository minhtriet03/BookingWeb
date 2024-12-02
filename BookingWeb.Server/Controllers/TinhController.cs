using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinhController : ControllerBase
    {
        private readonly TinhService _service;
        public TinhController(TinhService tinhService) {
            _service = tinhService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tinhthanh>>> GetAllTinh()
        {

            try
            {
                var data = await _service.getAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Tinhthanh>> GetById(int id)
        {
            try
            {
                var data = await _service.getbyId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Tinhthanh>> GetByName(string name)
        {
            try
            {
                var data = await _service.GetByName(name);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<Tinhthanh>> addTinhThanh(Tinhthanh tinhthanh)
        {
            try
            {
                var data = await _service.addTinhThanh(tinhthanh);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Tinhthanh>> updateTinhThanh(Tinhthanh tinhthanh)
        {
            try
            {
                var data = await _service.updateTinh(tinhthanh);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Tinhthanh>> deleteTinhThanh(int id)
        {
            try
            {
                var data = await _service.deleteTinh(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
