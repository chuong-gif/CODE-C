using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh01
{
    public class Nguoi
    {
        public string DiaChi { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Tên: {Ten}, Tuổi: {Tuoi}, Địa chỉ: {DiaChi}");
        }
    }
}
