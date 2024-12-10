namespace BookingWeb.Server.ViewModels;

public class BenXeVM
{
    public int IdBenXe { get; set; }
    public int IdTinhThanh { get; set; }
    public string? TenBenXe { get; set; }
    public bool? TrangThai { get; set; }
    public TinhThanhVM? TinhThanhVM { get; set; }   
}

