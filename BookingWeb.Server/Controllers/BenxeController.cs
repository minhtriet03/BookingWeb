using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BenxeController : ControllerBase
    {
        private readonly BenxeService _benxeService;
       public BenxeController(BenxeService benxeService) {
            _benxeService = benxeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Benxe>>> getAll()
        {
            try
            {
                var benxes = await _benxeService.getAll();
                return Ok(benxes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
         
            }
        }

        [HttpGet("page={i}")]
        public async Task<ActionResult<List<Benxe>>> getByPage(int i)
        {
            try
            {
                var benxes = await _benxeService.getbyPage(i);
                return Ok(benxes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Benxe>> getByName(string name)
        {
            try
            {
                var benxe = await _benxeService.getByName(name);
                return Ok(benxe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public async Task<ActionResult<Benxe>> addBenxe(Benxe benxe)
        {
            try
            {
                _benxeService.addBenXe(benxe);
                return Ok(benxe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Benxe>> updateBenXe(Benxe benxe)
        {
            try
            {
                var data = await _benxeService.updateBenxe(benxe);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Vitri>> delBenxe(int id)
        {
            try
            {
                // Gọi service để thêm Vitri
                var delVitri = await _benxeService.deleteBenXe(id);
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
