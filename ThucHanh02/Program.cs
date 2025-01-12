using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh02
{
    internal class Program
    {
        private enum ThucDon
        {
            Thoat = 0,
            NhapThuCong,
            DocFile,
            Xuat,
            TimAnPhamTheoTuaDe,
            XoaAnPhamTheoTuaDe,
            CapNhatAnPhamTheoTuaDe,
            SapXepTheoNam
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
            DanhSachAnPham danhSachAnPham = new DanhSachAnPham();

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
                        danhSachAnPham.NhapThuCong();
                        break;
                    case ThucDon.DocFile:
                        danhSachAnPham.NhapTuFile();
                        break;
                    case ThucDon.Xuat:
                        danhSachAnPham.Xuat();
                        break;
                    case ThucDon.TimAnPhamTheoTuaDe:
                        Console.Write("Nhập tựa đề ấn phẩm cần tìm: ");
                        string tuaDeTim = Console.ReadLine();
                        AnPham anPhamTim = danhSachAnPham.TimAnPhamTheoTuaDe(tuaDeTim);
                        if (anPhamTim != null)
                        {
                            anPhamTim.HienThiThongTin();
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy ấn phẩm.");
                        }
                        break;
                    case ThucDon.XoaAnPhamTheoTuaDe:
                        Console.Write("Nhập tựa đề ấn phẩm cần xóa: ");
                        string tuaDeXoa = Console.ReadLine();
                        danhSachAnPham.XoaAnPhamTheoTuaDe(tuaDeXoa);
                        Console.WriteLine($"Đã xóa ấn phẩm có tựa đề '{tuaDeXoa}'.");
                        break;
                    case ThucDon.CapNhatAnPhamTheoTuaDe:
                        Console.Write("Nhập tựa đề ấn phẩm cần cập nhật: ");
                        string tuaDeCapNhat = Console.ReadLine();
                        danhSachAnPham.CapNhatAnPhamTheoTuaDe(tuaDeCapNhat);
                        break;
                    case ThucDon.SapXepTheoNam:
                        danhSachAnPham.SapXepTheoNam();
                        Console.WriteLine("Danh sách sau khi sắp xếp theo năm:");
                        danhSachAnPham.Xuat();
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
