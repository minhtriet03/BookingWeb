namespace BookingWeb.Server.ViewModels
{
    public class VexeVM
    {
        public int IdVe { get; set; }
        public int? IdPhieu { get; set; }

        public int IdViTriGhe { get; set; }
        public string tuyenduong { get; set; }
        public decimal? GiaVe { get; set; }
        public DateOnly NgayKhoiHanh { get; set; }
        public bool TrangThai { get; set; }
    }
}
