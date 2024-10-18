using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Nguoidung
{
    public int IdUser { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Role { get; set; }

    public virtual Taikhoan? Taikhoan { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
