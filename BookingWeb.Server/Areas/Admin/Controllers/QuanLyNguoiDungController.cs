using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyNguoiDungController : Controller
    {
        private readonly BookingBusContext _context;

        public QuanLyNguoiDungController(BookingBusContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Nguoidungs
                .Select(u => new UserVM
                {
                    IdUser = u.IdUser,
                    HoTen = u.HoTen,
                    DiaChi = u.DiaChi,
                    Email = u.Email,
                    Phone = u.Phone,
                }).ToListAsync();
            return View(data);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var nguoiDung = await _context.Nguoidungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            var nguoiDungVM = new UserVM
            {
                IdUser = nguoiDung.IdUser,
                HoTen = nguoiDung.HoTen,
                DiaChi = nguoiDung.DiaChi,
                Email = nguoiDung.Email,
                Phone = nguoiDung.Phone,
            };

            return View(nguoiDungVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var nguoiDung = await _context.Nguoidungs.FindAsync(model.IdUser);
            if (nguoiDung == null)
                return NotFound();
            
            nguoiDung.HoTen = model.HoTen;
            nguoiDung.DiaChi = model.DiaChi;
            nguoiDung.Phone = model.Phone;
            nguoiDung.Email = model.Email;
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            /*if (ModelState.IsValid)
            {
                var nguoiDung = await _context.Nguoidungs.FindAsync(model.IdUser);
                if (nguoiDung != null)
                {
                    nguoiDung.HoTen = model.HoTen;
                    nguoiDung.DiaChi = model.DiaChi;
                    nguoiDung.Phone = model.Phone;
                    nguoiDung.Email = model.Email;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View("Index");*/
        }
    }
}
