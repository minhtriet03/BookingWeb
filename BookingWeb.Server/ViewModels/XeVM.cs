using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.ViewModels;

public class XeVM
{
    public int IdXe { get; set; }
    public string? BienSo { get; set; }
    public bool? TinhTrang { get; set; }

    // Thông tin loại xe
    public LoaiXeVM? LoaiXe { get; set; }
}