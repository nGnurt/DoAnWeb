using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string name)
        {
            HttpContext.Session.SetString("username", name);
            return Json(new { success = "True" });
        }
        [HttpPost]
        public JsonResult LogOut()
        {
            HttpContext.Session.Clear();
            return Json(new { success = "True" });
        }

    }
}
