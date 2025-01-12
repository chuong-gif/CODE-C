using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLamThu_02
{
    
    internal class Program
    {
        private enum ThucDon
        {
            thoat = 0,
            NhapTuFile,
            Xuat,
            TimNhanVienLonTuoiNhat,
            XapXepTheoNamSinh,
            XoaNhanVienTheoTen,
            LietKeNamSinhVaSoNhanVien

        }
        private static ThucDon ChonMenu()
        {
            int menu = 0;
            while(true)
            {
                Console.WriteLine("nhap");
                if (int.TryParse(Console.ReadLine(), out menu)) ;
                {
                    return (ThucDon)menu;
                }
            }
        }
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            while(true) 
            {
                Console.Clear();
                foreach
            }
        }
    }
}
