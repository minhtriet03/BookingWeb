﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models;

public partial class Nguoidung
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Role { get; set; }

    public int? IdAccount { get; set; }

    public virtual Taikhoan? IdAccountNavigation { get; set; }

    public virtual ICollection<Phieudat> Phieudats { get; set; } = new List<Phieudat>();
}
