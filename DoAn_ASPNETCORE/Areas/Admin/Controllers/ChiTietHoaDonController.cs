﻿using System;
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
    public class ChiTietHoaDonController : Controller
    {
        private readonly Webbanhang _context;

        public ChiTietHoaDonController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietHoaDon
        public async Task<IActionResult> Index()
        {
            var webbanhang = _context.ChiTietHoaDonModel.Include(c => c.HoaDon);
            return View(await webbanhang.ToListAsync());
        }

        // GET: Admin/ChiTietHoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel
                .Include(c => c.HoaDon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Create
        public IActionResult Create()
        {
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID");
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoaDon_ID,TenSP,SoLuong,Gia,KhuyenMai,ThanhTien")] ChiTietHoaDonModel chiTietHoaDonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel.FindAsync(id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // POST: Admin/ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoaDon_ID,TenSP,SoLuong,Gia,KhuyenMai,ThanhTien")] ChiTietHoaDonModel chiTietHoaDonModel)
        {
            if (id != chiTietHoaDonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonModelExists(chiTietHoaDonModel.ID))
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
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel
                .Include(c => c.HoaDon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // POST: Admin/ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel.FindAsync(id);
            _context.ChiTietHoaDonModel.Remove(chiTietHoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonModelExists(int id)
        {
            return _context.ChiTietHoaDonModel.Any(e => e.ID == id);
        }
    }
}
