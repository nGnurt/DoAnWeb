using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly Webbanhang _context;

        public SanPhamController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/SanPham
        public async Task<IActionResult> Index()
        {
            var webbanhang = _context.SanPhamModel.Include(s => s.Loai);
            return View(await webbanhang.ToListAsync());
        }

        // GET: Admin/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhamModel
                .Include(s => s.Loai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenSP,MaLoai,Gia,GiaMoi,Image,Image_List,Size,SoLuong,NgayLap,TrangThai")] SanPhamModel sanPhamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID", sanPhamModel.MaLoai);
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhamModel.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID", sanPhamModel.MaLoai);
            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenSP,MaLoai,Gia,GiaMoi,Image,Image_List,Size,SoLuong,NgayLap,TrangThai")] SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID", sanPhamModel.MaLoai);
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhamModel
                .Include(s => s.Loai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModel = await _context.SanPhamModel.FindAsync(id);
            _context.SanPhamModel.Remove(sanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhamModel.Any(e => e.ID == id);
        }
    }
}
