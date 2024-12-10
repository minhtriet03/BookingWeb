namespace BookingWeb.Server.ViewModels
{
    public class TaiKhoanVM
    {
        public int IdAccount { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int IdQuyen { get; set; }

        public bool? TrangThai { get; set; }
    }
}