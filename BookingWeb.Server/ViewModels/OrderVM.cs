namespace BookingWeb.Server.ViewModels;

public class OrderVM
{
    public int IdPhieu { get; set; }
    
    public int IdUser { get; set; }

    public DateOnly? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public bool? TrangThai { get; set; }
    
    public UserVM? UserVM { get; set; }
}