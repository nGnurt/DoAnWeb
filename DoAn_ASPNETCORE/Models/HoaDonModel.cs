using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class HoaDonModel
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual UserModel User { set; get; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public int ThanhTien { get; set; }
        public int TrangThai { get; set; }
        public ICollection<ChiTietHoaDonModel> lstCTHD { set; get; }
    }
}
