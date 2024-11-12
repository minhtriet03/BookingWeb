using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Server.Models;

public partial class Taikhoan
{
   
    public int IdAccount { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? IdQuyen { get; set; }

    public virtual Phanquyen? IdQuyenNavigation { get; set; }

    public virtual ICollection<Nguoidung> Nguoidungs { get; set; } = new List<Nguoidung>();
}
