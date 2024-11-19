using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Nguoidung
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { get; set; }

    [StringLength(255)]
    [Unicode(true)]
    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool TrangThai { get; set; }
    
    public int? IdAccount { get; set; }

    public virtual Taikhoan? IdAccountNavigation { get; set; }

    public virtual ICollection<Phieudat> Phieudats { get; set; } = new List<Phieudat>();
}
