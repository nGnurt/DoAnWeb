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
    public class UserController : Controller
    {
        private readonly Webbanhang _context;

        public UserController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/User
        public async Task<IActionResult> Index()/*(string searchString)*/
        {
            //IQueryable<string> genreQuery = from m in _context.UserModel

            //                                select m.UserName;

            //var User = from m in _context.UserModel
            //             select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    User = User.Where(s => s.UserName.Contains(searchString));
            //}


            //var movieGenreVM = new UserViewModel
            //{
            //    DSUser = new SelectList(await genreQuery.Distinct().ToListAsync()),
            //    Users = await User.ToListAsync()
            //};

            //return View(movieGenreVM);
            //if(!string.IsNullOrEmpty(searchString))
            //{
            //    return View(await _context.UserModel.Where(m => m.UserName.Contains(searchString)).ToListAsync());

            //}
            //else
            //{
            //    return View(await _context.UserModel.ToListAsync());
            //}
            return View();
        }


        // GET: Admin/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,HoTen,DiaChi,Email,Sdt,Loai,TrangThai")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                var url = Url.RouteUrl("", new { Controller = "Pages", action = "Index", area = "" });
                return Redirect(url);
            }
            return View(userModel);
        }

        // GET: Admin/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,HoTen,DiaChi,Email,Sdt,Loai,TrangThai")] UserModel userModel)
        {
            if (id != userModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.ID))
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
            return View(userModel);
        }

        // GET: Admin/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.UserModel.FindAsync(id);
            _context.UserModel.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModel.Any(e => e.ID == id);
        }
    }
}
