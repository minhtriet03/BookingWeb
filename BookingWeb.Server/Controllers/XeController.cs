using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XeController : ControllerBase
    {
        private readonly XeService _xeService;

        public XeController(XeService xeService)
        {
            _xeService = xeService;
        }

        // Lấy tất cả xe
        [HttpGet]
        public async Task<ActionResult<List<Xe>>> GetAllXe()
        {
            var xes = await _xeService.GetAllXes();
            return Ok(xes);
        }

        // Lấy xe theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Xe>> GetXeById(int id)
        {
            var xe = await _xeService.Getxe(id);
            if (xe == null)
            {
                return NotFound();
            }
            return Ok(xe);
        }

        // Thêm xe mới
        [HttpPost]
        public async Task<ActionResult<Xe>> AddXe(Xe newXe)
        {
            var xe = await _xeService.Addxe(newXe);
            if (xe == null)
            {
                return BadRequest("Không thể thêm xe.");
            }
            return CreatedAtAction(nameof(GetXeById), new { id = newXe.IdXe }, newXe);
        }

        // Cập nhật xe
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateXe(int id, Xe updatedXe)
        {
            if (id != updatedXe.IdXe)
            {
                return BadRequest("ID xe không khớp.");
            }

            var result = await _xeService.Updatexe(updatedXe);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Xóa xe
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXe(int id)
        {
            var result = await _xeService.Deletexe(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
