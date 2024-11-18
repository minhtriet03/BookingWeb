using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Vitri
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdViTriGhe { get; set; }

    public int? IdXe { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
