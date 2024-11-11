﻿using System;
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

    public virtual DbSet<Vitri> Vitris { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=ToanLD;Initial Catalog=BookingBus;Persist Security Info=True;User ID=sa;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Benxe>(entity =>
        {
            entity.HasKey(e => e.IdBenXe).HasName("PK__benxe__5D85FA845457C57C");

            entity.ToTable("benxe");

            entity.Property(e => e.IdBenXe)
                .ValueGeneratedNever()
                .HasColumnName("ID_BenXe");
            entity.Property(e => e.IdTinhThanh).HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenBenXe)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTinhThanhNavigation).WithMany(p => p.Benxes)
                .HasForeignKey(d => d.IdTinhThanh)
                .HasConstraintName("fk_benxe_tinhthanh");
        });

        modelBuilder.Entity<Chuyenxe>(entity =>
        {
            entity.HasKey(e => e.IdChuyenXe).HasName("PK__chuyenxe__108DC34AC2F09492");

            entity.ToTable("chuyenxe");

            entity.Property(e => e.IdChuyenXe)
                .ValueGeneratedNever()
                .HasColumnName("ID_ChuyenXe");
            entity.Property(e => e.IdTuyenDuong).HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.ThoiGianDen)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_GianDen");
            entity.Property(e => e.ThoiGianKh)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_GianKH");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTuyenDuongNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdTuyenDuong)
                .HasConstraintName("fk_chuyenxe_tuyenduong");

            entity.HasOne(d => d.IdXeNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdXe)
                .HasConstraintName("fk_chuyenxe_xe");
        });

        modelBuilder.Entity<Loaixe>(entity =>
        {
            entity.HasKey(e => e.IdLoai).HasName("PK__loaixe__914C2314CF7F9441");

            entity.ToTable("loaixe");

            entity.Property(e => e.IdLoai)
                .ValueGeneratedNever()
                .HasColumnName("ID_Loai");
            entity.Property(e => e.SoGhe).HasColumnName("So_Ghe");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ten_Loai");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__nguoidun__ED4DE4426067B775");

            entity.ToTable("nguoidung");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("ID_User");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Dia_Chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Ho_Ten");
            entity.Property(e => e.IdAccount).HasColumnName("ID_Account");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Nguoidungs)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("fk_nguoidung_taikhoan");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.IdQuyen).HasName("PK__phanquye__D219AE52A6951B83");

            entity.ToTable("phanquyen");

            entity.Property(e => e.IdQuyen)
                .ValueGeneratedNever()
                .HasColumnName("ID_Quyen");
            entity.Property(e => e.TenQuyen)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Phieudat>(entity =>
        {
            entity.HasKey(e => e.IdPhieu).HasName("PK__phieudat__E61CE97E43D3D4D5");

            entity.ToTable("phieudat");

            entity.Property(e => e.IdPhieu)
                .ValueGeneratedNever()
                .HasColumnName("ID_Phieu");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.NgayLap).HasColumnName("Ngay_Lap");
            entity.Property(e => e.TongTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tong_Tien");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Phieudats)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phieudat_nguoidung");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__taikhoan__213379EBC673E920");

            entity.ToTable("taikhoan");

            entity.Property(e => e.IdAccount)
                .ValueGeneratedNever()
                .HasColumnName("ID_Account");
            entity.Property(e => e.IdQuyen).HasColumnName("ID_Quyen");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdQuyenNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.IdQuyen)
                .HasConstraintName("fk_taikhoan_phanquyen");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.IdThanhToan).HasName("PK__thanhtoa__AB2E563157EAFBD3");

            entity.ToTable("thanhtoan");

            entity.Property(e => e.IdThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("ID_ThanhToan");
            entity.Property(e => e.IdPhieuDat).HasColumnName("ID_PhieuDat");
            entity.Property(e => e.PhuongThucTt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PhuongThuc_TT");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("So_Tien");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPhieuDatNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.IdPhieuDat)
                .HasConstraintName("fk_thanhtoan_phieudat");
        });

        modelBuilder.Entity<Tinhthanh>(entity =>
        {
            entity.HasKey(e => e.IdTinhThanh).HasName("PK__tinhthan__BC0EB70B259D3B97");

            entity.ToTable("tinhthanh");

            entity.Property(e => e.IdTinhThanh)
                .ValueGeneratedNever()
                .HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenTinhThanh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ten_TinhThanh");
        });

        modelBuilder.Entity<Tuyenduong>(entity =>
        {
            entity.HasKey(e => e.IdTuyenDuong).HasName("PK__tuyenduo__8D9665CDC1A77655");

            entity.ToTable("tuyenduong");

            entity.Property(e => e.IdTuyenDuong)
                .ValueGeneratedNever()
                .HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.KhoangCach)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Khoang_Cach");
            entity.Property(e => e.NoiDen).HasColumnName("Noi_Den");
            entity.Property(e => e.NoiKhoiHanh).HasColumnName("Noi_KhoiHanh");

            entity.HasOne(d => d.NoiDenNavigation).WithMany(p => p.TuyenduongNoiDenNavigations)
                .HasForeignKey(d => d.NoiDen)
                .HasConstraintName("fk_tuyenduong_noiden");

            entity.HasOne(d => d.NoiKhoiHanhNavigation).WithMany(p => p.TuyenduongNoiKhoiHanhNavigations)
                .HasForeignKey(d => d.NoiKhoiHanh)
                .HasConstraintName("fk_tuyenduong_noikh");
        });

        modelBuilder.Entity<Vexe>(entity =>
        {
            entity.HasKey(e => e.IdVe).HasName("PK__vexe__8B63A19C63B2D04E");

            entity.ToTable("vexe");

            entity.Property(e => e.IdVe)
                .ValueGeneratedNever()
                .HasColumnName("ID_Ve");
            entity.Property(e => e.GiaVe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Gia_Ve");
            entity.Property(e => e.IdChuyenXe).HasColumnName("ID_ChuyenXe");
            entity.Property(e => e.IdPhieu).HasColumnName("ID_Phieu");
            entity.Property(e => e.IdViTriGhe).HasColumnName("ID_ViTriGhe");
            entity.Property(e => e.NgayKhoiHanh).HasColumnName("Ngay_KhoiHanh");
            entity.Property(e => e.NgayVe).HasColumnName("Ngay_Ve");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdChuyenXeNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdChuyenXe)
                .HasConstraintName("fk_vexe_chuyenxe");

            entity.HasOne(d => d.IdPhieuNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdPhieu)
                .HasConstraintName("fk_vexe_phieudat");

            entity.HasOne(d => d.IdViTriGheNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdViTriGhe)
                .HasConstraintName("fk_vexe_vitri");
        });

        modelBuilder.Entity<Vitri>(entity =>
        {
            entity.HasKey(e => e.IdViTriGhe).HasName("PK__vitri__F0FA263A8F933914");

            entity.ToTable("vitri");

            entity.Property(e => e.IdViTriGhe)
                .ValueGeneratedNever()
                .HasColumnName("ID_ViTriGhe");
            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.ViTri1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ViTri");

            entity.HasOne(d => d.IdXeNavigation).WithMany(p => p.Vitris)
                .HasForeignKey(d => d.IdXe)
                .HasConstraintName("fk_vitri_xe");
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.IdXe).HasName("PK__xe__8B62515E4D0DB79D");

            entity.ToTable("xe");

            entity.Property(e => e.IdXe)
                .ValueGeneratedNever()
                .HasColumnName("ID_Xe");
            entity.Property(e => e.BienSo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Bien_So");
            entity.Property(e => e.IdLoai).HasColumnName("ID_Loai");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tinh_Trang");

            entity.HasOne(d => d.IdLoaiNavigation).WithMany(p => p.Xes)
                .HasForeignKey(d => d.IdLoai)
                .HasConstraintName("fk_xe_loaixe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}