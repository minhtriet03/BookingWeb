using AutoMapper;
using BookingWeb.Server.Helpers;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

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
builder.Services.AddScoped<OrderService>();


// Đăng ký UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<AccountService>();

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
