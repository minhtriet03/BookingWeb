using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class XeVeX
{
    public int Id { get; set; }

    public int IdXe { get; set; }

    public int IdVe { get; set; }

    public virtual Vexe IdVeNavigation { get; set; } = null!;

    public virtual Xe IdXeNavigation { get; set; } = null!;
}
