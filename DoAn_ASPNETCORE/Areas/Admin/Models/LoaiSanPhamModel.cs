using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class LoaiSanPhamModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TenLoai { get; set; }
        public int NhaCungCap { get; set; }
        [ForeignKey("NhaCungCap")]
        public virtual NhaCungCapModel MaNCC { set; get; }
        [Required]
        public string TrangThai { get; set; }
        public ICollection<SanPhamModel> lstSanPham { set; get; }
    
    }
}
