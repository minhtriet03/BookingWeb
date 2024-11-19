using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
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
