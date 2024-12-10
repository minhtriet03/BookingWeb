using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vexe
{
    public int IdVe { get; set; }

    public int? IdPhieu { get; set; }

    public string ViTriGhe { get; set; }

    public int IdChuyenXe { get; set; }

    public DateOnly NgayKhoiHanh { get; set; }

    public bool TrangThai { get; set; }

    public virtual Chuyenxe IdChuyenXeNavigation { get; set; } = null!;

    public virtual Phieudat? IdPhieuNavigation { get; set; } = null!;

    
}
