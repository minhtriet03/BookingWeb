using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Xe
{
    public int IdXe { get; set; }

    public int? IdLoai { get; set; }

    public string? BienSo { get; set; }

    public bool? TinhTrang { get; set; }

    public virtual ICollection<Chuyenxe> Chuyenxes { get; set; } = new List<Chuyenxe>();

    public virtual Loaixe? IdLoaiNavigation { get; set; }

    public virtual ICollection<Vitri> Vitris { get; set; } = new List<Vitri>();

    //public virtual ICollection<XeVeXe> XeVeXes { get; set; } = new List<XeVeXe>();
}
