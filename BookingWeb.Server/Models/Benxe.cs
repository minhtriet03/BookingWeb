using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Benxe
{
    public int IdBenXe { get; set; }

    public int? IdTinhThanh { get; set; }

    public string? TenBenXe { get; set; }

    public virtual Tinhthanh? IdTinhThanhNavigation { get; set; }

    public virtual ICollection<Tuyenduong> TuyenduongNoiDenNavigations { get; set; } = new List<Tuyenduong>();

    public virtual ICollection<Tuyenduong> TuyenduongNoiKhoiHanhNavigations { get; set; } = new List<Tuyenduong>();
}
