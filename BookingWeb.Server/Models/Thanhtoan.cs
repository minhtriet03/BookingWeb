using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Thanhtoan
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdThanhToan { get; set; }

    public int? IdPhieuDat { get; set; }

    public decimal? SoTien { get; set; }

    public string? PhuongThucTt { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Phieudat? IdPhieuDatNavigation { get; set; }
}
