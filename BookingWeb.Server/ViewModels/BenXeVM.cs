namespace BookingWeb.Server.ViewModels;

public class BenXeVM
{
    public int IdBenXe { get; set; }
    public string TenBenXe { get; set; } = string.Empty;
    public string TenTinhThanh { get; set; } = string.Empty;
    public bool TrangThai { get; set; }
}

public class PagedBenXeVM
{
    public List<BenXeVM> BenXes { get; set; } = new List<BenXeVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
}