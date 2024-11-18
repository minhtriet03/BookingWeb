using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Loaixe
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdLoai { get; set; }

    [StringLength(255)]
    [Unicode(true)]
    public string? TenLoai { get; set; }

    public int? SoGhe { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<Xe> Xes { get; set; } = new List<Xe>();
}
