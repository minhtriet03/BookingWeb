using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class LoaixeController : ControllerBase
        {
            private readonly LoaiXeService _loaixeService;

            public LoaixeController(LoaiXeService loaixeService)
            {
                _loaixeService = loaixeService;
            }

            // Lấy tất cả loại xe
            [HttpGet]
            public async Task<ActionResult<List<Loaixe>>> GetAllLoaixes()
            {
                var loaixes = await _loaixeService.GetAllLoaiXes();
                return Ok(loaixes);
            }

            // Lấy loại xe theo ID
            [HttpGet("{id}")]
            public async Task<ActionResult<Loaixe>> GetLoaixeById(int id)
            {
                var loaixe = await _loaixeService.GetLoaixe(id);
                if (loaixe == null)
                {
                    return NotFound();
                }
                return Ok(loaixe);
            }
        }
    }

