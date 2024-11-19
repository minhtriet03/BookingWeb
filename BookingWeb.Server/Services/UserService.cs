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
    
    //Lấy tất cả
    public async Task<List<UserVM>> GetAllUsers()
    {
        var data = await _unitOfWork.userRepository.GetAllAsync();
        var userVM = await Task.FromResult(data.Select(u => new UserVM
        {
            IdUser = u.IdUser,
            DiaChi = u.DiaChi,
            Email = u.Email,
            HoTen = u.HoTen,
            Phone = u.Phone,
            TrangThai = u.TrangThai
        }).ToList());

        return userVM;
    }

    //Lấy bằng ID
    public async Task<UserVM> GetUserById(int id)
    {
        var user = await _unitOfWork.userRepository.GetByIdAsync(id);
        if (user == null) return null;
        

        return new UserVM
        {
            IdUser = user.IdUser,
            HoTen = user.HoTen,
            DiaChi = user.DiaChi,
            Email = user.Email,
            Phone = user.Phone,
            TrangThai = user.TrangThai
        };
    }
    
    //Lấy danh sách phân trang
    public async Task<PagedUserVM> GetUsersByPageAsync(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;

        // Tổng số bản ghi
        var totalRecords = await _unitOfWork.userRepository.CountAsync();

        // Lấy danh sách người dùng với phân trang
        var users = await _unitOfWork.userRepository.GetPagedAsync(skip, pageSize);

        // Chuyển đổi sang ViewModel
        var data = users.Select(u => new UserVM
        {
            IdUser = u.IdUser,
            HoTen = u.HoTen,
            DiaChi = u.DiaChi,
            Email = u.Email,
            Phone = u.Phone,
            TrangThai = u.TrangThai
        }).ToList();

        // Trả về ViewModel với dữ liệu
        return new PagedUserVM
        {
            Users = data,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
        };
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

    public async Task<bool> DeactivateUserAsync(int userId)
    {
        
        try
        {
            var user = await _unitOfWork.userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("Người dùng không tồn tại");
            }

            user.TrangThai = false;
            await _unitOfWork.userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi: " +  ex.Message);
        }
    }
}