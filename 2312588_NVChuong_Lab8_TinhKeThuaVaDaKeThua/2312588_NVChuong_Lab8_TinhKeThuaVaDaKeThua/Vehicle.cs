using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    internal class Vehicle : IVehicle
    {
        public string Ten { get; set; }
        public int TocDo { get; set; }
        public void Chay()
        {
            Console.WriteLine("Vehicle is running");
        }
        public void Dung()
        {
            Console.WriteLine("Vehicle is stopping");
        }

        
        public Vehicle(string ten, int tocDo)
        {
            Ten = ten;
            TocDo = tocDo;
        }
        
        public Vehicle(string tb)
        {
            string[] s = tb.Split(',');
            Ten = s[0];
            TocDo = int.Parse(s[1]);
        }

        public override string ToString()
        {
            return $"{Ten,-16} {TocDo,-10}";
        }
    }
}
