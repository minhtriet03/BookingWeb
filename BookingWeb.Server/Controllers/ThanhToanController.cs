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

    public ThanhToanController(VnPayService vnPayservice,ThanhToanService thanhToanService )
    {
        _vnPayservice = vnPayservice;
        _thanhtoanService = thanhToanService;
    }


    [HttpPost("create-payment")]
    public IActionResult CreatePayment([FromBody] VnPaymentRequestModel request)
    {

        var vnPayModel = new VnPaymentRequestModel
        {
            Amount = request.Amount,
            CreatedDate = DateTime.Now,
            Description = "hahaha",
            FullName = "hihihi",
            OrderId = request.OrderId,
            IdPhieuDat = request.IdPhieuDat
        };
        string paymentUrl = _vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel);
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
