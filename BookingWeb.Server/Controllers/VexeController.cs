using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VexeController : ControllerBase
    {
        private VexeService _vexeService;

        public VexeController(VexeService vexeService)
        {
            _vexeService = vexeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vexe>>> GetAllVeXe()
        {
            try
            {
                var data = await _vexeService.getAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("page={i}")]
        public async Task<ActionResult<List<Vexe>>> GetVexeByPage(int i)
        {

            try
            {
                var data = await _vexeService.getByPage(i);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        
        [HttpGet("Date")]
        public async Task<ActionResult<List<VeXeVM>>> GetByDate(string startDate, string endDate)
        {
            try
            {
                var data = await _vexeService.GetByDate(startDate, endDate);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<bool>> addVexe(Vexe vexe)
        {
            try
            {
                var data = await _vexeService.addVeXe(vexe);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> delete(int id)
        {
            try
            {
                var data = await _vexeService.deleteVexe(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
