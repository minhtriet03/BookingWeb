using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Vexe
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVe { get; set; }

    public int? IdPhieu { get; set; }

    public int? IdViTriGhe { get; set; }

    public int? IdChuyenXe { get; set; }

    public DateOnly? NgayKhoiHanh { get; set; }

    public DateOnly? NgayVe { get; set; }

    public string? TrangThai { get; set; }

    public virtual Chuyenxe? IdChuyenXeNavigation { get; set; }

    public virtual Phieudat? IdPhieuNavigation { get; set; }

    public virtual Vitri? IdViTriGheNavigation { get; set; }
}
