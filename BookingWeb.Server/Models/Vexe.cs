using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vexe
{
    public int IdVe { get; set; }

    public int? IdPhieu { get; set; }

    public DateOnly? NgayKhoiHanh { get; set; }

    public DateOnly? NgayVe { get; set; }

    public int? IdUser { get; set; }

    public decimal? GiaVe { get; set; }

    public string? TrangThai { get; set; }

    public virtual Phieudat? IdPhieuNavigation { get; set; }

    public virtual Nguoidung? IdUserNavigation { get; set; }

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();
}
