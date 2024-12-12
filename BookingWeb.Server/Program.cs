﻿using AutoMapper;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookingWeb.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Tạo JSON dễ đọc (Indented Formatting)
        options.JsonSerializerOptions.WriteIndented = true;
        // Xử lý vòng lặp tham chiếu
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("https://localhost:5173", "http://localhost:5173", "http://localhost:5108", "https://localhost:7241")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddDbContext<BookingBusContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingBus"));
});

//Tránh lồng nhau
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


// Đăng ký dịch vụ XeService
builder.Services.AddScoped<XeService>();
builder.Services.AddScoped<IXeRepository, XeRepository>();
builder.Services.AddScoped<IGenericRepository<Xe>, XeRepository>();
// Đăng ký dịch vụ LoaiXeService
builder.Services.AddScoped<LoaiXeService>();
builder.Services.AddScoped<ILoaiXeRepository, LoaiXeRepository>();
builder.Services.AddScoped<IGenericRepository<Loaixe>, LoaiXeRepository>();

//Đăng ký các service
//User

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGenericRepository<Nguoidung>, GenericRepository<Nguoidung>>();
builder.Services.AddScoped<UserService>();

//Order
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IGenericRepository<Taikhoan>, GenericRepository<Taikhoan>>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IGenericRepository<Phieudat>, GenericRepository<Phieudat>>();
builder.Services.AddScoped<OrderService>();


//Tinh
builder.Services.AddScoped<ITinhRepository, TinhRepository>();
builder.Services.AddScoped<IGenericRepository<Tinhthanh>, GenericRepository<Tinhthanh>>();
builder.Services.AddScoped<TinhService>();

//Vexe
builder.Services.AddScoped<IVexeRepository, VexeRepository>();
builder.Services.AddScoped<IGenericRepository<Vexe>, GenericRepository<Vexe>>();
builder.Services.AddScoped<VexeService>();

//Benxe
builder.Services.AddScoped<IBenXeRepository, BenXeRepository>();
builder.Services.AddScoped<IGenericRepository<Benxe>, GenericRepository<Benxe>>();
builder.Services.AddScoped<BenxeService>();

//TuyenDuong
builder.Services.AddScoped<ITuyenDuongRepository, TuyenDuongRepository>();
builder.Services.AddScoped<IGenericRepository<Tuyenduong>, GenericRepository<Tuyenduong>>();
builder.Services.AddScoped<TuyenDuongService>();
//ChuyenXe
builder.Services.AddScoped<IChuyenXeRepository, ChuyenXeRepository>();
builder.Services.AddScoped<IGenericRepository<Chuyenxe>, GenericRepository<Chuyenxe>>();
builder.Services.AddScoped<ChuyenXeService>();

//Role
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IGenericRepository<Phanquyen>, GenericRepository<Phanquyen>>();
builder.Services.AddScoped<RoleService>();

//thanh toan
builder.Services.AddScoped<IThanhToanRepository, ThanhToanRepository>();
builder.Services.AddScoped<IGenericRepository<Thanhtoan>, GenericRepository<Thanhtoan>>();
builder.Services.AddScoped<ThanhToanService>();


// Đăng ký UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<AccountService>();

// đăng ký vpnay
builder.Services.AddScoped<VnPayService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Cấu hình pipeline xử lý yêu cầu HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Ánh xạ Razor Pages
app.MapRazorPages();

// Ánh xạ Controllers
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
