using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class BinhLuanModel
    {
        [Key]
        public int id { set; get; }
        public int User_ID { set; get; }
        [ForeignKey("User_ID")]
        public virtual UserModel User { set; get; }
        [ForeignKey("SanPham_ID")]
        public int SanPham_ID { set; get; }
        public virtual SanPhamModel SanPham { set; get; }
        public string NoiDung { set; get; }
        public DateTime NgayDang { set; get; }
        public int TrangThai { set; get; }
    }
}
