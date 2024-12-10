namespace BookingWeb.Server.ViewModels;

public class TuyenDuongVM
{
    public int IdTuyenDuong { get; set; }
    
    public string? TenBenXe { get; set; }
    
    public int IdDiemDen { get; set; }
    
    public int IdDiemDi { get; set; }
    
    public int IdBenXeDi { get; set; }
    
    public string TenBenXeDi { get; set; } = string.Empty;
    public int IdBenXeDen { get; set; }
    
    public string TenBenXeDen { get; set; } = string.Empty;
    
    public string  NoiKhoiHanh { get; set; } = string.Empty;
    public string NoiDen { get; set; } = string.Empty;
    public decimal? KhoangCach { get; set; }
    public decimal? GiaVe { get; set; }
    public bool TrangThai { get; set; }
}
public class PagedTuyenDuongVM
{
    public List<TuyenDuongVM> TuyenDuongs { get; set; } = new List<TuyenDuongVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
}
