using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Phieudat
{
    public int IdPhieu { get; set; }

    public DateOnly? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
