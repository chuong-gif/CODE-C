using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh01
{
    internal class Program
    {
        private enum ThucDon
        {
            Thoat = 0,
            NhapThuCong,
            DocFile,
            Xuat,
            TimQuanLyTheoPhong,
            XoaQuanLyTheoPhong,
            SapXepNhanVienTheoPhong
        }

        private static ThucDon ChonMenu()
        {
            int menu = 0;
            while (true)
            {
                Console.Write("Nhập số Menu: ");
                if (int.TryParse(Console.ReadLine(), out menu))
                {
                    return (ThucDon)menu;
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Chọn Chức Năng ===========");
                foreach (ThucDon i in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)i}. {i}");
                }
                Console.WriteLine("=======================================");

                ThucDon chon = ChonMenu();
                Console.Clear();

                switch (chon)
                {
                    case ThucDon.Thoat:
                        return;
                    case ThucDon.NhapThuCong:
                        quanLyNhanVien.NhapThuCong();
                        break;
                    case ThucDon.DocFile:
                        quanLyNhanVien.DocDuLieuTuFile("data.txt");
                        break;
                    case ThucDon.Xuat:
                        quanLyNhanVien.Xuat();
                        break;
                    case ThucDon.TimQuanLyTheoPhong:
                        Console.Write("Nhập tên phòng cần tìm: ");
                        string phong = Console.ReadLine();
                        var dsQuanLy = quanLyNhanVien.TimQuanLyTheoPhong(phong);
                        Console.WriteLine($"Danh sách quản lý thuộc phòng {phong}:");
                        foreach (var ql in dsQuanLy)
                        {
                            ql.HienThiThongTin();
                            Console.WriteLine("=======================================");
                        }
                        break;
                    case ThucDon.XoaQuanLyTheoPhong:
                        Console.Write("Nhập tên phòng cần xóa quản lý: ");
                        phong = Console.ReadLine();
                        quanLyNhanVien.XoaQuanLyTheoPhong(phong);
                        Console.WriteLine($"Đã xóa quản lý thuộc phòng {phong}.");
                        break;
                    case ThucDon.SapXepNhanVienTheoPhong:
                        Console.Write("Sắp xếp theo phòng (1. Tăng dần, 2. Giảm dần): ");
                        int sapXepOption = int.Parse(Console.ReadLine());
                        bool tangDan = sapXepOption == 1;
                        quanLyNhanVien.SapXepNhanVienTheoPhong(tangDan);
                        Console.WriteLine("Danh sách sau khi sắp xếp theo phòng:");
                        quanLyNhanVien.Xuat();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }
}
