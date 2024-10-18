using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Taikhoan
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? IdQuyen { get; set; }

    public virtual Phanquyen? IdQuyenNavigation { get; set; }

    public virtual Nguoidung IdUserNavigation { get; set; } = null!;
}