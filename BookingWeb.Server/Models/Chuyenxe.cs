using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Chuyenxe
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdChuyenXe { get; set; }

    public int? IdXe { get; set; }

    public int? IdTuyenDuong { get; set; }

    public DateTime? ThoiGianKh { get; set; }

    public DateTime? ThoiGianDen { get; set; }

    public bool? TrangThai { get; set; }

    public virtual Tuyenduong? IdTuyenDuongNavigation { get; set; }

    public virtual Xe? IdXeNavigation { get; set; }

    public virtual ICollection<Vexe> Vexes { get; set; } = new List<Vexe>();
}
