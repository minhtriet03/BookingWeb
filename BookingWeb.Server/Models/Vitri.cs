using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vitri
{
    public int IdViTriGhe { get; set; }

    public int IdXe { get; set; }

    public string? Maso { get; set; }

    public bool? TrangThai { get; set; }

    // Quan hệ nhiều-nhiều với Xe thông qua XeVitri
    public virtual ICollection<XeVitri> XeVitries { get; set; } = new List<XeVitri>();

    // Quan hệ một-nhiều với Vexe
    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
