using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Thanhtoan
{
    public int IdThanhToan { get; set; }

    public int? IdVe { get; set; }

    public decimal? SoTien { get; set; }

    public string? PhuongThucTt { get; set; }

    public string? TrangThai { get; set; }

    public virtual Vexe? IdVeNavigation { get; set; }
}
