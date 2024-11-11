using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services;

public class UserService
{
    private readonly BookingBusContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService(BookingBusContext context, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserVM>> GetAllUsers()
    {
        var data = await _context.Nguoidungs.Select(u => new UserVM
        {
            IdUser = u.IdUser,
            DiaChi = u.DiaChi,
            Email = u.Email,
            HoTen = u.HoTen,
            Phone = u.Phone
        }).ToListAsync();

        return data;
    }

    public async Task<bool> UpdateUserAsync(Nguoidung user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.HoTen))
                throw new ArgumentException("Họ tên không được để trống!");

            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentException("Email không được để trống!");

            //Kiem tra xem email co bi trung hay la khong
            var existingUser = await _userRepository.GetByUsername(user.Email);
            if (existingUser != null && existingUser.IdUser != user.IdUser)
            {
                throw new InvalidOperationException("Email đã tồn tại");
            }

            var result = await _userRepository.UpdateAsync(user);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch
        {
            throw;
        }
    }

}