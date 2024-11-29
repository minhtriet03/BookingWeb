using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Models;

public partial class BookingBusContext : DbContext
{
    public BookingBusContext()
    {
    }

    public BookingBusContext(DbContextOptions<BookingBusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Benxe> Benxes { get; set; }

    public virtual DbSet<Chuyenxe> Chuyenxes { get; set; }

    public virtual DbSet<Loaixe> Loaixes { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Phanquyen> Phanquyens { get; set; }

    public virtual DbSet<Phieudat> Phieudats { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }

    public virtual DbSet<Tinhthanh> Tinhthanhs { get; set; }

    public virtual DbSet<Tuyenduong> Tuyenduongs { get; set; }

    public virtual DbSet<Vexe> Vexes { get; set; }

    public virtual DbSet<Vexechuyenxe> Vexechuyenxes { get; set; }

    public virtual DbSet<Vitri> Vitris { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    public virtual DbSet<Xevitri> Xevitris { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LD9DI6O;Initial Catalog=BookingBus;Persist Security Info=True;User ID=sa;Password=12345;Trust Server Certificate=True");



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}