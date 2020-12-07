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

            var DsLastedProducts = (from m in _context.SanPhamModel
                                    where m.DanhMuc == "DM2"
                                    select m).Take(4).ToList();
            ViewBag.LastedProducts = DsLastedProducts;
          

            ViewBag.NewProducts = DsNewProducts;

            var Loai = (from l in _context.LoaiSanPhamModel
                                
                                 select l).ToList();
            ViewBag.TenL = Loai;


            var BetsSell = (from l in _context.SanPhamModel
                            where l.DanhMuc == "DM3"
                            select l).Take(4).ToList();
            ViewBag.BestSellers = BetsSell;



            return View();
        }

        public async Task<IActionResult> products(int? id)
        {
            var iphone = (from m in _context.SanPhamModel
                                 where m.MaLoai ==id
                                 select m).ToList();
          
            ViewBag.Loai = iphone;
            return View();
        }

        public async Task<IActionResult> detail(int? id)
        {
      
            var detail = (from m in _context.SanPhamModel
                          where m.ID == id
                          select m).ToList();

            ViewBag.ChiTiet = detail;
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
            var sanpham = (from m in _context.SanPhamModel
                            where m.ID == id
                            select m).ToList();
            ViewBag.SanPham = sanpham;

            return View();
        }





    }
}
