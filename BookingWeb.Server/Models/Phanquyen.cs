using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Phanquyen
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdQuyen { get; set; }

    public string? TenQuyen { get; set; }

    public bool? TrangThai { get; set; }


    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
