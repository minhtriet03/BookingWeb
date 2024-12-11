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
    public List<UserVM> Users { get; set; } = new List<UserVM>(); 
    public int CurrentPage { get; set; } 
    public int TotalPages { get; set; }
}