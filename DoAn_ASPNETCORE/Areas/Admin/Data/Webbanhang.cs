using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Admin.Data
{
    public class Webbanhang :DbContext
    {
        public Webbanhang(DbContextOptions<Webbanhang>options)
            :base(options)
        {

        }
        public DbSet<SanPhamModel> SanPhamModel { get; set; }
        public DbSet<LoaiSanPhamModel> LoaiSanPhamModel { get; set; }
        public DbSet<HoaDonModel> HoaDonModel { get; set; }
        public DbSet<ChiTietHoaDonModel> ChiTietHoaDonModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<NhaCungCapModel> NhaCungCapModel { get; set; }
        public DbSet<DanhMucModel> DanhMucModel { get; set; }
        public DbSet<BinhLuanModel> BinhLuanModel { get; set; }
    }
}
