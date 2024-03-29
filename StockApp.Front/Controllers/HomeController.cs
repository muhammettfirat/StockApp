﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.Front.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public string AdminPage() 
        {
            return "Admin";
        }
        [Authorize(Roles = "Member")]
        public string MemberPage()
        {
            return "Member";
        }
    }
}
