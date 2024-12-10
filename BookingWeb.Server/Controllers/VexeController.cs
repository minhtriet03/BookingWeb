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
        private OrderService _orderService;
        private TuyenDuongService _tuyenduongService;
        private TinhService _tinhService;

        public VexeController(VexeService vexeService, OrderService orderService)
        {
            _vexeService = vexeService;
            _orderService = orderService;
        }
         
        [HttpGet("user={id}")]
        public async Task<ActionResult<List<VexeVM>>> GetVeXeByPhieu(int id) {
            var phieus = await _orderService.GetByIdUser(id);
            if (phieus == null || !phieus.Any())
            {
                return NotFound("Không tìm thấy phiếu nào cho người dùng này.");
            }

            var vexeVMs = new List<VexeVM>();

            foreach (var phieu in phieus)
            {
                // Lấy thông tin vé xe cùng thông tin chi tiết từ dịch vụ
                var vexes = await _vexeService.GetVebyPhieuWithDetails(phieu.IdPhieu);

                foreach (var v in vexes)
                {
                    // Lấy tuyến đường thông qua IdChuyenXeNavigation
                    var tuyenduong = v.IdChuyenXeNavigation?.IdTuyenDuongNavigation;

                    if (tuyenduong == null) continue;

                    // Lấy thông tin Bến xe nơi khởi hành và nơi đến
                    var noiKhoiHanh = tuyenduong.NoiKhoiHanhNavigation?.TenBenXe ?? "Không xác định";
                    var noiDen = tuyenduong.NoiDenNavigation?.TenBenXe ?? "Không xác định";

                    var diaDiem = $"{noiKhoiHanh} - {noiDen}";

                    // Tạo ViewModel VexeVM với thông tin
                    var vexeVm = new VexeVM
                    {
                        IdVe = v.IdVe,
                        IdPhieu = v.IdPhieu,
                        IdViTriGhe = v.IdViTriGhe,
                        GiaVe = tuyenduong.GiaVe,
                        tuyenduong = diaDiem, // Hiển thị thông tin bến xe
                        NgayKhoiHanh = v.NgayKhoiHanh,
                        TrangThai = v.TrangThai
                    };

                    vexeVMs.Add(vexeVm);
                }
            }

            return Ok(vexeVMs);
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
