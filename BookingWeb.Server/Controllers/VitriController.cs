using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VitriController : ControllerBase
    {
        private readonly VitriService _vitriService;

        public VitriController(VitriService vitriService)
        {
            _vitriService = vitriService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vitri>>> GetAllVitri()
        {
            try
            {
                var data = await _vitriService.GetAllVitri();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

   

    }
}
