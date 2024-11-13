using AutoMapper;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<OrderVM>> GetAllOrders()
    {
        var data= await _orderRepository.GetAllAsync();

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

    public async Task<bool> AddOrderAsync(int userId, decimal soLuong, decimal giaTien, Phieudat order)
    {
        try
        {
            order.IdUser = userId;
            order.TongTien = soLuong * giaTien;
            order.TrangThai = "Chưa thanh toán";
            
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw;
        }
    } 
}