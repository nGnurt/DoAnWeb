
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class NhaCungCapModel
    {
        public int ID { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
        public ICollection<LoaiSanPhamModel> lstLoaiSanPham { set; get; }
    }
}
