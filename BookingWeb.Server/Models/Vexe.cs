using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Vexe
{
    public int IdVe { get; set; }

    public int? IdPhieu { get; set; }

    public int? IdViTriGhe { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Phieudat? IdPhieuNavigation { get; set; }

    public virtual Vitri? IdViTriGheNavigation { get; set; }

    public virtual ICollection<Vexechuyenxe> Vexechuyenxes { get; set; } = new List<Vexechuyenxe>();
}
