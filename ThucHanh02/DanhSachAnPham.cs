using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh02
{
    public class DanhSachAnPham
    {
        private List<AnPham> collection;

        public DanhSachAnPham()
        {
            collection = new List<AnPham>();
        }

        // Nhập thủ công
        public void NhapThuCong()
        {
            Console.WriteLine("Chọn loại ấn phẩm (1: Tạp chí, 2: Sách): ");
            int loai = int.Parse(Console.ReadLine());

            if (loai == 1)
            {
                TapChi tapChi = new TapChi();
                Console.Write("Nhập tựa đề: ");
                tapChi.TuaDe = Console.ReadLine();
                Console.Write("Nhập năm: ");
                tapChi.Nam = int.Parse(Console.ReadLine());
                Console.Write("Nhập nhà xuất bản: ");
                tapChi.NhaXuatBan = Console.ReadLine();
                Console.Write("Nhập số: ");
                tapChi.So = int.Parse(Console.ReadLine());
                Console.Write("Nhập tập: ");
                tapChi.Tap = int.Parse(Console.ReadLine());
                collection.Add(tapChi);
            }
            else if (loai == 2)
            {
                Sach sach = new Sach();
                Console.Write("Nhập tựa đề: ");
                sach.TuaDe = Console.ReadLine();
                Console.Write("Nhập năm: ");
                sach.Nam = int.Parse(Console.ReadLine());
                Console.Write("Nhập nhà xuất bản: ");
                sach.NhaXuatBan = Console.ReadLine();
                Console.Write("Nhập ISBN: ");
                sach.ISBN = Console.ReadLine();
                Console.Write("Nhập tác giả: ");
                sach.TacGia = Console.ReadLine();
                collection.Add(sach);
            }
        }

        // Đọc dữ liệu từ file
        public void NhapTuFile(string filename = "danhsachanpham.txt")
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] info = line.Split(';');
                    if (info.Length < 4)
                    {
                        Console.WriteLine("Dữ liệu không hợp lệ: " + line);
                        continue;
                    }

                    if (info[0].Trim() == "TapChi")
                    {
                        TapChi tapChi = new TapChi
                        {
                            TuaDe = info[1].Trim(),
                            Nam = int.Parse(info[2].Trim()),
                            NhaXuatBan = info[3].Trim(),
                            So = int.Parse(info[4].Trim()),
                            Tap = int.Parse(info[5].Trim())
                        };
                        collection.Add(tapChi);
                    }
                    else if (info[0].Trim() == "Sach")
                    {
                        Sach sach = new Sach
                        {
                            TuaDe = info[1].Trim(),
                            Nam = int.Parse(info[2].Trim()),
                            NhaXuatBan = info[3].Trim(),
                            ISBN = info[4].Trim(),
                            TacGia = info[5].Trim()
                        };
                        collection.Add(sach);
                    }
                    else
                    {
                        Console.WriteLine("Loại ấn phẩm không được hỗ trợ: " + info[0].Trim());
                    }
                }
            }
        }

        // Xuất danh sách ấn phẩm
        public void Xuat()
        {
            Console.WriteLine("Danh sách ấn phẩm:");
            foreach (var anPham in collection)
            {
                anPham.HienThiThongTin();
            }
        }

        // Tìm kiếm ấn phẩm theo tựa đề
        public AnPham TimAnPhamTheoTuaDe(string tuaDe)
        {
            return collection.FirstOrDefault(ap => ap.TuaDe.Equals(tuaDe, StringComparison.OrdinalIgnoreCase));
        }

        // Xóa ấn phẩm theo tựa đề
        public void XoaAnPhamTheoTuaDe(string tuaDe)
        {
            collection.RemoveAll(ap => ap.TuaDe.Equals(tuaDe, StringComparison.OrdinalIgnoreCase));
        }

        // Cập nhật ấn phẩm theo tựa đề
        public void CapNhatAnPhamTheoTuaDe(string tuaDe)
        {
            AnPham anPham = TimAnPhamTheoTuaDe(tuaDe);
            if (anPham != null)
            {
                Console.Write("Nhập năm mới: ");
                anPham.Nam = int.Parse(Console.ReadLine());
                Console.Write("Nhập nhà xuất bản mới: ");
                anPham.NhaXuatBan = Console.ReadLine();

                if (anPham is TapChi tapChi)
                {
                    Console.Write("Nhập số mới: ");
                    tapChi.So = int.Parse(Console.ReadLine());
                    Console.Write("Nhập tập mới: ");
                    tapChi.Tap = int.Parse(Console.ReadLine());
                }
                else if (anPham is Sach sach)
                {
                    Console.Write("Nhập ISBN mới: ");
                    sach.ISBN = Console.ReadLine();
                    Console.Write("Nhập tác giả mới: ");
                    sach.TacGia = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy ấn phẩm.");
            }
        }

        // Sắp xếp ấn phẩm theo năm
        public void SapXepTheoNam()
        {
            collection.Sort((x, y) => x.Nam.CompareTo(y.Nam));
        }
    }
}
