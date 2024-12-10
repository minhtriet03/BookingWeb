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

    public bool TrangThai { get; set; }

    public int IdAccount { get; set; }

    public virtual Taikhoan? IdAccountNavigation { get; set; } = null!;

    public virtual ICollection<Phieudat> Phieudats { get; set; } = new List<Phieudat>();
}
