using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class XeViTri
{
    public int Id { get; set; }

    public int? IdXe { get; set; }

    public int? IdViTri { get; set; }

    public virtual Vitri? IdViTriNavigation { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }
}
