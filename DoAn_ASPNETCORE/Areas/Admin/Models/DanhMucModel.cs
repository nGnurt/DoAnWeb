using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class DanhMucModel
    {
        [Key]
        public string ID_DanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string TrangThai { get; set; }

        public ICollection<SanPhamModel> dmucSanPham { get; set; }

    }
}
