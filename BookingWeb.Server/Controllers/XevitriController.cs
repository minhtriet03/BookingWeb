using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XevitriController : ControllerBase
    {
        private readonly XevitriService _xevitriService;

        public XevitriController(XevitriService xevitriService)
        {
            _xevitriService = xevitriService;
        }

        [HttpGet("page={page}")]
        public async Task<ActionResult<List<Xevitri>>> getByPage(int page)
        {
            try
            {
                var data = await _xevitriService.getByPage(page);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Xevitri>>> add(Xevitri xevitri)
        {
            try
            {
                var data = await _xevitriService.addXeVtri(xevitri);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
