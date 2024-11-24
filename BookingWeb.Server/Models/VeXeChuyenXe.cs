using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vexechuyenxe
{
    public int IdVeXe { get; set; }

    public int IdChuyenXe { get; set; }

    public DateOnly? NgayKhoiHanh { get; set; }

    public DateOnly? NgayDen { get; set; }

    public virtual Chuyenxe IdChuyenXeNavigation { get; set; } = null!;

    public virtual Vexe IdVeXeNavigation { get; set; } = null!;
}
