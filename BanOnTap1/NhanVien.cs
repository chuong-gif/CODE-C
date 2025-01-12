using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh01
{
    public class NhanVien : Nguoi
    {
        public decimal Luong { get; set; }
        public string MaNhanVien { get; set; }
        public string Vitri { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Mã nhân viên: {MaNhanVien}, Vị trí: {Vitri}, Lương: {Luong}");
        }
    }
}
