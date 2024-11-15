using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services;

public class UserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserVM>> GetAllUsers()
    {
        var data = await _unitOfWork.userRepository.GetAllAsync();
        var userVM = await Task.FromResult(data.Select(u => new UserVM
        {
            IdUser = u.IdUser,
            DiaChi = u.DiaChi,
            Email = u.Email,
            HoTen = u.HoTen,
            Phone = u.Phone
        }).ToList());

        return userVM;
    }

    public async Task<bool> AddUserAsync(Nguoidung user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.HoTen))
                throw new ArgumentException("Họ tên không được để trống");

            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentException("Email không được để trống");

            if (string.IsNullOrEmpty(user.Phone))
                throw new ArgumentException("Số điện thoại không được để trống");

            bool isExistEmail = await _unitOfWork.userRepository.IsEmailExist(user.Email);
            bool isExistPhone = await _unitOfWork.userRepository.IsPhoneExist(user.Phone);

            if (isExistEmail && isExistPhone)
                throw new InvalidOperationException("Email và số điện thoại đã tồn tại");
            else if (isExistEmail)
                throw new InvalidOperationException("Email đã tồn tại");
            else if (isExistPhone)
                throw new InvalidOperationException("Số điện thoại đã tồn tại");

            user.Role = 1; //ở đây Toàn chưa biết cái nào là cái nào : D
            
            await _unitOfWork.userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch
        {
            throw;
        }
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
            var existingUser = await _unitOfWork.userRepository.GetByUsername(user.Email);
            if (existingUser != null && existingUser.IdUser != user.IdUser)
            {
                throw new InvalidOperationException("Email đã tồn tại");
            }

            var result = await _unitOfWork.userRepository.UpdateAsync(user);
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

    public async Task<bool> DeleteUserAsync(int userId)
    {
        
        try
        {
            var user = await _unitOfWork.userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("Người dùng không tồn tại");
            }

            await _unitOfWork.userRepository.DeleteAsync(userId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi: " +  ex.Message);
        }
    }
}