using AutoMapper;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
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
}