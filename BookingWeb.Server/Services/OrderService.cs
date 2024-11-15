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
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
            order.TrangThai = "Chưa thanh toán";
            
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
}