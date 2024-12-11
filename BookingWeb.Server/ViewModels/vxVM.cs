namespace BookingWeb.Server.ViewModels
{
    public class vxVM
    {
        public int IdVe { get; set; }

        public int IdPhieu { get; set; }

        public string ViTriGhe { get; set; }

        public string Xe { get; set; }
        public string tuyenduong { get; set; }

        public decimal? GiaVe { get; set; }
        public DateOnly NgayKhoiHanh { get; set; }
        public bool TrangThai { get; set; }
    }
}
