using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.ViewModels;

public class XeVM
{
    public int IdXe { get; set; }
    public string? BienSo { get; set; }
    public bool? TinhTrang { get; set; }

    // Thông tin loại xe
    public LoaiXeVM? LoaiXeVM { get; set; }
}

public class PagedXeVM
{
    public List<XeVM> Xes { get; set; } = new List<XeVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
    
    public IEnumerable<LoaiXeVM> Loaixes { get; set; }
}