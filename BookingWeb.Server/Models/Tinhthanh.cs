using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Tinhthanh
{
    public int IdTinhThanh { get; set; }

    public string? TenTinhThanh { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<Benxe> Benxes { get; set; } = new List<Benxe>();
}
