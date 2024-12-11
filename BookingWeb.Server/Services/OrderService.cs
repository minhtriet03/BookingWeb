using AutoMapper;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Services;

public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        //_unitOfWork = unitOfWork;
    }

    public async Task<List<OrderVM>> GetAllOrders()
    {
        var data= await _unitOfWork.orderRepository.GetAllAsync();

        var orderVMs = data.Select(order => new OrderVM
        {
            IdPhieu = order.IdPhieu,
            IdUser = order.IdUser,
            NgayLap = order.NgayLap,
            TongTien = order.TongTien,
            TrangThai = order.TrangThai
        }).ToList();
        
        return orderVMs;
    }
    
    public async Task<List<OrderVM>> GetByDate(string startDate, string endDate)
    {
        if (!DateTime.TryParse(startDate, out DateTime startParsedDate))
        {
            throw new ArgumentException("Ngày bắt đầu không hợp lệ", nameof(startDate));
        }

        if (!DateTime.TryParse(endDate, out DateTime endParsedDate))
        {
            throw new ArgumentException("Ngày kết thúc không hợp lệ", nameof(endDate));
        }
        
        var startDateOnly = DateOnly.FromDateTime(startParsedDate);
        var endDateOnly = DateOnly.FromDateTime(endParsedDate);

        var data = await _unitOfWork.orderRepository.GetByConditionAsync(order =>
            order.NgayLap >= startDateOnly && order.NgayLap <= endDateOnly);
        
        var orderVMs = data.Select(order => new OrderVM
        {
            IdPhieu = order.IdPhieu,
            IdUser = order.IdUser,
            NgayLap = order.NgayLap,
            TongTien = order.TongTien,
            TrangThai = order.TrangThai,
            UserVM = order.IdUserNavigation == null ? null : new UserVM
            {
                HoTen = order.IdUserNavigation.HoTen,
                Email = order.IdUserNavigation.Email,
                Phone = order.IdUserNavigation.Phone
            }
        }).ToList();

        return orderVMs;
    }

    public async Task<List<OrderVM>> GetByIdUser(int id)
    {
        var data = await _unitOfWork.orderRepository.GetByIdUser(id);
        var orderVMs = data.Select(order => new OrderVM
        {
            IdPhieu = order.IdPhieu,
            IdUser = order.IdUser,
            NgayLap = order.NgayLap,
            TongTien = order.TongTien,
            TrangThai = order.TrangThai
        }).ToList();

        return orderVMs;
    }

    public async Task<bool> AddOrderAsync(int userId
            ,decimal giaTien
            , decimal soLuong
            , Phieudat order
        )
    {
        try
        {
            order.IdUser = userId;
            order.TongTien = giaTien * soLuong;
            order.TrangThai = false;
            
            await _unitOfWork.orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> UpdateOrderAsync(Phieudat order)
    {
        try
        {
            var checkIdUser = _unitOfWork.userRepository.GetByIdAsync(order.IdUser);
            if (checkIdUser == null)
                throw new ArgumentException("Không tìm thấy người dùng có id: " + order.IdUser);
            
            var resutl = await _unitOfWork.orderRepository.UpdateAsync(order);

            if(resutl)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleleOrderAsync(int id)
    {
        try
        {
            var order = await _unitOfWork.orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new ArgumentException("Không tìm thấy thông tin phiếu đặt");
            }

            await _unitOfWork.orderRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
    }
    
    
    public async Task<List<ThongKeVM>> ThongKePhieuDatTheoThang()
    {
        // Lấy dữ liệu từ Repository
        var thongKe  = await _unitOfWork.orderRepository.GetAllAsync();

        return thongKe
            .GroupBy(p => new 
            { 
                Thang = p.NgayLap.Value.Month, 
                Nam = p.NgayLap.Value.Year 
            })
            .Select(g => new ThongKeVM
            {
                Thang = g.Key.Thang,
                Nam = g.Key.Nam,
                SoLuongPhieu = g.Count(),
                TongTien = g.Sum(p => p.TongTien ?? 0)
            })
            .OrderBy(tk => tk.Nam)
            .ThenBy(tk => tk.Thang)
            .ToList();
    }
}