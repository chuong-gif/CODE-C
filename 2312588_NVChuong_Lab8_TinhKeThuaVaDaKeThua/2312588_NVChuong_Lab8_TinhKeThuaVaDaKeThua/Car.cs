using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    internal class Car : Vehicle , ICar
    {
        public int SoChoNgoi { get; set; }
        public Car(string ten, int tocDo, int soChoNgoi) : base(ten, tocDo)
        {
            SoChoNgoi = soChoNgoi;
        }


        public Car(string tb) : base(tb) 
        {
            string[] s = tb.Split(',');
            SoChoNgoi = int.Parse(s[2]);
        }
        public void DongCua()
        {
            if(SoChoNgoi > 7)
            {
                SoChoNgoi = 7;
            }
            else
            {
                SoChoNgoi = 0;
            }
            Console.WriteLine("Car is closing the door");
        }
        public void MoCua()
        {
            Console.WriteLine("Car is opening the door");
        }

        public override string ToString()
        {
            return  string.Format($"{"Car":-10} {base.ToString()} {SoChoNgoi}");
        }

    }
}
