using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoAn_ASPNETCORE.Areas.User.Models;

namespace DoAn_ASPNETCORE.Areas.User.Controllers
{
    [Area("User")]
    public class PagesController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Products1()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registered()
        {
            return View();
        }
        public IActionResult Mail()
        {
            return View();
        }
        public IActionResult Single()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
