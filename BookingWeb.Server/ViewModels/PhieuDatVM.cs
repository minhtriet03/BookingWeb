namespace BookingWeb.Server.ViewModels;

public class PhieuDatVM
{
    public int IdPhieu { get; set; }

    public int IdUser { get; set; }

    public DateOnly NgayLap { get; set; }

    public decimal TongTien { get; set; }

    public string? TrangThai { get; set; }
}