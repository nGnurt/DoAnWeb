using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DoAn_ASPNETCORE.Areas.Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace DoAn_ASPNETCORE.Controllers
{

    public class PagesController : Controller
    {
        private readonly Webbanhang _context;

        public PagesController(Webbanhang context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var DsNewProducts = (from m in _context.SanPhamModel 
                           where m.DanhMuc=="DM1"
                           select m).Take(4).ToList();
            ViewBag.NewProducts = DsNewProducts;
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
        public IActionResult Single(int? id)
        {
            var sanpham = from m in _context.SanPhamModel
                          where (m.ID == id)
                          select m;
            ViewBag.SanPham = sanpham;
            return View();
        }




    }
}
