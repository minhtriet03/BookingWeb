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
        
        [HttpGet]
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
    }
}
