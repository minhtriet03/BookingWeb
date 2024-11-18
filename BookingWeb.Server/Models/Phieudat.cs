using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Phieudat
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPhieu { get; set; }

    public int IdUser { get; set; }

    public DateOnly? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Nguoidung IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
