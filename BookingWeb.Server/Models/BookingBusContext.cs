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

    public virtual DbSet<Vitrighe> Vitrighes { get; set; }

    public virtual DbSet<Xe> Xes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Benxe>(entity =>
        {
            entity.HasKey(e => e.IdBenXe).HasName("PK__benxe__5D85FA845A4C697A");

            entity.ToTable("benxe");

            entity.Property(e => e.IdBenXe).HasColumnName("ID_BenXe");
            entity.Property(e => e.IdTinhThanh).HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenBenXe).HasMaxLength(255);

            entity.HasOne(d => d.IdTinhThanhNavigation).WithMany(p => p.Benxes)
                .HasForeignKey(d => d.IdTinhThanh)
                .HasConstraintName("FK__benxe__ID_TinhTh__4E88ABD4");
        });

        modelBuilder.Entity<Chuyenxe>(entity =>
        {
            entity.HasKey(e => e.IdChuyenXe).HasName("PK__chuyenxe__108DC34A6A4C50A1");

            entity.ToTable("chuyenxe");

            entity.Property(e => e.IdChuyenXe).HasColumnName("ID_ChuyenXe");
            entity.Property(e => e.IdTuyenDuong).HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.ThoiGianDen)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_GianDen");
            entity.Property(e => e.ThoiGianKh)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_GianKH");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdTuyenDuongNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdTuyenDuong)
                .HasConstraintName("FK__chuyenxe__ID_Tuy__5070F446");

            entity.HasOne(d => d.IdXeNavigation).WithMany(p => p.Chuyenxes)
                .HasForeignKey(d => d.IdXe)
                .HasConstraintName("FK__chuyenxe__ID_Xe__4F7CD00D");
        });

        modelBuilder.Entity<Loaixe>(entity =>
        {
            entity.HasKey(e => e.IdLoai).HasName("PK__loaixe__914C2314F75A6B6A");

            entity.ToTable("loaixe");

            entity.Property(e => e.IdLoai).HasColumnName("ID_Loai");
            entity.Property(e => e.SoGhe).HasColumnName("So_Ghe");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(255)
                .HasColumnName("Ten_Loai");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__nguoidun__ED4DE4423AD0E841");

            entity.ToTable("nguoidung");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("Dia_Chi");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("Ho_Ten");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.IdQuyen).HasName("PK__phanquye__D219AE5247447240");

            entity.ToTable("phanquyen");

            entity.Property(e => e.IdQuyen).HasColumnName("ID_Quyen");
            entity.Property(e => e.TenQuyen).HasMaxLength(255);
        });

        modelBuilder.Entity<Phieudat>(entity =>
        {
            entity.HasKey(e => e.IdPhieu).HasName("PK__phieudat__E61CE97EA66E4176");

            entity.ToTable("phieudat");

            entity.Property(e => e.IdPhieu).HasColumnName("ID_Phieu");
            entity.Property(e => e.NgayLap).HasColumnName("Ngay_Lap");
            entity.Property(e => e.TongTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tong_Tien");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__taikhoan__ED4DE4424E71C01E");

            entity.ToTable("taikhoan");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("ID_User");
            entity.Property(e => e.IdQuyen).HasColumnName("ID_Quyen");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.IdQuyenNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.IdQuyen)
                .HasConstraintName("FK__taikhoan__ID_Quy__52593CB8");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Taikhoan)
                .HasForeignKey<Taikhoan>(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__taikhoan__ID_Use__5165187F");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.IdThanhToan).HasName("PK__thanhtoa__AB2E563152AAAAF2");

            entity.ToTable("thanhtoan");

            entity.Property(e => e.IdThanhToan).HasColumnName("ID_ThanhToan");
            entity.Property(e => e.IdVe).HasColumnName("ID_Ve");
            entity.Property(e => e.PhuongThucTt)
                .HasMaxLength(50)
                .HasColumnName("PhuongThuc_TT");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("So_Tien");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdVeNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.IdVe)
                .HasConstraintName("FK__thanhtoan__ID_Ve__534D60F1");
        });

        modelBuilder.Entity<Tinhthanh>(entity =>
        {
            entity.HasKey(e => e.IdTinhThanh).HasName("PK__tinhthan__BC0EB70BE8D641B3");

            entity.ToTable("tinhthanh");

            entity.Property(e => e.IdTinhThanh).HasColumnName("ID_TinhThanh");
            entity.Property(e => e.TenTinhThanh)
                .HasMaxLength(255)
                .HasColumnName("Ten_TinhThanh");
        });

        modelBuilder.Entity<Tuyenduong>(entity =>
        {
            entity.HasKey(e => e.IdTuyenDuong).HasName("PK__tuyenduo__8D9665CD938208C4");

            entity.ToTable("tuyenduong");

            entity.Property(e => e.IdTuyenDuong).HasColumnName("ID_TuyenDuong");
            entity.Property(e => e.KhoangCach)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Khoang_Cach");
            entity.Property(e => e.NoiDen)
                .HasMaxLength(255)
                .HasColumnName("Noi_Den");
            entity.Property(e => e.NoiKhoiHanh)
                .HasMaxLength(255)
                .HasColumnName("Noi_KhoiHanh");
        });

        modelBuilder.Entity<Vexe>(entity =>
        {
            entity.HasKey(e => e.IdVe).HasName("PK__vexe__8B63A19C226FAC6D");

            entity.ToTable("vexe");

            entity.Property(e => e.IdVe).HasColumnName("ID_Ve");
            entity.Property(e => e.GiaVe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Gia_Ve");
            entity.Property(e => e.IdPhieu).HasColumnName("ID_Phieu");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.NgayKhoiHanh).HasColumnName("Ngay_KhoiHanh");
            entity.Property(e => e.NgayVe).HasColumnName("Ngay_Ve");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdPhieuNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdPhieu)
                .HasConstraintName("FK__vexe__ID_Phieu__5441852A");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Vexes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__vexe__ID_User__5535A963");
        });

        modelBuilder.Entity<Vitrighe>(entity =>
        {
            entity.HasKey(e => e.IdViTriGhe).HasName("PK__vitrighe__F0FA263A4094A755");

            entity.ToTable("vitrighe");

            entity.Property(e => e.IdViTriGhe).HasColumnName("ID_ViTriGhe");
            entity.Property(e => e.TangViTri).HasColumnName("Tang_ViTri");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<Xe>(entity =>
        {
            entity.HasKey(e => e.IdXe).HasName("PK__xe__8B62515EE59701F2");

            entity.ToTable("xe");

            entity.Property(e => e.IdXe).HasColumnName("ID_Xe");
            entity.Property(e => e.BienSo)
                .HasMaxLength(15)
                .HasColumnName("Bien_So");
            entity.Property(e => e.MaTuyenDuong).HasColumnName("Ma_TuyenDuong");
            entity.Property(e => e.SoCho).HasColumnName("So_Cho");

            entity.HasOne(d => d.MaTuyenDuongNavigation).WithMany(p => p.Xes)
                .HasForeignKey(d => d.MaTuyenDuong)
                .HasConstraintName("FK__xe__Ma_TuyenDuon__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
