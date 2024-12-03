using System;
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
                    ID_Loai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Loai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "(NULL)"),
                    So_Ghe = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loaixe__914C231484162537", x => x.ID_Loai);
                });

            migrationBuilder.CreateTable(
                name: "phanquyen",
                columns: table => new
                {
                    ID_Quyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phanquye__D219AE521EF8DFDB", x => x.ID_Quyen);
                });

            migrationBuilder.CreateTable(
                name: "tinhthanh",
                columns: table => new
                {
                    ID_TinhThanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_TinhThanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tinhthan__BC0EB70B648D8A7D", x => x.ID_TinhThanh);
                });

            migrationBuilder.CreateTable(
                name: "vitri",
                columns: table => new
                {
                    ID_ViTriGhe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vitri__F0FA263AAC450897", x => x.ID_ViTriGhe);
                });

            migrationBuilder.CreateTable(
                name: "xe",
                columns: table => new
                {
                    ID_Xe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Loai = table.Column<int>(type: "int", nullable: false),
                    Bien_So = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "(NULL)"),
                    Tinh_Trang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__xe__8B62515E52C40997", x => x.ID_Xe);
                    table.ForeignKey(
                        name: "FK_xe_loaixe",
                        column: x => x.ID_Loai,
                        principalTable: "loaixe",
                        principalColumn: "ID_Loai");
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    ID_Account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Quyen = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__taikhoan__213379EB2699579B", x => x.ID_Account);
                    table.ForeignKey(
                        name: "FK_taikhoan_phanquyen",
                        column: x => x.ID_Quyen,
                        principalTable: "phanquyen",
                        principalColumn: "ID_Quyen");
                });

            migrationBuilder.CreateTable(
                name: "benxe",
                columns: table => new
                {
                    ID_BenXe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TinhThanh = table.Column<int>(type: "int", nullable: false),
                    TenBenXe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__benxe__5D85FA844FDC4F24", x => x.ID_BenXe);
                    table.ForeignKey(
                        name: "FK_benxe_tinhthanh",
                        column: x => x.ID_TinhThanh,
                        principalTable: "tinhthanh",
                        principalColumn: "ID_TinhThanh");
                });

            migrationBuilder.CreateTable(
                name: "nguoidung",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho_Ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    Dia_Chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ID_Account = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nguoidun__ED4DE442BDF9A79A", x => x.ID_User);
                    table.ForeignKey(
                        name: "FK_nguoidung_taikhoan",
                        column: x => x.ID_Account,
                        principalTable: "taikhoan",
                        principalColumn: "ID_Account");
                });

            migrationBuilder.CreateTable(
                name: "tuyenduong",
                columns: table => new
                {
                    ID_TuyenDuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Noi_KhoiHanh = table.Column<int>(type: "int", nullable: false),
                    Noi_Den = table.Column<int>(type: "int", nullable: false),
                    Khoang_Cach = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "(NULL)"),
                    Gia_Ve = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tuyenduo__8D9665CDB5016B03", x => x.ID_TuyenDuong);
                    table.ForeignKey(
                        name: "FK_tuyenduong_benxe",
                        column: x => x.Noi_KhoiHanh,
                        principalTable: "benxe",
                        principalColumn: "ID_BenXe");
                    table.ForeignKey(
                        name: "FK_tuyenduong_benxe1",
                        column: x => x.Noi_Den,
                        principalTable: "benxe",
                        principalColumn: "ID_BenXe");
                });

            migrationBuilder.CreateTable(
                name: "phieudat",
                columns: table => new
                {
                    ID_Phieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    Ngay_Lap = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(NULL)"),
                    Tong_Tien = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phieudat__E61CE97EEA5EA967", x => x.ID_Phieu);
                    table.ForeignKey(
                        name: "FK_phieudat_nguoidung",
                        column: x => x.ID_User,
                        principalTable: "nguoidung",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "chuyenxe",
                columns: table => new
                {
                    ID_ChuyenXe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Xe = table.Column<int>(type: "int", nullable: false),
                    ID_TuyenDuong = table.Column<int>(type: "int", nullable: false),
                    Thoi_GianKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(getdate())"),
                    Thoi_GianDen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(getdate())"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chuyenxe__108DC34A90342C66", x => x.ID_ChuyenXe);
                    table.ForeignKey(
                        name: "FK_chuyenxe_tuyenduong",
                        column: x => x.ID_TuyenDuong,
                        principalTable: "tuyenduong",
                        principalColumn: "ID_TuyenDuong");
                    table.ForeignKey(
                        name: "FK_chuyenxe_xe",
                        column: x => x.ID_Xe,
                        principalTable: "xe",
                        principalColumn: "ID_Xe");
                });

            migrationBuilder.CreateTable(
                name: "thanhtoan",
                columns: table => new
                {
                    ID_ThanhToan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PhieuDat = table.Column<int>(type: "int", nullable: false),
                    So_Tien = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "(NULL)"),
                    PhuongThuc_TT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(NULL)"),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__thanhtoa__AB2E56314DA22CB2", x => x.ID_ThanhToan);
                    table.ForeignKey(
                        name: "FK_thanhtoan_phieudat",
                        column: x => x.ID_PhieuDat,
                        principalTable: "phieudat",
                        principalColumn: "ID_Phieu");
                });

            migrationBuilder.CreateTable(
                name: "vexe",
                columns: table => new
                {
                    ID_Ve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Phieu = table.Column<int>(type: "int", nullable: false),
                    ID_ViTriGhe = table.Column<int>(type: "int", nullable: false),
                    ID_ChuyenXe = table.Column<int>(type: "int", nullable: false),
                    NgayKhoiHanh = table.Column<DateOnly>(type: "date", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vexe__8B63A19CBA40D288", x => x.ID_Ve);
                    table.ForeignKey(
                        name: "FK_vexe_chuyenxe",
                        column: x => x.ID_ChuyenXe,
                        principalTable: "chuyenxe",
                        principalColumn: "ID_ChuyenXe");
                    table.ForeignKey(
                        name: "FK_vexe_phieudat",
                        column: x => x.ID_Phieu,
                        principalTable: "phieudat",
                        principalColumn: "ID_Phieu");
                    table.ForeignKey(
                        name: "FK_vexe_vitri",
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
                name: "xe");

            migrationBuilder.DropTable(
                name: "nguoidung");

            migrationBuilder.DropTable(
                name: "benxe");

            migrationBuilder.DropTable(
                name: "loaixe");

            migrationBuilder.DropTable(
                name: "taikhoan");

            migrationBuilder.DropTable(
                name: "tinhthanh");

            migrationBuilder.DropTable(
                name: "phanquyen");
        }
    }
}
