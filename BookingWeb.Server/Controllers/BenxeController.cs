﻿using BookingWeb.Server.Models;
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

        [HttpGet("BenXeByTinhThanh")]
        public async Task<IActionResult> GetBenXeByTinhThanh([FromQuery] int idTinhThanh)
        {
            var data = await _benxeService.GetBenXeByTinhThanhAsync(idTinhThanh);
            if (data == null)
            {
                return BadRequest();
            }

            return Ok(data);
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


    }
}
