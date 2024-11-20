﻿using Microsoft.AspNetCore.Mvc;

namespace BookingWeb.Server.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]")]
	public class HomeController : Controller
	{
		[HttpGet]  
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
