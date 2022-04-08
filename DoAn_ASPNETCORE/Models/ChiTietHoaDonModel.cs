using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class ChiTietHoaDonModel
    {
        public int ID { get; set; }
        public int HoaDon_ID { get; set; }
        [ForeignKey("HoaDon_ID")]

        public virtual HoaDonModel HoaDon { set; get; }
        
        public string TenSP { get; set; }
        public string SoLuong { get; set; }
        public string Gia { get; set; }
        public int KhuyenMai { get; set; }
        public int ThanhTien { get; set; }
        public int TrangThai { get; set; }
    }
}
