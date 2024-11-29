namespace BookingWeb.Server.Models
{
    public class Xevitri
    {
        public int IdXe { get; set; }

        public int IdViTri { get; set; }

        public bool? TrangThai { get; set; }

        public virtual Vitri IdViTriNavigation { get; set; } = null!;

        public virtual Xe IdXeNavigation { get; set; } = null!;
    }
}
