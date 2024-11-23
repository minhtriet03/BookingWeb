namespace BookingWeb.Server.ViewModels;

public class ChuyenXeVM
{
    public int IdChuyenXe { get; set; }

    public DateTime? ThoiGianKh { get; set; }

    public DateTime? ThoiGianDen { get; set; }

    public bool? TrangThai { get; set; }
    
    public XeVM? XeVM { get; set; }
    
    public TuyenDuongVM? TuyenDuongVM { get; set; }
}