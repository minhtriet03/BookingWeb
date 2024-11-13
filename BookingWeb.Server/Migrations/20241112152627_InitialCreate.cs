using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loaixe",
                columns: table => new
                {
                    ID_Loai = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ten_Loai = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    So_Ghe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loaixe__914C2314CF7F9441", x => x.ID_Loai);
                });

            migrationBuilder.CreateTable(
                name: "phanquyen",
                columns: table => new
                {
                    ID_Quyen = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenQuyen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phanquye__D219AE52A6951B83", x => x.ID_Quyen);
                });

            migrationBuilder.CreateTable(
                name: "tinhthanh",
                columns: table => new
                {
                    ID_TinhThanh = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ten_TinhThanh = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tinhthan__BC0EB70B259D3B97", x => x.ID_TinhThanh);
                });

            migrationBuilder.CreateTable(
                name: "xe",
                columns: table => new
                {
                    ID_Xe = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Loai = table.Column<int>(type: "int", nullable: true),
                    Bien_So = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Tinh_Trang = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__xe__8B62515E4D0DB79D", x => x.ID_Xe);
                    table.ForeignKey(
                        name: "fk_xe_loaixe",
                        column: x => x.ID_Loai,
                        principalTable: "loaixe",
                        principalColumn: "ID_Loai");
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    ID_Account = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ID_Quyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__taikhoan__213379EBC673E920", x => x.ID_Account);
                    table.ForeignKey(
                        name: "fk_taikhoan_phanquyen",
                        column: x => x.ID_Quyen,
                        principalTable: "phanquyen",
                        principalColumn: "ID_Quyen");
                });

            migrationBuilder.CreateTable(
                name: "benxe",
                columns: table => new
                {
                    ID_BenXe = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_TinhThanh = table.Column<int>(type: "int", nullable: true),
                    TenBenXe = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__benxe__5D85FA845457C57C", x => x.ID_BenXe);
                    table.ForeignKey(
                        name: "fk_benxe_tinhthanh",
                        column: x => x.ID_TinhThanh,
                        principalTable: "tinhthanh",
                        principalColumn: "ID_TinhThanh");
                });

            migrationBuilder.CreateTable(
                name: "vitri",
                columns: table => new
                {
                    ID_ViTriGhe = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Xe = table.Column<int>(type: "int", nullable: true),
                    ViTri = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vitri__F0FA263A8F933914", x => x.ID_ViTriGhe);
                    table.ForeignKey(
                        name: "fk_vitri_xe",
                        column: x => x.ID_Xe,
                        principalTable: "xe",
                        principalColumn: "ID_Xe");
                });

            migrationBuilder.CreateTable(
                name: "nguoidung",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ho_Ten = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Dia_Chi = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    ID_Account = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nguoidun__ED4DE4426067B775", x => x.ID_User);
                    table.ForeignKey(
                        name: "fk_nguoidung_taikhoan",
                        column: x => x.ID_Account,
                        principalTable: "taikhoan",
                        principalColumn: "ID_Account");
                });

            migrationBuilder.CreateTable(
                name: "tuyenduong",
                columns: table => new
                {
                    ID_TuyenDuong = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Noi_KhoiHanh = table.Column<int>(type: "int", nullable: true),
                    Noi_Den = table.Column<int>(type: "int", nullable: true),
                    Khoang_Cach = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tuyenduo__8D9665CDC1A77655", x => x.ID_TuyenDuong);
                    table.ForeignKey(
                        name: "fk_tuyenduong_noiden",
                        column: x => x.Noi_Den,
                        principalTable: "benxe",
                        principalColumn: "ID_BenXe");
                    table.ForeignKey(
                        name: "fk_tuyenduong_noikh",
                        column: x => x.Noi_KhoiHanh,
                        principalTable: "benxe",
                        principalColumn: "ID_BenXe");
                });

            migrationBuilder.CreateTable(
                name: "phieudat",
                columns: table => new
                {
                    ID_Phieu = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    Ngay_Lap = table.Column<DateOnly>(type: "date", nullable: true),
                    Tong_Tien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phieudat__E61CE97E43D3D4D5", x => x.ID_Phieu);
                    table.ForeignKey(
                        name: "fk_phieudat_nguoidung",
                        column: x => x.ID_User,
                        principalTable: "nguoidung",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "chuyenxe",
                columns: table => new
                {
                    ID_ChuyenXe = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Xe = table.Column<int>(type: "int", nullable: true),
                    ID_TuyenDuong = table.Column<int>(type: "int", nullable: true),
                    Thoi_GianKH = table.Column<DateTime>(type: "datetime", nullable: true),
                    Thoi_GianDen = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chuyenxe__108DC34AC2F09492", x => x.ID_ChuyenXe);
                    table.ForeignKey(
                        name: "fk_chuyenxe_tuyenduong",
                        column: x => x.ID_TuyenDuong,
                        principalTable: "tuyenduong",
                        principalColumn: "ID_TuyenDuong");
                    table.ForeignKey(
                        name: "fk_chuyenxe_xe",
                        column: x => x.ID_Xe,
                        principalTable: "xe",
                        principalColumn: "ID_Xe");
                });

            migrationBuilder.CreateTable(
                name: "thanhtoan",
                columns: table => new
                {
                    ID_ThanhToan = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_PhieuDat = table.Column<int>(type: "int", nullable: true),
                    So_Tien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PhuongThuc_TT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__thanhtoa__AB2E563157EAFBD3", x => x.ID_ThanhToan);
                    table.ForeignKey(
                        name: "fk_thanhtoan_phieudat",
                        column: x => x.ID_PhieuDat,
                        principalTable: "phieudat",
                        principalColumn: "ID_Phieu");
                });

            migrationBuilder.CreateTable(
                name: "vexe",
                columns: table => new
                {
                    ID_Ve = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Phieu = table.Column<int>(type: "int", nullable: true),
                    ID_ViTriGhe = table.Column<int>(type: "int", nullable: true),
                    ID_ChuyenXe = table.Column<int>(type: "int", nullable: true),
                    Ngay_KhoiHanh = table.Column<DateOnly>(type: "date", nullable: true),
                    Ngay_Ve = table.Column<DateOnly>(type: "date", nullable: true),
                    Gia_Ve = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vexe__8B63A19C63B2D04E", x => x.ID_Ve);
                    table.ForeignKey(
                        name: "fk_vexe_chuyenxe",
                        column: x => x.ID_ChuyenXe,
                        principalTable: "chuyenxe",
                        principalColumn: "ID_ChuyenXe");
                    table.ForeignKey(
                        name: "fk_vexe_phieudat",
                        column: x => x.ID_Phieu,
                        principalTable: "phieudat",
                        principalColumn: "ID_Phieu");
                    table.ForeignKey(
                        name: "fk_vexe_vitri",
                        column: x => x.ID_ViTriGhe,
                        principalTable: "vitri",
                        principalColumn: "ID_ViTriGhe");
                });

            migrationBuilder.CreateIndex(
                name: "IX_benxe_ID_TinhThanh",
                table: "benxe",
                column: "ID_TinhThanh");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenxe_ID_TuyenDuong",
                table: "chuyenxe",
                column: "ID_TuyenDuong");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenxe_ID_Xe",
                table: "chuyenxe",
                column: "ID_Xe");

            migrationBuilder.CreateIndex(
                name: "IX_nguoidung_ID_Account",
                table: "nguoidung",
                column: "ID_Account");

            migrationBuilder.CreateIndex(
                name: "IX_phieudat_ID_User",
                table: "phieudat",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_taikhoan_ID_Quyen",
                table: "taikhoan",
                column: "ID_Quyen");

            migrationBuilder.CreateIndex(
                name: "IX_thanhtoan_ID_PhieuDat",
                table: "thanhtoan",
                column: "ID_PhieuDat");

            migrationBuilder.CreateIndex(
                name: "IX_tuyenduong_Noi_Den",
                table: "tuyenduong",
                column: "Noi_Den");

            migrationBuilder.CreateIndex(
                name: "IX_tuyenduong_Noi_KhoiHanh",
                table: "tuyenduong",
                column: "Noi_KhoiHanh");

            migrationBuilder.CreateIndex(
                name: "IX_vexe_ID_ChuyenXe",
                table: "vexe",
                column: "ID_ChuyenXe");

            migrationBuilder.CreateIndex(
                name: "IX_vexe_ID_Phieu",
                table: "vexe",
                column: "ID_Phieu");

            migrationBuilder.CreateIndex(
                name: "IX_vexe_ID_ViTriGhe",
                table: "vexe",
                column: "ID_ViTriGhe");

            migrationBuilder.CreateIndex(
                name: "IX_vitri_ID_Xe",
                table: "vitri",
                column: "ID_Xe");

            migrationBuilder.CreateIndex(
                name: "IX_xe_ID_Loai",
                table: "xe",
                column: "ID_Loai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thanhtoan");

            migrationBuilder.DropTable(
                name: "vexe");

            migrationBuilder.DropTable(
                name: "chuyenxe");

            migrationBuilder.DropTable(
                name: "phieudat");

            migrationBuilder.DropTable(
                name: "vitri");

            migrationBuilder.DropTable(
                name: "tuyenduong");

            migrationBuilder.DropTable(
                name: "nguoidung");

            migrationBuilder.DropTable(
                name: "xe");

            migrationBuilder.DropTable(
                name: "benxe");

            migrationBuilder.DropTable(
                name: "taikhoan");

            migrationBuilder.DropTable(
                name: "loaixe");

            migrationBuilder.DropTable(
                name: "tinhthanh");

            migrationBuilder.DropTable(
                name: "phanquyen");
        }
    }
}
