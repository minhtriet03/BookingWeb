﻿namespace BookingWeb.Server.ViewModels;

public class ChuyenXeVM
{
    public int IdChuyenXe { get; set; }

    public String? ThoiGianKh { get; set; }

    public string? ThoiGianDen { get; set; }

    public bool? TrangThai { get; set; }
    
    public XeVM? XeVM { get; set; }
    
    public TuyenDuongVM? TuyenDuongVM { get; set; }
}