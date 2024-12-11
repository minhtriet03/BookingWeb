using Azure.Core;
using BookingWeb.Server.Dto;
using BookingWeb.Server.Services;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/thanh-toan")]
public class ThanhToanController : ControllerBase
{
    private readonly VnPayService _vnPayservice;

    public ThanhToanController(VnPayService vnPayservice)
    {
        _vnPayservice = vnPayservice;
    }


    [HttpPost("create-payment")]
    public IActionResult CreatePayment([FromBody] VnPaymentRequestModel request)
    {

        var vnPayModel = new VnPaymentRequestModel
        {
            Amount = 100000,
            CreatedDate = DateTime.Now,
            Description = "hahaha",
            FullName = "hihihi",
            OrderId = new Random().Next(1000, 100000)
        };
        string paymentUrl = _vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel);
        return Ok(new { url = paymentUrl });
    }

    [HttpGet("callback")]
    public IActionResult PaymentCallBack()
    {
        var response = _vnPayservice.PaymentExecute(Request.Query);

        if (response == null || response.VnPayResponseCode != "00")
        {
          return BadRequest("Payment failed");
        }


        // Lưu đơn hàng vô database

        return Ok("Payment successful");
    }

}
