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
        public async Task<ActionResult<List<vxVM>>> GetVeXeByPhieu(int id)
        {
            var phieus = await _orderService.GetByIdUser(id);
            if (phieus == null || !phieus.Any())
            {
                return NotFound("Không tìm thấy phiếu nào cho người dùng này.");
            }

            var vexeVMs = new List<vxVM>();

            foreach (var phieu in phieus)
            {
                // Lấy thông tin vé xe cùng thông tin chi tiết từ dịch vụ
                var vexes = await _vexeService.GetVebyPhieuWithDetails(phieu.IdPhieu);

                foreach (var v in vexes)
                {
                    // Lấy tuyến đường thông qua IdChuyenXeNavigation
                    var tuyenduong = v.IdChuyenXeNavigation?.IdTuyenDuongNavigation;

                    if (tuyenduong == null) continue;

                    var noiKhoiHanh = tuyenduong.NoiKhoiHanhNavigation?.TenBenXe ?? "Không xác định";
                    Console.WriteLine(noiKhoiHanh);
                    var noiDen = tuyenduong.NoiDenNavigation?.TenBenXe ?? "Không xác định";
                    Console.WriteLine(noiDen);
                    var diaDiem = $"{noiKhoiHanh} - {noiDen}";

                    // Lấy ngày khởi hành từ Chuyenxe (không phải từ Vexe nữa)
                    var ngayKhoiHanh = v.IdChuyenXeNavigation?.NgayKhoiHanh ?? throw new Exception("Ngày khởi hành không xác định.");

                    var xe = v.IdChuyenXeNavigation?.IdXeNavigation?.BienSo ?? "Không xác định";

                    var vexeVm = new vxVM
                    {
                        IdVe = v.IdVe,
                        IdPhieu = v.IdPhieu.HasValue ? v.IdPhieu.Value : throw new Exception("IdPhieu is null"),
                        ViTriGhe = v.ViTriGhe,
                        GiaVe = tuyenduong.GiaVe,
                        tuyenduong = diaDiem,
                        Xe = xe,
                        NgayKhoiHanh = ngayKhoiHanh, 
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

        [HttpGet("Date")]
        public async Task<ActionResult<List<VeXeVM>>> GetByDate()
        {
            try
            {
                var data = await _vexeService.GetByDate();
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

        [HttpGet("GetIDChuyenXe")]
        public async Task<IActionResult> GetIDChuyenXe()
        {
            try
            {
                var data = await _vexeService.LayIDChuyenXeChuaCoVe();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPost("CreateVeXe")]
        public async Task<IActionResult> TaoVeChoChuyenChuaCoVe()
        {
            var ketQua = await _vexeService.CreateVeXe();
    
            if (ketQua)
            {
                return Ok(ketQua);
            }
            else
            {
                return BadRequest("Có lỗi xảy ra khi tạo vé");
            }
        }
    }
}
