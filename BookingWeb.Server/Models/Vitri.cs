using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vitri
{
    public int IdViTriGhe { get; set; }

    public string? ViTri1 { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();

    public virtual ICollection<Xevitri> Xevitris { get; set; } = new List<Xevitri>();

}
