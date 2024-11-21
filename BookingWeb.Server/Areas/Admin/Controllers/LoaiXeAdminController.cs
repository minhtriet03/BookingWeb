using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class LoaiXeAdminController
{
    private readonly LoaiXeService _loaiXeService;

    public LoaiXeAdminController(LoaiXeService loaiXeService)
    {
        _loaiXeService = loaiXeService;
    }

    /*[HttpGet]
    public async Task<IActionResult> Index()
    {
    }*/
}