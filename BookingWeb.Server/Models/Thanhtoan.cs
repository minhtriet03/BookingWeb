using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Thanhtoan
{
    public int IdThanhToan { get; set; }

    public int? IdPhieuDat { get; set; }

    public decimal? SoTien { get; set; }

    public string? PhuongThucTt { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Phieudat? IdPhieuDatNavigation { get; set; }
}
