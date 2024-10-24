using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Phanquyen
{
    public int IdQuyen { get; set; }

    public string? TenQuyen { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
