using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Loaixe
{
    public int IdLoai { get; set; }

    public string? TenLoai { get; set; }

    public int? SoGhe { get; set; }

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
