using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh01
{
    public class QuanLyNhanVien
    {
        private List<Nguoi> collection;

        public QuanLyNhanVien()
        {
            collection = new List<Nguoi>();
        }

        public void NhapThuCong()
        {
            while (true)
            {
                Console.WriteLine("Chọn loại nhân viên để nhập:");
                Console.WriteLine("1. Người");
                Console.WriteLine("2. Nhân viên");
                Console.WriteLine("3. Quản lý");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Nguoi nguoi = new Nguoi();
                        Console.Write("Nhập tên: ");
                        nguoi.Ten = Console.ReadLine();
                        Console.Write("Nhập tuổi: ");
                        nguoi.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập địa chỉ: ");
                        nguoi.DiaChi = Console.ReadLine();
                        collection.Add(nguoi);
                        break;

                    case "2":
                        NhanVien nhanVien = new NhanVien();
                        Console.Write("Nhập tên: ");
                        nhanVien.Ten = Console.ReadLine();
                        Console.Write("Nhập tuổi: ");
                        nhanVien.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập địa chỉ: ");
                        nhanVien.DiaChi = Console.ReadLine();
                        Console.Write("Nhập mã nhân viên: ");
                        nhanVien.MaNhanVien = Console.ReadLine();
                        Console.Write("Nhập vị trí: ");
                        nhanVien.Vitri = Console.ReadLine();
                        Console.Write("Nhập lương: ");
                        nhanVien.Luong = decimal.Parse(Console.ReadLine());
                        collection.Add(nhanVien);
                        break;

                    case "3":
                        QuanLy quanLy = new QuanLy();
                        Console.Write("Nhập tên: ");
                        quanLy.Ten = Console.ReadLine();
                        Console.Write("Nhập tuổi: ");
                        quanLy.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập địa chỉ: ");
                        quanLy.DiaChi = Console.ReadLine();
                        Console.Write("Nhập mã nhân viên: ");
                        quanLy.MaNhanVien = Console.ReadLine();
                        Console.Write("Nhập vị trí: ");
                        quanLy.Vitri = Console.ReadLine();
                        Console.Write("Nhập lương: ");
                        quanLy.Luong = decimal.Parse(Console.ReadLine());
                        Console.Write("Nhập phòng: ");
                        quanLy.Phong = Console.ReadLine();
                        collection.Add(quanLy);
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục hoặc nhập '0' để thoát...");
                if (Console.ReadLine() == "0")
                {
                    break;
                }
            }
        }

        public void DocDuLieuTuFile(string filename = "data.txt")
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] info = line.Split(';');
                    if (info[0] == "Nguoi")
                    {
                        Nguoi nguoi = new Nguoi
                        {
                            Ten = info[1].Trim(),
                            Tuoi = int.Parse(info[2].Trim()),
                            DiaChi = info[3].Trim()
                        };
                        collection.Add(nguoi);
                    }
                    else if (info[0] == "NhanVien")
                    {
                        NhanVien nhanVien = new NhanVien
                        {
                            Ten = info[1].Trim(),
                            Tuoi = int.Parse(info[2].Trim()),
                            DiaChi = info[3].Trim(),
                            MaNhanVien = info[4].Trim(),
                            Vitri = info[5].Trim(),
                            Luong = decimal.Parse(info[6].Trim())
                        };
                        collection.Add(nhanVien);
                    }
                    else if (info[0] == "QuanLy")
                    {
                        QuanLy quanLy = new QuanLy
                        {
                            Ten = info[1].Trim(),
                            Tuoi = int.Parse(info[2].Trim()),
                            DiaChi = info[3].Trim(),
                            MaNhanVien = info[4].Trim(),
                            Vitri = info[5].Trim(),
                            Luong = decimal.Parse(info[6].Trim()),
                            Phong = info[7].Trim()
                        };
                        collection.Add(quanLy);
                    }
                }
            }
        }

        public void Xuat()
        {
            Console.WriteLine("Danh sách nhân viên:");
            foreach (var nguoi in collection)
            {
                nguoi.HienThiThongTin();
                Console.WriteLine("=======================================");
            }
        }

        public List<QuanLy> TimQuanLyTheoPhong(string phong)
        {
            var result = collection.OfType<QuanLy>().Where(q => q.Phong == phong).ToList();
            return result;
        }

        public void XoaQuanLyTheoPhong(string phong)
        {
            collection.RemoveAll(x => x is QuanLy ql && ql.Phong == phong);
        }

        public void SapXepNhanVienTheoPhong(bool tangDan = true)
        {
            collection.Sort((x, y) =>
            {
                if (x is QuanLy qx && y is QuanLy qy)
                {
                    return tangDan ? string.Compare(qx.Phong, qy.Phong, StringComparison.Ordinal) : string.Compare(qy.Phong, qx.Phong, StringComparison.Ordinal);
                }
                return 0;
            });
        }

        // Các phương thức thêm, cập nhật, xóa, sửa khác...
    }
}
