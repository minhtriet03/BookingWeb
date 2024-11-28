using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Chuyenxe
{
    public int IdChuyenXe { get; set; }

    public int? IdXe { get; set; }

    public int? IdTuyenDuong { get; set; }

    public string? ThoiGianKh { get; set; }

    public string? ThoiGianDen { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Tuyenduong? IdTuyenDuongNavigation { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }

    public virtual ICollection<Vexechuyenxe> Vexechuyenxes { get; set; } = new List<Vexechuyenxe>();
}
