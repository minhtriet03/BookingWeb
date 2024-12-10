namespace BookingWeb.Server.ViewModels;

public class UserVM
{
    public int IdUser { get; set; }

    public string HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public bool? TrangThai { get; set; }
}

public class PagedUserVM
{
    public List<UserVM> Users { get; set; } = new List<UserVM>(); // Danh sách người dùng
    public int CurrentPage { get; set; } // Trang hiện tại
    public int TotalPages { get; set; } // Tổng số trang
}