﻿using System;
using System.Collections.Generic;

namespace BookingWeb.Server.Models;

public partial class Tuyenduong
{
    public int IdTuyenDuong { get; set; }

    public int? NoiKhoiHanh { get; set; }

    public int? NoiDen { get; set; }

    public decimal? KhoangCach { get; set; }

    public virtual ICollection<Chuyenxe> Chuyenxes { get; set; } = new List<Chuyenxe>();

    public virtual Benxe? NoiDenNavigation { get; set; }

    public virtual Benxe? NoiKhoiHanhNavigation { get; set; }
}