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
        [HttpGet("{name}")]
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
    }
}
