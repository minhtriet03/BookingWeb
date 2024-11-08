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

}