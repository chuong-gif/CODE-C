using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLamThu_02
{
    public class QuanLyNhanVien 
    {
        private List<INhanVien> dsNhanVien;
        public INhanVien this[int index]
        {
            get { return dsNhanVien[index]; }
            set { dsNhanVien[index] = value; }
        }
        public QuanLyNhanVien()
        {
            dsNhanVien = new List<INhanVien>();
        }
        public void NhapTuFile(string tenFile = "data.txt")
        {
            using (StreamReader sr = new StreamReader(tenFile)) 
            {
                string line;
                while ((line = sr.ReadLine() ) != null)
                {
                    string[] Tep = line.Split(';');
                    if(Tep.Length < 5)
                    {
                        Console.WriteLine("ko du dieu kien" + line);
                        continue;
                    }
                    if (Tep[0].Trim() == "HopDong")
                    {
                        dsNhanVien.Add(new NhanVienHopDong(line));
                    }
                    else if (Tep[0].Trim() == "TheoGio")
                    {
                        dsNhanVien.Add(new NhanVienTheoGio(line));
                    }
                    else
                    {
                        Console.WriteLine("ko hop le o: " + Tep[0].Trim());
                    }
                }
            }
        }
        public void Xuat()
        {
            Console.WriteLine("Danh sach nhan vien");
            foreach(var NhanVien in dsNhanVien) 
            {
                Console.WriteLine(NhanVien);
            }
        }
        public INhanVien TimNhanVienLonTuoiNhat()
        {
            if(dsNhanVien.Count == 0)
            {
                return null;
            }
            INhanVien nhanVienLonTuoiNhat = dsNhanVien[0];
            foreach (var NhanVien in dsNhanVien)
            {
                nhanVienLonTuoiNhat = NhanVien;   
            }
            return nhanVienLonTuoiNhat;
        }
        public void XapXepTheoNamSinh()
        {
            dsNhanVien.Sort((x, y) => x.NamSinh.CompareTo(y.NamSinh));
        }
        public void XoaNhanVienTheoTen(string ten)
        {
            dsNhanVien.RemoveAll(x => x.Ten.Equals(ten,StringComparison.OrdinalIgnoreCase));
        }
        public void LietKeNamSinhVaSoNhanVien()
        {
            Dictionary<int, int> namVaSoNhanVien = new Dictionary<int, int>();
            foreach (var NhanVien in dsNhanVien)
            {
                int namSinh = NhanVien.NamSinh;
                if(namVaSoNhanVien.ContainsKey(namSinh))
                {
                    namVaSoNhanVien[namSinh]++;
                }
                else
                {
                    namVaSoNhanVien[namSinh] = 1;
                }

            }
            Console.WriteLine("danh nhan vien co so nam tuong ung");
            foreach(var kvq in namVaSoNhanVien)
            {
                Console.WriteLine($"nam sinh :{kvq.Key},so nhan vien:{kvq.Value}");
            }

        }
    }
}
