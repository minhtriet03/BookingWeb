namespace BookingWeb.Server.Dto
{
    public class ChuyenxeDetailDto
    {
        public string NoiKhoiHanhTinhThanh { get; set; }
        public string NoiDenTinhThanh { get; set; }
        public decimal? KhoangCach { get; set; }
        public decimal? GiaVe { get; set; }

        public int? SoLuongVeDaDat { get; set; }

        public string? TGKH { get; set; }
        public string? TGKT { get; set; }

        public bool? TrangThai { get; set; }
        public string LoaiXe { get; set; }
        public string TongThoiGian { get; set; }
    }
}