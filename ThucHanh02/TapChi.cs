﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh02
{
    public class TapChi : AnPham
    {
        public int So { get; set; }
        public int Tap { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Số: {So}, Tập: {Tap}");
        }
    }
}
