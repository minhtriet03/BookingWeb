using Azure;
using Azure.Core;
using BookingWeb.Server.Dto;
using BookingWeb.Server.Models;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/thanh-toan")]
public class ThanhToanController : ControllerBase
{
    private readonly VnPayService _vnPayservice;
    private readonly ThanhToanService _thanhtoanService;
    private readonly OrderService _orderService;
    private readonly VexeService _vexeService;

    public ThanhToanController(VnPayService vnPayservice,ThanhToanService thanhToanService, OrderService orderService, VexeService vexeService )
    {
        _vnPayservice = vnPayservice;
        _thanhtoanService = thanhToanService;
        _orderService = orderService;
        _vexeService = vexeService;
    }


    [HttpPost("create-payment")]
    public async Task<IActionResult> CreatePayment([FromBody] VnPaymentRequestModel request)
    {

        var vnPayModel = new VnPaymentRequestModel
        {
            Amount = request.Amount,
            CreatedDate = DateTime.Now,
            Description = "hahaha",
            FullName = "hihihi",
            OrderId = request.OrderId,
            IdPhieuDat = request.IdPhieuDat,
            idcx = request.idcx,
            vexe = request.vexe,
        };
        string paymentUrl = _vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel);

        if (string.IsNullOrEmpty(paymentUrl))
        {
            return BadRequest("Payment failed");
        }

        var thanhToan = new Thanhtoan
        {
            IdPhieuDat = request.IdPhieuDat,
            SoTien = Convert.ToDecimal(request.Amount),
            PhuongThucTt = "VNPAY",
            TrangThai = true
        };


        Console.WriteLine("Thanh toan: " + thanhToan.IdPhieuDat + " - " + thanhToan.SoTien + " - " + thanhToan.PhuongThucTt);

        await _orderService.UpdateOrderStatusById(request.IdPhieuDat);

        await _vexeService.setIdPhieuByVitriGheAndIdChuyenXe(request.vexe, request.idcx, request.IdPhieuDat);


        // Lưu đối tượng vào database
        var result = await _thanhtoanService.AddAsync(thanhToan);

        Console.WriteLine("Result: " + result);
        if (!result)
        {
            return BadRequest("Payment failed");
        }

        return Ok(new { url = paymentUrl });
    }

    [HttpGet("callback")]
    public async Task<IActionResult> PaymentCallBack()
    {
        // Xử lý phản hồi từ VNPAY
        var response = _vnPayservice.PaymentExecute(Request.Query);

        if (response == null || response.VnPayResponseCode != "00")
        {
            return BadRequest("Payment failed");
        }

        // Lấy IdPhieuDat và Amount từ query string
        int idPhieuDat = int.Parse(Request.Query["idPhieuDat"]);
        decimal amount = decimal.Parse(Request.Query["amount"]);

        // Tạo đối tượng thanh toán
        var thanhToan = new Thanhtoan
        {
            IdPhieuDat = idPhieuDat,
            SoTien = amount,
            PhuongThucTt = response.PaymentMethod,
            TrangThai = true
        };

        Console.WriteLine("Thanh toan: " + thanhToan.IdPhieuDat + " - " + thanhToan.SoTien + " - " + thanhToan.PhuongThucTt);


        // Lưu đối tượng vào database
        var result = await _thanhtoanService.AddAsync(thanhToan);
        Console.WriteLine("Result: " + result);
        if (!result)
        {
            return BadRequest("Payment failed");
        }

        return Ok("Payment successful");
    }

}
