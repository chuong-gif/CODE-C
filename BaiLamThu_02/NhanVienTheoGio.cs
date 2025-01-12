using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLamThu_02
{
    public class NhanVienTheoGio : INhanVien
    {
        //fields
        private List<String> dsCongViec;
        string maso;
        int namsinh;
        string ten;
        int tiengio;

        //properties
        public string MaSo
        {
            get { return maso; }
            set { maso = value; }
        }
        public int NamSinh
        {
            get { return namsinh; }
            set { namsinh = value; }

        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        public int TiengGio
        {
            get { return tiengio; }
            set { tiengio = value; }
        }
        //methods
        public NhanVienTheoGio()
        {
            dsCongViec = new List<string>();
        }
        public NhanVienTheoGio(string file2)
        {
            string[] s2 = file2.Split(';');
            maso = s2[1].Trim();
            ten = s2[2].Trim();
            namsinh = int.Parse(s2[3].Trim());
            dsCongViec = new List<string>(s2[4].Trim().Split(','));
            tiengio = int.Parse(s2[5].Trim());
        }
        public NhanVienTheoGio(string ms2, string ten2, int namS2, int tiengio2)
        {
            maso = ms2;
            ten = ten2;
            namsinh = namS2;
            dsCongViec = new List<string>();
            tiengio = tiengio2;

        }
        public override string ToString()
        {
            string congviec = string.Join(",", dsCongViec);
            return $"||Theo giờ ||Mã Số: {MaSo,-5}||Tên: {Ten,-20}||Năm Sinh: {NamSinh,-5}||Tiền giờ   : {tiengio,-5}||Công Việc : {congviec},\n=====================================================================================================";
        }
    }
}
