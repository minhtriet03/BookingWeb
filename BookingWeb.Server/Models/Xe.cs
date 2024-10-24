using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Xe
{
    public int IdXe { get; set; }

    public string? BienSo { get; set; }

    public int? SoCho { get; set; }

    public int? MaTuyenDuong { get; set; }

    public virtual ICollection<Chuyenxe> Chuyenxes { get; set; } = new List<Chuyenxe>();

    public virtual Tuyenduong? MaTuyenDuongNavigation { get; set; }
}
