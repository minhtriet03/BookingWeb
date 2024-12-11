using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Chuyenxe
{
    public int IdChuyenXe { get; set; }

    public int IdXe { get; set; }

    public int IdTuyenDuong { get; set; }

    public string? ThoiGianKh { get; set; }

    public string? ThoiGianDen { get; set; }
    public DateOnly NgayKhoiHanh { get; set; }

    public bool TrangThai { get; set; }

    public virtual Tuyenduong IdTuyenDuongNavigation { get; set; } = null!;

    public virtual Xe IdXeNavigation { get; set; } = null!;

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
