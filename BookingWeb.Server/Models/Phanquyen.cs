using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Phanquyen
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdQuyen { get; set; }

    [StringLength(255)]
    [Unicode(true)]
    public string? TenQuyen { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
