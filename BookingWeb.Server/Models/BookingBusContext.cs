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

    public virtual DbSet<Vitri> Vitris { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Benxe>(entity =>
        {
            entity.HasKey(e => e.IdBenXe).HasName("PK__benxe__5D85FA844FDC4F24");

            entity.ToTable("benxe");

            entity.Property(e => e.IdBenXe).HasColumnName("ID_BenXe");
            entity.Property(e => e.IdTinhThanh).HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenBenXe)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdTinhThanhNavigation).WithMany(p => p.Benxes)
                .HasForeignKey(d => d.IdTinhThanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_benxe_tinhthanh");
        });

        modelBuilder.Entity<Chuyenxe>(entity =>
        {
            entity.HasKey(e => e.IdChuyenXe).HasName("PK__chuyenxe__108DC34A90342C66");

            entity.ToTable("chuyenxe");

            entity.Property(e => e.IdChuyenXe).HasColumnName("ID_ChuyenXe");
            entity.Property(e => e.IdTuyenDuong).HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.ThoiGianDen)
                .HasMaxLength(50)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Thoi_GianDen");
            entity.Property(e => e.ThoiGianKh)
                .HasMaxLength(50)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Thoi_GianKH");

            entity.HasOne(d => d.IdTuyenDuongNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdTuyenDuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chuyenxe_tuyenduong");

            entity.HasOne(d => d.IdXeNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chuyenxe_xe");
        });

        modelBuilder.Entity<Loaixe>(entity =>
        {
            entity.HasKey(e => e.IdLoai).HasName("PK__loaixe__914C231484162537");

            entity.ToTable("loaixe");

            entity.Property(e => e.IdLoai).HasColumnName("ID_Loai");
            entity.Property(e => e.SoGhe)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("So_Ghe");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Ten_Loai");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__nguoidun__ED4DE442BDF9A79A");

            entity.ToTable("nguoidung");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Dia_Chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Ho_Ten");
            entity.Property(e => e.IdAccount).HasColumnName("ID_Account");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Nguoidungs)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nguoidung_taikhoan");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.IdQuyen).HasName("PK__phanquye__D219AE521EF8DFDB");

            entity.ToTable("phanquyen");

            entity.Property(e => e.IdQuyen).HasColumnName("ID_Quyen");
            entity.Property(e => e.TenQuyen)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Phieudat>(entity =>
        {
            entity.HasKey(e => e.IdPhieu).HasName("PK__phieudat__E61CE97EEA5EA967");

            entity.ToTable("phieudat");

            entity.Property(e => e.IdPhieu).HasColumnName("ID_Phieu");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Ngay_Lap");
            entity.Property(e => e.TongTien)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tong_Tien");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Phieudats)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_phieudat_nguoidung");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__taikhoan__213379EB2699579B");

            entity.ToTable("taikhoan");

            entity.Property(e => e.IdAccount).HasColumnName("ID_Account");
            entity.Property(e => e.IdQuyen).HasColumnName("ID_Quyen");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.IdQuyenNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.IdQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_taikhoan_phanquyen");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.IdThanhToan).HasName("PK__thanhtoa__AB2E56314DA22CB2");

            entity.ToTable("thanhtoan");

            entity.Property(e => e.IdThanhToan).HasColumnName("ID_ThanhToan");
            entity.Property(e => e.IdPhieuDat).HasColumnName("ID_PhieuDat");
            entity.Property(e => e.PhuongThucTt)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("PhuongThuc_TT");
            entity.Property(e => e.SoTien)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("So_Tien");

            entity.HasOne(d => d.IdPhieuDatNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.IdPhieuDat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_thanhtoan_phieudat");
        });

        modelBuilder.Entity<Tinhthanh>(entity =>
        {
            entity.HasKey(e => e.IdTinhThanh).HasName("PK__tinhthan__BC0EB70B648D8A7D");

            entity.ToTable("tinhthanh");

            entity.Property(e => e.IdTinhThanh).HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenTinhThanh)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Ten_TinhThanh");
        });

        modelBuilder.Entity<Tuyenduong>(entity =>
        {
            entity.HasKey(e => e.IdTuyenDuong).HasName("PK__tuyenduo__8D9665CDB5016B03");

            entity.ToTable("tuyenduong");

            entity.Property(e => e.IdTuyenDuong).HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.GiaVe)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Gia_Ve");
            entity.Property(e => e.KhoangCach)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Khoang_Cach");
            entity.Property(e => e.NoiDen).HasColumnName("Noi_Den");
            entity.Property(e => e.NoiKhoiHanh).HasColumnName("Noi_KhoiHanh");

            entity.HasOne(d => d.NoiDenNavigation).WithMany(p => p.TuyenduongNoiDenNavigations)
                .HasForeignKey(d => d.NoiDen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tuyenduong_benxe1");

            entity.HasOne(d => d.NoiKhoiHanhNavigation).WithMany(p => p.TuyenduongNoiKhoiHanhNavigations)
                .HasForeignKey(d => d.NoiKhoiHanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tuyenduong_benxe");
        });

        modelBuilder.Entity<Vexe>(entity =>
        {
            entity.HasKey(e => e.IdVe).HasName("PK__vexe__8B63A19CBA40D288");

            entity.ToTable("vexe");

            entity.Property(e => e.IdVe).HasColumnName("ID_Ve");
            entity.Property(e => e.IdChuyenXe).HasColumnName("ID_ChuyenXe");
            entity.Property(e => e.IdPhieu).HasColumnName("ID_Phieu");
            entity.Property(e => e.IdViTriGhe).HasColumnName("ID_ViTriGhe");

            entity.HasOne(d => d.IdChuyenXeNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdChuyenXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vexe_chuyenxe");

            entity.HasOne(d => d.IdPhieuNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdPhieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vexe_phieudat");

            entity.HasOne(d => d.IdViTriGheNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdViTriGhe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vexe_vitri");
        });

        modelBuilder.Entity<Vitri>(entity =>
        {
            entity.HasKey(e => e.IdViTriGhe).HasName("PK__vitri__F0FA263AAC450897");

            entity.ToTable("vitri");

            entity.Property(e => e.IdViTriGhe).HasColumnName("ID_ViTriGhe");
            entity.Property(e => e.ViTri1)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ViTri");
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.IdXe).HasName("PK__xe__8B62515E52C40997");

            entity.ToTable("xe");

            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.BienSo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Bien_So");
            entity.Property(e => e.IdLoai).HasColumnName("ID_Loai");
            entity.Property(e => e.TinhTrang).HasColumnName("Tinh_Trang");

            entity.HasOne(d => d.IdLoaiNavigation).WithMany(p => p.Xes)
                .HasForeignKey(d => d.IdLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_xe_loaixe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
