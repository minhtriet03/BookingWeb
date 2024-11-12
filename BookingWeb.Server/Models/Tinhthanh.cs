using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Tinhthanh
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTinhThanh { get; set; }

    public string? TenTinhThanh { get; set; }

    public virtual ICollection<Benxe> Benxes { get; set; } = new List<Benxe>();
}
