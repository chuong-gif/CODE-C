using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh02
{
    public class AnPham
    {
        public int Nam { get; set; }
        public string NhaXuatBan { get; set; }
        public string TuaDe { get; set; }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Tựa đề: {TuaDe}, Năm: {Nam}, Nhà xuất bản: {NhaXuatBan}");
        }
    }
}
