using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Xevitri
{
    public int IdXe { get; set; }

    public int IdViTri { get; set; }

    public virtual Xe? IdXeNavigation { get; set; } = null!;

    public virtual Vitri? IdVitriNavigation { get; set; } = null!;
}
