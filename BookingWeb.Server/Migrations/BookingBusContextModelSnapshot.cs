﻿// <auto-generated />
using System;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingWeb.Server.Migrations
{
    [DbContext(typeof(BookingBusContext))]
    partial class BookingBusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingWeb.Server.Models.Benxe", b =>
                {
                    b.Property<int>("IdBenXe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_BenXe");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBenXe"));

                    b.Property<int?>("IdTinhThanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TinhThanh")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("TenBenXe")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdBenXe")
                        .HasName("PK__benxe__5D85FA84A6235780");

                    b.HasIndex(new[] { "IdTinhThanh" }, "IX_benxe_ID_TinhThanh");

                    b.ToTable("benxe", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Chuyenxe", b =>
                {
                    b.Property<int>("IdChuyenXe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ChuyenXe");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdChuyenXe"));

                    b.Property<int?>("IdTuyenDuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TuyenDuong")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("IdXe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Xe")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("ThoiGianDen")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Thoi_GianDen")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ThoiGianKh")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Thoi_GianKH")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdChuyenXe")
                        .HasName("PK__chuyenxe__108DC34A04704F45");

                    b.HasIndex(new[] { "IdTuyenDuong" }, "IX_chuyenxe_ID_TuyenDuong");

                    b.HasIndex(new[] { "IdXe" }, "IX_chuyenxe_ID_Xe");

                    b.ToTable("chuyenxe", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Loaixe", b =>
                {
                    b.Property<int>("IdLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Loai");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoai"));

                    b.Property<int?>("SoGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("So_Ghe")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("TenLoai")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Ten_Loai")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdLoai")
                        .HasName("PK__loaixe__914C23141C318AD3");

                    b.ToTable("loaixe", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Nguoidung", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_User");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("DiaChi")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Dia_Chi")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("HoTen")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Ho_Ten")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Account")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Phone")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdUser")
                        .HasName("PK__nguoidun__ED4DE44201ABFF36");

                    b.HasIndex(new[] { "IdAccount" }, "IX_nguoidung_ID_Account");

                    b.ToTable("nguoidung", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Phanquyen", b =>
                {
                    b.Property<int>("IdQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Quyen");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdQuyen"));

                    b.Property<string>("TenQuyen")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdQuyen")
                        .HasName("PK__phanquye__D219AE5225D17883");

                    b.ToTable("phanquyen", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Phieudat", b =>
                {
                    b.Property<int>("IdPhieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Phieu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPhieu"));

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("ID_User");

                    b.Property<DateOnly?>("NgayLap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("Ngay_Lap")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<decimal?>("TongTien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Tong_Tien")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdPhieu")
                        .HasName("PK__phieudat__E61CE97E924175EE");

                    b.HasIndex(new[] { "IdUser" }, "IX_phieudat_ID_User");

                    b.ToTable("phieudat", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Taikhoan", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"));

                    b.Property<int?>("IdQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Quyen")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Password")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdAccount")
                        .HasName("PK__taikhoan__213379EB7E7880B7");

                    b.HasIndex(new[] { "IdQuyen" }, "IX_taikhoan_ID_Quyen");

                    b.ToTable("taikhoan", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Thanhtoan", b =>
                {
                    b.Property<int>("IdThanhToan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ThanhToan");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdThanhToan"));

                    b.Property<int?>("IdPhieuDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PhieuDat")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("PhuongThucTt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PhuongThuc_TT")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<decimal?>("SoTien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("So_Tien")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdThanhToan")
                        .HasName("PK__thanhtoa__AB2E563188254449");

                    b.HasIndex(new[] { "IdPhieuDat" }, "IX_thanhtoan_ID_PhieuDat");

                    b.ToTable("thanhtoan", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Tinhthanh", b =>
                {
                    b.Property<int>("IdTinhThanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TinhThanh");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTinhThanh"));

                    b.Property<string>("TenTinhThanh")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Ten_TinhThanh")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdTinhThanh")
                        .HasName("PK__tinhthan__BC0EB70B84090C12");

                    b.ToTable("tinhthanh", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Tuyenduong", b =>
                {
                    b.Property<int>("IdTuyenDuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TuyenDuong");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTuyenDuong"));

                    b.Property<decimal?>("GiaVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Gia_Ve")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<decimal?>("KhoangCach")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Khoang_Cach")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("NoiDen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Noi_Den")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("NoiKhoiHanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Noi_KhoiHanh")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdTuyenDuong")
                        .HasName("PK__tuyenduo__8D9665CD7174435A");

                    b.HasIndex(new[] { "NoiDen" }, "IX_tuyenduong_Noi_Den");

                    b.HasIndex(new[] { "NoiKhoiHanh" }, "IX_tuyenduong_Noi_KhoiHanh");

                    b.ToTable("tuyenduong", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vexe", b =>
                {
                    b.Property<int>("IdVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Ve");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVe"));

                    b.Property<int?>("IdPhieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Phieu")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("IdViTriGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ViTriGhe")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdVe")
                        .HasName("PK__vexe__8B63A19C210D5D44");

                    b.HasIndex(new[] { "IdPhieu" }, "IX_vexe_ID_Phieu");

                    b.HasIndex(new[] { "IdViTriGhe" }, "IX_vexe_ID_ViTriGhe");

                    b.ToTable("vexe", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vexechuyenxe", b =>
                {
                    b.Property<int>("IdVeXe")
                        .HasColumnType("int")
                        .HasColumnName("ID_VeXe");

                    b.Property<int>("IdChuyenXe")
                        .HasColumnType("int")
                        .HasColumnName("ID_ChuyenXe");

                    b.Property<DateOnly?>("NgayDen")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("NgayKhoiHanh")
                        .HasColumnType("date");

                    b.HasKey("IdVeXe", "IdChuyenXe");

                    b.HasIndex(new[] { "IdChuyenXe" }, "IX_vexechuyenxe_ID_ChuyenXe");

                    b.ToTable("vexechuyenxe", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vitri", b =>
                {
                    b.Property<int>("IdViTriGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ViTriGhe");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdViTriGhe"));

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("ViTri1")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ViTri")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdViTriGhe")
                        .HasName("PK__vitri__F0FA263A0546993C");

                    b.ToTable("vitri", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Xe", b =>
                {
                    b.Property<int>("IdXe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Xe");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdXe"));

                    b.Property<string>("BienSo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Bien_So")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("IdLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Loai")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool?>("TinhTrang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Tinh_Trang")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("IdXe")
                        .HasName("PK__xe__8B62515E2A4BD620");

                    b.HasIndex(new[] { "IdLoai" }, "IX_xe_ID_Loai");

                    b.ToTable("xe", (string)null);
                });

            modelBuilder.Entity("Xevitri", b =>
                {
                    b.Property<int>("IdXe")
                        .HasColumnType("int")
                        .HasColumnName("ID_Xe");

                    b.Property<int>("IdViTri")
                        .HasColumnType("int")
                        .HasColumnName("ID_ViTri");

                    b.HasKey("IdXe", "IdViTri");

                    b.HasIndex("IdViTri");

                    b.ToTable("xevitri", (string)null);
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Benxe", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Tinhthanh", "IdTinhThanhNavigation")
                        .WithMany("Benxes")
                        .HasForeignKey("IdTinhThanh")
                        .HasConstraintName("fk_benxe_tinhthanh");

                    b.Navigation("IdTinhThanhNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Chuyenxe", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Tuyenduong", "IdTuyenDuongNavigation")
                        .WithMany("Chuyenxes")
                        .HasForeignKey("IdTuyenDuong")
                        .HasConstraintName("fk_chuyenxe_tuyenduong");

                    b.HasOne("BookingWeb.Server.Models.Xe", "IdXeNavigation")
                        .WithMany("Chuyenxes")
                        .HasForeignKey("IdXe")
                        .HasConstraintName("fk_chuyenxe_xe");

                    b.Navigation("IdTuyenDuongNavigation");

                    b.Navigation("IdXeNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Nguoidung", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Taikhoan", "IdAccountNavigation")
                        .WithMany("Nguoidungs")
                        .HasForeignKey("IdAccount")
                        .HasConstraintName("fk_nguoidung_taikhoan");

                    b.Navigation("IdAccountNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Phieudat", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Nguoidung", "IdUserNavigation")
                        .WithMany("Phieudats")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("fk_phieudat_nguoidung");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Taikhoan", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Phanquyen", "IdQuyenNavigation")
                        .WithMany("Taikhoans")
                        .HasForeignKey("IdQuyen")
                        .HasConstraintName("fk_taikhoan_phanquyen");

                    b.Navigation("IdQuyenNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Thanhtoan", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Phieudat", "IdPhieuDatNavigation")
                        .WithMany("Thanhtoans")
                        .HasForeignKey("IdPhieuDat")
                        .HasConstraintName("fk_thanhtoan_phieudat");

                    b.Navigation("IdPhieuDatNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Tuyenduong", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Benxe", "NoiDenNavigation")
                        .WithMany("TuyenduongNoiDenNavigations")
                        .HasForeignKey("NoiDen")
                        .HasConstraintName("fk_tuyenduong_noiden");

                    b.HasOne("BookingWeb.Server.Models.Benxe", "NoiKhoiHanhNavigation")
                        .WithMany("TuyenduongNoiKhoiHanhNavigations")
                        .HasForeignKey("NoiKhoiHanh")
                        .HasConstraintName("fk_tuyenduong_noikh");

                    b.Navigation("NoiDenNavigation");

                    b.Navigation("NoiKhoiHanhNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vexe", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Phieudat", "IdPhieuNavigation")
                        .WithMany("Vexes")
                        .HasForeignKey("IdPhieu")
                        .HasConstraintName("fk_vexe_phieudat");

                    b.HasOne("BookingWeb.Server.Models.Vitri", "IdViTriGheNavigation")
                        .WithMany("Vexes")
                        .HasForeignKey("IdViTriGhe")
                        .HasConstraintName("fk_vexe_vitri");

                    b.Navigation("IdPhieuNavigation");

                    b.Navigation("IdViTriGheNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vexechuyenxe", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Chuyenxe", "IdChuyenXeNavigation")
                        .WithMany("Vexechuyenxes")
                        .HasForeignKey("IdChuyenXe")
                        .IsRequired()
                        .HasConstraintName("FK_vexechuyenxe_chuyenxe");

                    b.HasOne("BookingWeb.Server.Models.Vexe", "IdVeXeNavigation")
                        .WithMany("Vexechuyenxes")
                        .HasForeignKey("IdVeXe")
                        .IsRequired()
                        .HasConstraintName("FK_vexechuyenxe_vexe");

                    b.Navigation("IdChuyenXeNavigation");

                    b.Navigation("IdVeXeNavigation");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Xe", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Loaixe", "IdLoaiNavigation")
                        .WithMany("Xes")
                        .HasForeignKey("IdLoai")
                        .HasConstraintName("fk_xe_loaixe");

                    b.Navigation("IdLoaiNavigation");
                });

            modelBuilder.Entity("Xevitri", b =>
                {
                    b.HasOne("BookingWeb.Server.Models.Vitri", null)
                        .WithMany()
                        .HasForeignKey("IdViTri")
                        .IsRequired()
                        .HasConstraintName("FK_xevitri_vitri");

                    b.HasOne("BookingWeb.Server.Models.Xe", null)
                        .WithMany()
                        .HasForeignKey("IdXe")
                        .IsRequired()
                        .HasConstraintName("FK_xevitri_xe");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Benxe", b =>
                {
                    b.Navigation("TuyenduongNoiDenNavigations");

                    b.Navigation("TuyenduongNoiKhoiHanhNavigations");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Chuyenxe", b =>
                {
                    b.Navigation("Vexechuyenxes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Loaixe", b =>
                {
                    b.Navigation("Xes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Nguoidung", b =>
                {
                    b.Navigation("Phieudats");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Phanquyen", b =>
                {
                    b.Navigation("Taikhoans");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Phieudat", b =>
                {
                    b.Navigation("Thanhtoans");

                    b.Navigation("Vexes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Taikhoan", b =>
                {
                    b.Navigation("Nguoidungs");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Tinhthanh", b =>
                {
                    b.Navigation("Benxes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Tuyenduong", b =>
                {
                    b.Navigation("Chuyenxes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vexe", b =>
                {
                    b.Navigation("Vexechuyenxes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Vitri", b =>
                {
                    b.Navigation("Vexes");
                });

            modelBuilder.Entity("BookingWeb.Server.Models.Xe", b =>
                {
                    b.Navigation("Chuyenxes");
                });
#pragma warning restore 612, 618
        }
    }
}
