using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    internal interface IVehicle
    {
        string Ten {  get; set; }
        int TocDo { get; set; }
        void Chay();
        void Dung();
    }
}
