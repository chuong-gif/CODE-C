using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLamThu_02
{
    public class NhanVienHopDong : INhanVien
    {
        //Fields
        private List<string> dsNguoiThan;
        private float hesoluong;
        private string maso;
        private int namsinh;
        private string ten;
        //Properties
        public float HeSoLuong
        {
            get { return hesoluong; }
            set { hesoluong = value; }
        }
        public string MaSo
        {
            get { return maso; }
            set { maso = value; } // Thêm hàm set cho MaSo
        }
        public int NamSinh
        {
            get { return namsinh; }
            set { namsinh = value; } // Thêm hàm set cho NamSinh
        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; } // Thêm hàm set cho Ten
        }


        //Methods
        public NhanVienHopDong()
        {
            dsNguoiThan =new List<string>();
        }
        public NhanVienHopDong(string file)
        {
            string[] s = file.Split(';');
            maso = s[1].Trim();
            ten = s[2].Trim();
            namsinh = int.Parse(s[3].Trim());
            dsNguoiThan = new List<string>(s[4].Trim().Split(','));
            hesoluong = float.Parse(s[5].Trim());

        }
        public NhanVienHopDong(string ms, string _ten, int _namxb, float _heso)
        {
            maso = ms;
            ten = _ten;
            namsinh = _namxb;
            hesoluong = _heso;
            dsNguoiThan = new List<string>();

        }
        public override string ToString()
        {
            string nguoiThan = string.Join(", ", dsNguoiThan);
            return $"||Hợp đồng ||Mã Số: {MaSo,-5}||Tên: {Ten,-20}||Năm Sinh: {NamSinh,-5}||Hệ Số Lương: {HeSoLuong,-5}||Người Thân: {nguoiThan}\n=====================================================================================================";
        }
    }
}
