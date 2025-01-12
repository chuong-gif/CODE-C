using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh02
{
    public class Sach : AnPham
    {
        public string ISBN { get; set; }
        public string TacGia { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"ISBN: {ISBN}, Tác giả: {TacGia}");
        }
    }
}
