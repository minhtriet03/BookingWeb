using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Xe
{
    public int IdXe { get; set; }

    public int? IdLoai { get; set; }

    public string? BienSo { get; set; }

    public bool? TinhTrang { get; set; }

    // Quan hệ một-nhiều với Chuyenxe
    public virtual ICollection<Chuyenxe> Chuyenxes { get; set; } = new List<Chuyenxe>();

    // Quan hệ với Loaixe
    public virtual Loaixe? IdLoaiNavigation { get; set; }

    // Quan hệ nhiều-nhiều với Vitri thông qua XeVitri
    public virtual ICollection<XeVitri> XeVitries { get; set; } = new List<XeVitri>();


}
