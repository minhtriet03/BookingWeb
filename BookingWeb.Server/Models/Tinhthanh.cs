using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Tinhthanh
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTinhThanh { get; set; }

    [StringLength(255)] 
    [Unicode(true)] 
    public string? TenTinhThanh { get; set; }

    public virtual ICollection<Benxe> Benxes { get; set; } = new List<Benxe>();
}
