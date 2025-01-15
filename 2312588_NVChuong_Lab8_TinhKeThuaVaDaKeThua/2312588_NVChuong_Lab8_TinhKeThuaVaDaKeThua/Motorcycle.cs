using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    internal class Motorcycle : Vehicle, IMotorcycle
    {
        public Motorcycle(string ten, int tocDo) : base(ten, tocDo)
        {
        }

        public void GiamToc()
        {
            TocDo = TocDo - 5;
            Console.WriteLine("Đang giảm tốc ....");
        }

        public void TangToc()
        {
            TocDo = TocDo + 5;
            Console.WriteLine("Đang tăng tốc ....");
        }

        public override string ToString()
        {
            return string.Format($"{"Motorcycle",-10} {base.ToString()}");
        }
    }
}
