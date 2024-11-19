﻿using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class UserAdminController : Controller
    {
        private readonly UserService _userService;

        public UserAdminController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {
            // Sử dụng UserService để lấy dữ liệu
            var viewModel = await _userService.GetUsersByPageAsync(pageNumber, pageSize);

            // Trả về View với dữ liệu
            return View(viewModel);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("Người dùng không tồn tại");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userToUpdate = new Nguoidung
                {
                    IdUser = model.IdUser,
                    HoTen = model.HoTen,
                    Email = model.Email,
                    DiaChi = model.DiaChi,
                    Phone = model.Phone
                };
                
                var isUpdated = await _userService.UpdateUserAsync(userToUpdate);
                if (isUpdated)
                {
                    TempData["SuccessMessage"] = "Cập nhật thành công";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại rồi");
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}
