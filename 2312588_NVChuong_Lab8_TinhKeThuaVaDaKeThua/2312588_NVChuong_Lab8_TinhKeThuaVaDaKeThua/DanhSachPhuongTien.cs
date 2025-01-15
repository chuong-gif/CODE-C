using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    enum LoaiPhuongTien
    {
        Car,
        Motorcycle,
        CarAndMotorcycle,
        CarOrMotorcycle,
        All
    }
    enum LoaiDieuKien
    {
        Ten,
        SoChoNgoi,
        TocDo,
        TenvaSoChoNgoi,
        TenvaTocDo,
        SoChoNgoivaTocDo,
        TenvaSoChoNgoivaTocDo
    }
    enum LoaiSoSanh
    {
        LonNhat,
        NhoNhat,
        DaiNhat,
        NganNhat
    }
    enum TimKiemMaxMin
    {
        Max,
        Min
    }

    enum SapXep
    {
        Giam,
        Tang
    }



    internal class DanhSachPhuongTien
    {
        List<IVehicle> collection = new List<IVehicle>();

        public void Them(IVehicle vehicle)
        {
            collection.Add(vehicle);
        }

        public void Xoa(IVehicle pt)
        {
            collection.Remove(pt);
        }

        public void NhapTuFile(string tenFile)
        {
            StreamReader sr = new StreamReader(tenFile);
            string s = "".Trim();

            while ((s = sr.ReadLine()) != null)
            {
                string[] t = s.Split(',');
                if (t[0] == "Car")
                {
                    IVehicle car = new Car(t[1], int.Parse(t[2]), int.Parse(t[3]));
                    collection.Add(car);
                }
                else if (t[0] == "Motorcycle")
                {
                    IVehicle motorcycle = new Motorcycle(t[1], int.Parse(t[2]));
                    collection.Add(motorcycle);
                }

            }
            sr.Close();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"{"STT",-5}{"Loại",-11}{"Tên Hãng",-17}{"Tốc Độ",-11}Chỗ Ngồi");
            for (var i = 0; i < collection.Count; i++)
            {
                sb.AppendLine($"{i + 1,-5}{collection[i]}");
            }
            return sb.ToString();
        }

        public void Xuat()
        {
            Console.WriteLine(this);
        }

        // Tìm kiếm
        public int TimKiemMin_Max(TimKiemMaxMin timKiem, LoaiDieuKien loaidk)
        {
            if (loaidk is LoaiDieuKien.Ten)
            {
                switch (timKiem)
                {
                    case TimKiemMaxMin.Max:
                        return collection.Max(x => x.Ten.Length);
                    case TimKiemMaxMin.Min:
                        return collection.Min(x => x.Ten.Length);
                }
            }
            else if (loaidk is LoaiDieuKien.SoChoNgoi)
            {
                switch (timKiem)
                {
                    case TimKiemMaxMin.Max:
                        return collection.OfType<Car>().Max(x => (x is Car) ? ((Car)x).SoChoNgoi : 0);
                    case TimKiemMaxMin.Min:
                        return collection.OfType<Car>().Min(x => (x is Car) ? ((Car)x).SoChoNgoi : 0);
                }
            }
            else if (loaidk is LoaiDieuKien.TocDo)
            {
                switch (timKiem)
                {
                    case TimKiemMaxMin.Max:
                        foreach (var i in collection)
                        {
                            if (i is Car)
                            {
                                return collection.Max(x => x.TocDo);
                            }
                            else if (i is Motorcycle)
                            {
                                return collection.Max(x => x.TocDo);
                            }
                        }
                        break;

                    case TimKiemMaxMin.Min:
                        foreach (var i in collection)
                        {
                            if (i is Car)
                            {
                                return collection.Min(x => x.TocDo);
                            }
                            else if (i is Motorcycle)
                            {
                                return collection.OfType<Motorcycle>().Min(x => x.TocDo);
                            }
                        }
                        break;

                }
            }
            return 0;
        }


        //6.	Đếm số lượng theo loại kết hợp
        public int DemSoLuongTheoLoaiPhuongTien(LoaiPhuongTien loai)
        {
            if (loai == LoaiPhuongTien.Car)
            {
                return collection.Count(x => x is Car);
            }
            else if (loai == LoaiPhuongTien.Motorcycle)
            {
                return collection.Count(x => x is Motorcycle);
            }
            else if (loai == LoaiPhuongTien.CarAndMotorcycle)
            {
                return collection.Count(x => x is Car && x is Motorcycle);
            }
            else if (loai == LoaiPhuongTien.CarOrMotorcycle)
            {
                return collection.Count(x => x is Car || x is Motorcycle);
            }
            return 0;
        }

        // Loai dieu kien
        public int DemSoLuongTheoTen(string ten)
        {
            return collection.Count(x => x.Ten == ten);
        }

        public int DemSoLuongTheoChoNgoi(int choNgoi)
        {
            return collection.Count(x =>
            {
                return x is Car ? ((Car)x).SoChoNgoi == choNgoi : false;
            });
        }

        public int DemSoLuongTheoTocDo(int tocdo)
        {
            return collection.Count(x => x.TocDo == tocdo);
        }

        public int DemSoLuongTheoTenVaSoChoNgoi(string ten, int choNgoi)
        {
            return collection.Count(x => x is Car && (x as Car).SoChoNgoi == choNgoi && x.Ten == ten);
        }

        public int DemSoLuongTheoTenVaTocDo(string ten, int tocdo)
        {
            return collection.Count(x => x.Ten == ten && x.TocDo == tocdo);
        }

        public int DemSoLuongTheoSoChoNgoiVaTocDo(int choNgoi, int tocdo)
        {
            return collection.Count(x => x is Car && x.TocDo == tocdo && ((Car)x).SoChoNgoi == choNgoi);
        }

        public int DemSoLuongTheoTenVaSoChoNgoivaTocDo(string ten, int tocdo, int choNgoi)
        {
            return collection.Count(x => x is Car && x.Ten == ten && x.TocDo == tocdo && ((Car)x).SoChoNgoi == choNgoi);
        }

        // Loại So Sánh


        public int DemSoLuongTenDaiNhat()
        {
            return collection.Count(x => x.Ten.Length == TimKiemMin_Max(TimKiemMaxMin.Max, LoaiDieuKien.Ten));
        }

        public int DemSoLuongTenNganNhat()
        {
            return collection.Count(x => x.Ten.Length == TimKiemMin_Max(TimKiemMaxMin.Min, LoaiDieuKien.Ten));
        }


        public int DemSoLuongChoNgoiLonNhat()
        {
            return collection.Count(x => x is Car && ((Car)x).SoChoNgoi == TimKiemMin_Max(TimKiemMaxMin.Max, LoaiDieuKien.SoChoNgoi));
        }
        public int DemSoLuongChoNgoiNhoNhat()
        {
            return collection.Count(x => x is Car && ((Car)x).SoChoNgoi == TimKiemMin_Max(TimKiemMaxMin.Min, LoaiDieuKien.SoChoNgoi));
        }

        public int DemSoLuongTocDoNhoNhat()
        {
            return collection.Count(x => x.TocDo == TimKiemMin_Max(TimKiemMaxMin.Min, LoaiDieuKien.TocDo));
        }

        public int DemSoLuongTocDoLonNhat()
        {
            return collection.Count(x => x.TocDo == TimKiemMin_Max(TimKiemMaxMin.Max, LoaiDieuKien.TocDo));
        }

        // Kết Hợp : Loại Phương Tiện và Loại Điều Kiện
        // Kết Hợp : Loại Phương Tiện và Loại So Sánh
        // Kết Hợp : Loại Phương Tiện , Loại So Sánh, Loại Điều Kiện


        //7.	Tìm tất cả phương tiện theo loại kết hợp
        // Loại Phương Tiện
        public DanhSachPhuongTien TimDSPhuongTien(LoaiPhuongTien loai)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var x in collection)
            {
                if (loai == LoaiPhuongTien.Car)
                {
                    if (x is Car) kq.Them(x); continue;
                }
                if (loai == LoaiPhuongTien.Motorcycle)
                {
                    if (x is Motorcycle) kq.Them(x); continue;
                }
                if (loai == LoaiPhuongTien.CarAndMotorcycle)
                {
                    if (x is Car && x is Motorcycle) kq.Them(x); continue;
                }
                if (loai == LoaiPhuongTien.CarOrMotorcycle)
                {
                    if (x is Car || x is Motorcycle) kq.Them(x); continue;
                }
                if(loai == LoaiPhuongTien.All)
                {
                    if(x is IVehicle) kq.Them(x); continue;
                }
                    
            }
            return kq;
        }

        // Loại Điều Kiện
        public DanhSachPhuongTien TimDSDieuKien(LoaiDieuKien loai, string ten, int soChoNgoi, int tocDo)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var x in collection)
            {
                switch (loai)
                {
                    case LoaiDieuKien.Ten:
                        if (x.Ten == ten) kq.Them(x); continue;
                    case LoaiDieuKien.SoChoNgoi:
                        if (x is Car && ((Car)x).SoChoNgoi == soChoNgoi) kq.Them(x); continue;
                    case LoaiDieuKien.TocDo:
                        if (x.TocDo == tocDo) kq.Them(x); continue;
                    case LoaiDieuKien.TenvaSoChoNgoi:
                        if (x.Ten == ten && (x is Car && ((Car)x).SoChoNgoi == soChoNgoi)) kq.Them(x); continue;
                    case LoaiDieuKien.TenvaTocDo:
                        if (x.Ten == ten && x.TocDo == tocDo) kq.Them(x); continue;
                    case LoaiDieuKien.SoChoNgoivaTocDo:
                        if ((x is Car && ((Car)x).SoChoNgoi == soChoNgoi) && x.TocDo == tocDo) kq.Them(x); continue;
                    case LoaiDieuKien.TenvaSoChoNgoivaTocDo:
                        if (x.Ten == ten && x.TocDo == tocDo && (x is Car && ((Car)x).SoChoNgoi == soChoNgoi)) kq.Them(x); continue;
                }
            }
            return kq;
        }

        // Loại So Sánh

        public DanhSachPhuongTien TimDSSoSanh(LoaiSoSanh loaiss, LoaiDieuKien loaidk)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
            foreach (var x in collection)
            {
                int min = TimKiemMin_Max(TimKiemMaxMin.Min, loaidk);
                int max = TimKiemMin_Max(TimKiemMaxMin.Max, loaidk);
                if (loaidk is LoaiDieuKien.Ten)
                {

                    if (min == x.Ten.Length && loaiss is LoaiSoSanh.NganNhat)
                    {
                        kq.Them(x); continue;
                    }
                    if (max == x.Ten.Length && loaiss is LoaiSoSanh.DaiNhat)
                    {
                        kq.Them(x); continue;
                    }
                }
                else if (loaidk is LoaiDieuKien.SoChoNgoi)
                {

                    if (x is Car && (x as Car).SoChoNgoi == min && loaiss is LoaiSoSanh.NhoNhat)
                    {
                        kq.Them(x); continue;
                    }
                    if (x is Car && (x as Car).SoChoNgoi == max && loaiss is LoaiSoSanh.LonNhat)
                    {
                        kq.Them(x); continue;
                    }
                }
                else if (loaidk is LoaiDieuKien.TocDo)
                {
                    if (x.TocDo == min && loaiss is LoaiSoSanh.NhoNhat)
                    {
                        kq.Them(x); continue;
                    }
                    if (x.TocDo == max && loaiss is LoaiSoSanh.LonNhat)
                    {
                        kq.Them(x); continue;
                    }
                }
            }
            return kq;
        }

        // Kết Hợp : Loại Phương Tiện và Loại Điều Kiện
        public DanhSachPhuongTien TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien loaipt, LoaiDieuKien loaidk, string ten, int soChoNgoi, int tocDo)
        {
            DanhSachPhuongTien kq = new DanhSachPhuongTien();
           
                switch ( loaidk )
                {
                    case LoaiDieuKien.Ten:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk,ten,0,0);
                       
                    case LoaiDieuKien.SoChoNgoi:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, null, soChoNgoi, 0);
                        
                    case LoaiDieuKien.TocDo:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, null, 0, tocDo);
                        
                    case LoaiDieuKien.TenvaSoChoNgoi:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, ten, soChoNgoi, 0);
                        
                    case LoaiDieuKien.TenvaTocDo:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, ten, 0, tocDo);

                    case LoaiDieuKien.SoChoNgoivaTocDo:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, null, soChoNgoi, tocDo);
                        
                    case LoaiDieuKien.TenvaSoChoNgoivaTocDo:
                        return kq.TimDSPhuongTien(loaipt).TimDSDieuKien(loaidk, ten, soChoNgoi, tocDo);
               
            }
            return kq;
        }
        // Kết Hợp : Loại Phương Tiện và Loại So Sánh
        // Kết Hợp : Loại Phương Tiện , Loại So Sánh, Loại Điều Kiện
        public DanhSachPhuongTien TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien loaipt, LoaiSoSanh loaiss , LoaiDieuKien loaidk)
        {
            DanhSachPhuongTien kq = TimDSPhuongTien(loaipt);
            if (loaipt is LoaiPhuongTien)
            {
                switch (loaidk)
                {
                    case LoaiDieuKien.Ten:
                       return kq =TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);
                       
                    case LoaiDieuKien.SoChoNgoi:
                       return kq = TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);

                    case LoaiDieuKien.TocDo:
                        return kq = TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);

                    case LoaiDieuKien.TenvaSoChoNgoi:
                        return kq = TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);

                    case LoaiDieuKien.TenvaTocDo:
                        return kq = TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);

                    case LoaiDieuKien.SoChoNgoivaTocDo:
                        return kq =TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);

                    case LoaiDieuKien.TenvaSoChoNgoivaTocDo:
                        return kq = TimDSPhuongTien(loaipt).TimDSSoSanh(loaiss, loaidk);
                }

            }
            return kq;
        }

        //8.	Tìm phương tiện theo loại phương tiện và có giá trị lớn nhất, nhỏ nhất loại điều kiện
        public DanhSachPhuongTien TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien loaipt, LoaiDieuKien loaidk, LoaiSoSanh loaiss)
        {
            DanhSachPhuongTien kq = TimDSPhuongTien(loaipt);
            foreach (var x in collection)
            {
                // Kiểm tra loại phương tiện
                if ((loaipt == LoaiPhuongTien.Car) ||
                    (loaipt == LoaiPhuongTien.Motorcycle) ||
                    (loaipt == LoaiPhuongTien.CarAndMotorcycle) ||
                    (loaipt == LoaiPhuongTien.CarOrMotorcycle))
                {
                    // Kiểm tra điều kiện và thêm vào danh sách kết quả
                    switch (loaidk)
                    {
                        case LoaiDieuKien.Ten:
                            return kq.TimDSSoSanh(loaiss, loaidk);
                        case LoaiDieuKien.SoChoNgoi:
                            return kq.TimDSSoSanh(loaiss, loaidk);
                        case LoaiDieuKien.TocDo:
                            return kq.TimDSSoSanh(loaiss, loaidk);
                    }
                }
            }
            return kq;
        }
        //9.	Tìm các Car có số chỗ ngồi cao nhất và Motocycle có tốc độ thấp nhất
        // Đã làm !
        //10.	Tìm các Car có số chỗ ngồi thấp nhất và Motocycle có tốc độ thấp nhất
        // Đã làm !
        //11.	Tìm các Car có số chỗ ngồi thấp nhất và Motocycle có tốc độ cao nhất
        // Đã làm !

        //12.	Sắp xếp theo loại kết hợp
        // Loại Phương Tiện
        public DanhSachPhuongTien SapXepLoaiPhuongTienTang()
        {
            collection = collection.OrderBy(x => x is Car ? 0 : x is Motorcycle ? 1 : 2).ToList();
            
            return this;
        }

        public DanhSachPhuongTien SapXepLoaiPhuongTienGiam()
        {
            collection = collection.OrderByDescending(x => x is Car ? 0 : x is Motorcycle ? 1 : 2).ToList();
            return this;
        }

        // Loại Điều Kiện
        public DanhSachPhuongTien SapXepTheoLoaiDieuKien(LoaiDieuKien dk, SapXep sapXep)
        {
            foreach (var item in collection) 
            {
                switch (dk)
                {
                case LoaiDieuKien.Ten:
                    collection = (sapXep == SapXep.Tang)
                        ? collection.OrderBy(x => x.Ten.Length).ToList()
                        : collection.OrderByDescending(x => x.Ten.Length).ToList();
                        break;

                case LoaiDieuKien.SoChoNgoi:
                    collection = (sapXep == SapXep.Tang)
                        ? collection.OrderBy(x => (x is Car) ? (x as Car).SoChoNgoi : 0).ToList()
                        : collection.OrderByDescending(x => (x is Car) ? (x as Car).SoChoNgoi : 0).ToList();
                        break;

                case LoaiDieuKien.TocDo:
                     collection = (sapXep == SapXep.Tang)
                            ? collection.OrderBy(x => x.TocDo).ToList()
                            : collection.OrderByDescending(x => x.TocDo).ToList();
                        break;
                    case LoaiDieuKien.TenvaSoChoNgoi:
                        collection = (sapXep == SapXep.Tang)
                             ? collection.OrderBy(x => x.Ten.Length).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ToList()
                             : collection.OrderByDescending(x => x.Ten.Length).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ToList();
                        break;
                    case LoaiDieuKien.TenvaTocDo:
                        collection = (sapXep == SapXep.Tang)
                             ? collection.OrderBy(x => x.Ten.Length).ThenBy(x => x.TocDo).ToList()
                             : collection.OrderByDescending(x => x.Ten.Length).ThenBy(x => x.TocDo).ToList();
                        break;
                    case LoaiDieuKien.SoChoNgoivaTocDo:
                        collection = (sapXep == SapXep.Tang)
                             ? collection.OrderBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenBy(x => x.TocDo).ToList()
                             : collection.OrderByDescending(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenBy(x => x.TocDo).ToList();
                        break;
                    case LoaiDieuKien.TenvaSoChoNgoivaTocDo:
                        collection = (sapXep == SapXep.Tang)
                            ? collection.OrderBy(x => x.Ten).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenBy(x => x.TocDo).ToList()
                            : collection.OrderByDescending(x => x.Ten).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenBy(x => x.TocDo).ToList();
                        break;
                }
            }
            return this;
        }

        // Loại So Sánh

        // Loại Phương Tiện Và Loại Điều Kiện
        public DanhSachPhuongTien SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien loai, LoaiDieuKien dk, SapXep sapXep)
        {
            DanhSachPhuongTien kq = TimDSPhuongTien(loai);
            {
                switch (dk)
            {
                case LoaiDieuKien.Ten:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, sapXep);
                    break;
                case LoaiDieuKien.SoChoNgoi:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, sapXep);
                    break;
                case LoaiDieuKien.TocDo:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, sapXep);
                    break;
                case LoaiDieuKien.TenvaSoChoNgoi:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoi, sapXep);
                    break;
                case LoaiDieuKien.TenvaTocDo:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaTocDo, sapXep);
                    break;
                case LoaiDieuKien.SoChoNgoivaTocDo:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoivaTocDo, sapXep);
                    break;
                case LoaiDieuKien.TenvaSoChoNgoivaTocDo:
                    kq.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoivaTocDo, sapXep);
                    break;
            }
            }
            return kq;
        }
        // Loại Phương Tiện Và Loại So Sánh
        // Loại Phương Tiện Và Loại So Sánh Và Loại Điều Kiện

        //13.	Sắp sếp theo chiều tăng, giảm theo tên hoặc số chỗ ngồi hoặc tốc độ
        
        //14. Sắp sếp theo chiều tăng, giảm theo tên và số chỗ ngồi và tốc độ theo các trường hợp sau
        //a.    Chiều dài tên tăng, số chỗ ngồi tăng, tốc độ tăng
        //(ví dụ 2 phương tiện có tên chiều dài bằng nhau thì phương tiện tiện nào có số chỗ ngồi lớn hơn sẽ ở trước)
        public DanhSachPhuongTien SXTenTang_SoChoNgoiTang_TocDoTang()
        {
            collection.OrderBy(x => x.Ten.Length).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenBy(X => X.TocDo).ToList(); 
            return this;       
        }
        //b.    Chiều dài tên tăng, số chỗ ngồi tăng, tốc độ giảm
        public DanhSachPhuongTien SXTenTang_SoChoNgoiTang_TocDoGiam()
        {
            collection.OrderBy(x => x.Ten.Length).ThenBy(x => x is Car ? (x as Car).SoChoNgoi : 0).ThenByDescending(x => x.TocDo).ToList();
            return this;
        }
        //c.    Chiều dài tên tăng, số chỗ ngồi giảm, tốc độ tăng
        //d.	Chiều dài tên giảm, số chỗ ngồi giảm, tốc độ tăng
        //e.	Chiều dài tên giảm, số chỗ ngồi giảm, tốc độ giảm


        // 15.	Xóa tất cả theo loại kết hợp
        // Loại Phương Tiện
        public void XoaTheoLoaiPhuongTien(LoaiPhuongTien loai)
        {
            var ds = TimDSPhuongTien(loai);
            foreach (var x in ds.collection)
            {
                collection.Remove(x);
            }
        }

        //public void XoaTheoLoaiPhuongTien(LoaiPhuongTien loai)
        //{
        //    if(loai == LoaiPhuongTien.Car)
        //    {
        //        collection.RemoveAll(x  => x is Car);   
        //    }
        //    else if (loai == LoaiPhuongTien.Motorcycle)
        //    {
        //        collection.RemoveAll(x => x is Motorcycle);
        //    }
        //    else if ( loai == LoaiPhuongTien.CarAndMotorcycle)
        //    {
        //        collection.RemoveAll(x => x is Car && x is Motorcycle);
        //    }
        //    else if(loai == LoaiPhuongTien.CarOrMotorcycle)
        //    {
        //        collection.RemoveAll(x => x is Car || x is Motorcycle);
        //    }

        //}

        // Loại Điều Kiện
        public void XoaTheoLoaiDieuKien(LoaiDieuKien loai, string ten, int soChoNgoi, int tocDo)
        {
            var ds = TimDSDieuKien(loai, ten, soChoNgoi, tocDo);
            foreach (var x in ds.collection)
            {
                Xoa(x);
            }
        }

        //public void XoaTheoLoaiDieuKien(LoaiDieuKien loai, string ten, int soChoNgoi , int tocDo )
        //{
        //    collection.RemoveAll(x =>
        //    {
        //        switch (loai)
        //        {
        //            case LoaiDieuKien.Ten:
        //                return x.Ten == ten;
        //            case LoaiDieuKien.SoChoNgoi:
        //                return x is Car car && car.SoChoNgoi == soChoNgoi;
        //            case LoaiDieuKien.TocDo:
        //                return x.TocDo == tocDo;
        //            default:
        //                return false;
        //        }
        //    });
        //}

        // Loại So Sánh
        public void XoaTheoLoaiSoSanh(LoaiSoSanh loai, LoaiDieuKien loaidk)
        {
            var ds = TimDSSoSanh(loai, loaidk);
            foreach(var x in ds.collection)
            {
                Xoa(x);
            }
        }



        // 16.  Gọi phương thức TangToc, GiamToc, DongCua, MoCua theo loại kết hợp
        // Loại Phương Tiện
        // Hàm gọi TangToc cho tất cả các phương tiện là IMotorcycle
        public void TangTocMotorcycle(List<Vehicle> phuongtien)
        {
            foreach (var x in phuongtien)
            {
                if (x is IMotorcycle motorcycle)
                {
                    motorcycle.TangToc();
                }
            }
        }

        // Hàm gọi GiamToc cho tất cả các phương tiện là IMotorcycle
        public void GiamTocMotorcycle(List<Vehicle> phuongtien)
        {
            foreach (var x in phuongtien)
            {
                if (x is IMotorcycle motorcycle)
                {
                    motorcycle.GiamToc();
                }
            }
        }

        // Hàm gọi DongCua cho tất cả các phương tiện là ICar
        public void DongCuaCar(List<Vehicle> phuongtien)
        {
            foreach (var x in phuongtien)
            {
                if (x is ICar car)
                {
                    car.DongCua();
                }
            }
        }

        // Hàm gọi MoCua cho tất cả các phương tiện là ICar
        public void MoCuaCar(List<Vehicle> phuongtien)
        {
            foreach (var x in phuongtien)
            {
                if (x is ICar car)
                {
                    car.MoCua();
                }
            }
        }

        // Loại Điều Kiện

        // Gọi phương thức TangToc theo tên
        public void TangTocTheoTen(List<Vehicle> phuongtien, string ten)
        {
            foreach (var x in phuongtien)
            {
                if (x.Ten == ten && x is IMotorcycle motorcycle)
                {
                    motorcycle.TangToc();
                }
            }
        }

        // Gọi phương thức GiamToc theo tốc độ
        public void GiamTocTheoTocDo(List<Vehicle> phuongtien, int tocDo)
        {
            foreach (var x in phuongtien)
            {
                if (x.TocDo == tocDo && x is IMotorcycle motorcycle)
                {
                    motorcycle.GiamToc();
                }
            }
        }

      

        // 17.	Hiển thị danh sách theo loại kết hợp

       

        // 18.	Lưu tất cả các câu hiển thị ở trên xuống File
        public void XuatFile(string filename = "data.txt")
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var x in collection)
                {
                    if (x is Car car)
                    {
                        sw.WriteLine($"Car,{car.Ten},{car.TocDo},{car.SoChoNgoi}");
                    }
                    else if (x is Motorcycle motorcycle)
                    {
                        sw.WriteLine($"Motorcycle,{motorcycle.Ten},{motorcycle.TocDo}");
                    }
                }
            }
        }

    }
}

