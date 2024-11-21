namespace BookingWeb.Server.ViewModels;

public class TuyenDuongVM
{
    public int IdTuyenDuong { get; set; }
    
    public string? TenBenXe { get; set; }
    public string NoiKhoiHanh { get; set; } = string.Empty;
    public string NoiDen { get; set; } = string.Empty;
    public decimal? KhoangCach { get; set; }
    public decimal? GiaVe { get; set; }
    public bool? TrangThai { get; set; }
}
public class PagedTuyenDuongVM
{
    public List<TuyenDuongVM> TuyenDuongs { get; set; } = new List<TuyenDuongVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
}
