using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vitri
{
    public int IdViTriGhe { get; set; }

    public int? IdXe { get; set; }

    public string? ViTri1 { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
