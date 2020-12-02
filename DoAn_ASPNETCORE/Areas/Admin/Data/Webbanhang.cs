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
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.SanPhamModel> SanPhamModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel> LoaiSanPhamModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.HoaDonModel> HoaDonModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.ChiTietHoaDonModel> ChiTietHoaDonModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.UserModel> UserModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.NhaCungCapModel> NhaCungCapModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.DanhMucModel> DanhMucModel { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.BinhLuanModel> BinhLuanModel { get; set; }
    }
}
