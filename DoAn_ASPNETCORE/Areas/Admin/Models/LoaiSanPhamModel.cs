using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class LoaiSanPhamModel
    {
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public int NhaCungCap { get; set; }
        [ForeignKey("NhaCungCap")]
        public virtual NhaCungCapModel MaNCC { set; get; }
        public string TrangThai { get; set; }
        public ICollection<SanPhamModel> lstSanPham { set; get; }
    }
}
