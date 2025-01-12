using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh01
{
    public class QuanLy : NhanVien
    {
        public string Phong { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Phòng: {Phong}");
        }
    }
}
