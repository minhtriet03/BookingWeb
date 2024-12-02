using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Taikhoan
{
    public int IdAccount { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdQuyen { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Phanquyen IdQuyenNavigation { get; set; } = null!;

    public virtual ICollection<Nguoidung> Nguoidungs { get; set; } = new List<Nguoidung>();
}
