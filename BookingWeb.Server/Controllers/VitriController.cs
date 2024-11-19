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

        [HttpGet("{idXe}")]
        public async Task<ActionResult<List<Vitri>>> getVitriByIdXe(int idXe)
        {
            try
            {
                var data = await _vitriService.GetByIdXe(idXe);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Vitri>> addVitri(Vitri vitri)
        {
            try
            {
                var addedVitri = await _vitriService.addAsync(vitri);
                if (addedVitri == null)
                {
                    return BadRequest("Failed to add Vitri.");
                }
                else
                {
                    return Ok(addedVitri);
                }

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{idVitri}")]
        public async Task<ActionResult<Vitri>> delVitri(int idVitri)
        {
            try
            {
                // Gọi service để thêm Vitri
                var delVitri = await _vitriService.delete(idVitri);
                if (delVitri == null)
                {
                    return BadRequest("Failed to del Vitri.");
                }
                else
                {
                    return Ok(delVitri);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
