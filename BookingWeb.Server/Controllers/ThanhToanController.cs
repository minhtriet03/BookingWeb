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
        //if (request == null || request.Amount <= 0 || string.IsNullOrEmpty(request.OrderId))
        //    return BadRequest("Invalid request");


        //string paymentUrl = _vnPayservice.CreatePaymentUrl(500000, "ORD123456", "https://localhost:5173/payment-success");

        //Console.WriteLine("Generated Payment URL: " + paymentUrl);
        //return Ok(new { url = paymentUrl });

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
        //return Redirect(_vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel));
    }

    [HttpGet("callback")]
    //public IActionResult Callback([FromQuery] IDictionary<string, string> queryParams)
    //{
    //    if (!queryParams.ContainsKey("9CFWQS4WMZU8Y6H1OHFZOLDUWQNNTZHA"))
    //        return BadRequest("Invalid callback data");

    //    // Kiểm tra chữ ký vnp_SecureHash
    //    var secureHash = queryParams["vnp_SecureHash"];
    //    queryParams.Remove("vnp_SecureHash");

    //    // Tạo hash mới để xác thực
    //    string rawData = string.Join('&', queryParams.OrderBy(k => k.Key).Select(k => $"{k.Key}={k.Value}"));
    //    using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes("9CFWQS4WMZU8Y6H1OHFZOLDUWQNNTZHA"));
    //    string computedHash = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(rawData))).Replace("-", "").ToLower();

    //    if (secureHash != computedHash)
    //        return BadRequest("Invalid secure hash");

    //    // Xử lý trạng thái thanh toán
    //    var responseCode = queryParams["vnp_ResponseCode"];
    //    if (responseCode == "00") // Thành công
    //    {
    //        // Cập nhật trạng thái giao dịch trong cơ sở dữ liệu
    //        return Ok("Payment successful");
    //    }
    //    else
    //    {
    //        return BadRequest("Payment failed");
    //    }
    //}

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
