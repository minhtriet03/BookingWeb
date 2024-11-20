using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.ViewModels;

public class LoaiXeVM
{
    public int IdLoai { get; set; }
    public string? TenLoai { get; set; }
    public int? SoGhe { get; set; }
    public bool? TrangThai { get; set; }
}