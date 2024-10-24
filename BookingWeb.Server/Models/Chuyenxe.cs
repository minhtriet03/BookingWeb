using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Chuyenxe
{
    public int IdChuyenXe { get; set; }

    public int? IdXe { get; set; }

    public int? IdTuyenDuong { get; set; }

    public DateTime? ThoiGianKh { get; set; }

    public DateTime? ThoiGianDen { get; set; }

    public string? TrangThai { get; set; }

    public virtual Tuyenduong? IdTuyenDuongNavigation { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }
}
