namespace BookingWeb.Server.ViewModels
{
    public class VeXeVM
    {
        public int IdVe { get; set; }

        public int? IdPhieu { get; set; }

        public string ViTriGhe { get; set; }

        public int IdChuyenXe { get; set; }

        public DateOnly NgayKhoiHanh { get; set; }

        public bool TrangThai { get; set; }

        public  ChuyenXeVM? IdChuyenXeNavigation { get; set; } = null!;

        public  PhieuDatVM? IdPhieuNavigation { get; set; } = null!;

        public  ViTriVM? IdViTriGheNavigation { get; set; } = null!;
    }
}