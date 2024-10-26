using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container
builder.Services.AddControllersWithViews();  // Để hỗ trợ API và MVC Views
builder.Services.AddRazorPages();            // Thêm Razor Pages

// Đăng ký Swagger và CORS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

builder.Services.AddDbContext<BookingBusContext>(options => {
	options.UseSqlServer(builder.Configuration.GetConnectionString("BookingBus"));
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Cấu hình pipeline xử lý yêu cầu HTTP
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Sử dụng CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseRouting();

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
