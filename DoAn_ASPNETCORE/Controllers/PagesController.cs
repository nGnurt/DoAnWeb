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
                           select m).Take(1).ToList();


            ViewBag.NewProducts = DsNewProducts;

            var Loai = (from l in _context.LoaiSanPhamModel
                                
                                 select l).ToList();

            ViewBag.TenL = Loai;
            return View();
        }

        public async Task<IActionResult> Header()
        {
            var danhmuc = (from m in _context.LoaiSanPhamModel where m.TenLoai == "iPhone" select m).ToList();
            ViewBag.danhmuc = danhmuc;
            return View();
        }
        public IActionResult products()
        {
            var DsNewProducts = (from m in _context.SanPhamModel
                                 where m.MaLoai ==2
                                 select m).ToList();
          
            ViewBag.Loai = DsNewProducts;
            return View();
        }

        public ViewResult detail(int id)
        {
         
            return View();
        }
        public IActionResult Checkout()
        {
           
            return View();
        }
        public IActionResult Products1(int? id)
        {
            var DsLaptop = (from m in _context.SanPhamModel
                            where m.MaLoai == id
                            select m).ToList();
            ViewBag.LapTop = DsLaptop;
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
           

            return View();
        }





    }
}
