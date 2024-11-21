namespace BookingWeb.Server.ViewModels;

public class TinhThanhVM
{
    public int IdTinhThanh { get; set; }
    public string TenTinhThanh { get; set; } = string.Empty;
    public bool? TrangThai { get; set; }
}

public class PageTinhThanhVM
{
    public List<TinhThanhVM> TinhThanhs { get; set; } = new List<TinhThanhVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
}