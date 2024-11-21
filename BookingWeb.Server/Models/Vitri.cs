using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vitri
{
    public int IdViTriGhe { get; set; }

    public int IdXe { get; set; }

    public string? Maso { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Xe IdXeNavigation { get; set; } = null!;

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
