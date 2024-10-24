using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Tuyenduong
{
    public int IdTuyenDuong { get; set; }

    public string? NoiKhoiHanh { get; set; }

    public string? NoiDen { get; set; }

    public decimal? KhoangCach { get; set; }

    public virtual ICollection<Chuyenxe> Chuyenxes { get; set; } = new List<Chuyenxe>();

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
