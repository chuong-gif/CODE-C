using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2312585_PNHBo_Lab7_TinhKeThuaVaDaKeThua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DanhSachPhuongTien ds = new DanhSachPhuongTien();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================== CHỌN CHỨC NĂNG ======================================");
                foreach (ThucDon option in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }
                Console.WriteLine("===========================================================================================");
                Console.Write("Nhập số Menu : ");
                
                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case ThucDon.NhapTuFile:
                        ds.NhapTuFile("data.txt");
                        break;
                    case ThucDon.Xuat:
                        ds.Xuat();
                        break;
                    case ThucDon.DemSoLuongPhuongTienCar:
                        Console.WriteLine("Số lượng của phương tiện Car là : " + ds.DemSoLuongTheoLoaiPhuongTien(LoaiPhuongTien.Car));
                        break;
                    case ThucDon.DemSoLuongPhuongTienMotorcycle:
                        Console.WriteLine("Số lượng của phương tiện Motorcycle : " + ds.DemSoLuongTheoLoaiPhuongTien(LoaiPhuongTien.Motorcycle));
                        break;
                    case ThucDon.DemSoLuongPhuongTienCarAndMotorcycle:
                        Console.WriteLine("Số lượng của phương tiện Car và Motorcycle : " + ds.DemSoLuongTheoLoaiPhuongTien(LoaiPhuongTien.CarAndMotorcycle));
                        break;
                    case ThucDon.DemSoLuongPhuongTienCarOrMotorcycle:
                        Console.WriteLine("Số lượng của phương tiện Car hoặc Motorcycle : " + ds.DemSoLuongTheoLoaiPhuongTien(LoaiPhuongTien.CarOrMotorcycle));
                        break;
                    case ThucDon.DemSoLuongDemSoLuongTheoTen:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo tên ");
                        Console.Write("Nhập tên cần đếm : ");
                        string ten = Console.ReadLine();
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoTen(ten));
                        break;
                    case ThucDon.DemSoLuongTheoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo số chỗ ngồi ");
                        Console.Write("Nhập số chỗ ngồi cần đếm : ");
                        int soChoNgoi = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoChoNgoi(soChoNgoi));
                        break;
                    case ThucDon.DemSoLuongTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo tốc độ ");
                        Console.Write("Nhập số tốc độ cần đếm : ");
                        int tocDo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoTocDo(tocDo));
                        break;
                    case ThucDon.DemSoLuongTheoTenVaSoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo tên và chỗ ngồi ");
                        Console.WriteLine("Nhập tên cần đếm ");
                        string ten1 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần đếm : ");
                        int soChoNgoi1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoTenVaSoChoNgoi(ten1, soChoNgoi1));
                        break;
                    case ThucDon.DemSoLuongTheoTenVaTocDo:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo tên và chỗ ngồi ");
                        Console.Write("Nhập tên cần đếm :");
                        string ten2 = Console.ReadLine();
                        Console.Write("Nhập số tốc độ cần đếm : ");
                        int tocDo2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoTenVaTocDo(ten2, tocDo2));
                        break;
                    case ThucDon.DemSoLuongTheoSoChoNgoiVaTocDo:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo số chỗ ngồi và tốc độ ");
                        Console.Write("Nhập số chỗ ngồi cần đếm :");
                        int soChoNgoi3 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số tốc độ cần đếm : ");
                        int tocDo3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoSoChoNgoiVaTocDo(soChoNgoi3, tocDo3));
                        break;
                    case ThucDon.DemSoLuongTheoTenVaSoChoNgoivaTocDo:
                        ds.Xuat();
                        Console.WriteLine("Đếm số lượng theo tên, số chỗ ngồi và tốc độ ");
                        Console.Write("Nhập tên cần đếm :");
                        string ten4 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần đếm : ");
                        int soChoNgoi4 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số tốc độ cần đếm : ");
                        int tocDo4 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lượng là : " + ds.DemSoLuongTheoTenVaSoChoNgoivaTocDo(ten4, soChoNgoi4, tocDo4));
                        break;
                    case ThucDon.DemSoLuongTenDaiNhat:
                        Console.WriteLine("Đếm số lượng tên dài nhất là : " + ds.DemSoLuongTenDaiNhat());
                        break;
                    case ThucDon.DemSoLuongTenNganNhat:
                        Console.WriteLine("Đếm số lượng tên ngắn nhất là : " + ds.DemSoLuongTenNganNhat());
                        break;
                    case ThucDon.DemSoLuongChoNgoiLonNhat:
                        Console.WriteLine("Đếm số lượng chỗ ngồi lớn nhất là : " + ds.DemSoLuongChoNgoiLonNhat());
                        break;
                    case ThucDon.DemSoLuongChoNgoiNhoNhat:
                        Console.WriteLine("Đếm số lượng chỗ ngồi nhỏ nhất là : " + ds.DemSoLuongChoNgoiNhoNhat());
                        break;
                    case ThucDon.DemSoLuongTocDoLonNhat:
                        Console.WriteLine("Đếm số lượng tốc độ lớn nhất là : " + ds.DemSoLuongTocDoLonNhat());
                        break;
                    case ThucDon.DemSoLuongTocDoNhoNhat:
                        Console.WriteLine("Đếm số lượng tốc độ nhỏ nhất là : " + ds.DemSoLuongTocDoNhoNhat());
                        break;
                    case ThucDon.TimDSPhuongTienCar:
                        Console.WriteLine("Tìm danh sách phương tiện là Car !");
                        ds.TimDSPhuongTien(LoaiPhuongTien.Car).Xuat();
                        break;
                    case ThucDon.TimDSPhuongTienMotorcycle:
                        Console.WriteLine("Tìm danh sách phương tiện là Motorcycle !");
                        ds.TimDSPhuongTien(LoaiPhuongTien.Motorcycle).Xuat();
                        break;
                    case ThucDon.TimDSPhuongTienCarAndMotorcycle:
                        Console.WriteLine("Tìm danh sách phương tiện là Car và Motorcycle !");
                        ds.TimDSPhuongTien(LoaiPhuongTien.CarAndMotorcycle).Xuat();
                        break;
                    case ThucDon.TimDSPhuongTienCarOrMotorcycle:
                        Console.WriteLine("Tìm danh sách phương tiện là Car hoặc Motorcycle !");
                        ds.TimDSPhuongTien(LoaiPhuongTien.CarOrMotorcycle).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienTen:
                        Console.WriteLine("Tìm danh sách theo tên ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten5 = Console.ReadLine();
                        ds.TimDSDieuKien(LoaiDieuKien.Ten, ten5, 0, 0).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienSoChoNgoi:
                        Console.WriteLine("Tìm danh sách theo số chỗ ngồi ");
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi5 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.SoChoNgoi, null, soChoNgoi5, 0).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienTocDo:
                        Console.WriteLine("Tìm danh sách theo tốc độ ");
                        Console.Write("Nhập số tốc độ cần tìm : ");
                        int tocDo5 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.TocDo, null, 0, tocDo5).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienTen_SoChoNgoi:
                        Console.WriteLine("Tìm danh sách theo tên và số chỗ ngồi ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten6 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần tìm :");
                        int soChoNgoi6 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.TenvaSoChoNgoi, ten6, soChoNgoi6, 0).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienTen_TocDo:
                        Console.WriteLine("Tìm danh sách theo tên và tốc độ ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten7 = Console.ReadLine();
                        Console.Write("Nhập số tốc độ cần tìm : ");
                        int tocDo7 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.TenvaTocDo, ten7, tocDo7, 0).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienSoChoNgoi_TocDo:
                        Console.WriteLine("Tìm danh sách theo số chỗ ngồi và tốc độ ");
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi8 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số tốc độ cần tìm : ");
                        int tocDo8 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.SoChoNgoivaTocDo, null, soChoNgoi8, tocDo8).Xuat();
                        break;
                    case ThucDon.TimDSDieuKienTen_SoChoNgoi_TocDo:
                        Console.WriteLine("Tìm danh sách theo tên , số chỗ ngồi, số tốc độ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten9 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi : ");
                        int soChoNgoi9 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số tốc độ : ");
                        int tocDo9 = int.Parse(Console.ReadLine());
                        ds.TimDSDieuKien(LoaiDieuKien.TenvaSoChoNgoivaTocDo, ten9, soChoNgoi9, tocDo9).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhTen_Max:
                        Console.WriteLine("Tìm danh sách có tên dài nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.DaiNhat, LoaiDieuKien.Ten).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhTen_Min:
                        Console.WriteLine("Tìm danh sách có tên ngắn nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.NganNhat, LoaiDieuKien.Ten).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhSoChoNgoi_Max:
                        Console.WriteLine("Tìm danh sách có số chỗ ngồi lớn nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.SoChoNgoi).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhSoChoNgoi_Min:
                        Console.WriteLine("Tìm danh sách có số chỗ ngồi nhỏ nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.SoChoNgoi).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhTocDo_Max:
                        Console.WriteLine("Tìm danh sách có số tốc độ lớn nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.TocDo).Xuat();
                        break;
                    case ThucDon.TimDSSoSanhTocDo_Min:
                        Console.WriteLine("Tìm danh sách có số tốc độ nhỏ nhất ");
                        ds.TimDSSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.TocDo).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MinTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car ngắn nhất theo tên ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.Ten, LoaiSoSanh.NganNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MaxTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car dài nhất theo tên ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.Ten, LoaiSoSanh.DaiNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MinTheoSoChoNgoi:
                        Console.WriteLine("Tìm danh sách phương tiện Car nhỏ nhất theo số chỗ ngồi ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MaxTheoSoChoNgoi:
                        Console.WriteLine("Tìm danh sách phương tiện Car lớn nhất theo số chỗ ngồi ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MinTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car nhỏ nhất theo số tốc độ ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCar_MaxTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car lớn nhất theo số tốc độ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TocDo, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienMotorcycle_MinTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Motorcycle ngắn nhất theo tên");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.Ten, LoaiSoSanh.NganNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienMotorcycle_MaxTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Motorcycle dài nhất theo tên ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.Ten, LoaiSoSanh.DaiNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienMotorcycle_MinTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Motorcycle nhỏ nhất theo tốc độ ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienMotorcycle_MaxTheoTocDo:
                        Console.WriteLine("Tìm danh dách phương tiện Motorcycle lớn nhất theo tốc độ ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarAndMotorcycle_MinTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car và Motorcycle ngắn nhất theo tên ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarAndMotorcycle, LoaiDieuKien.Ten, LoaiSoSanh.NganNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarAndMotorcycle_MaxTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car và Motorcycle dài nhất theo tên ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarAndMotorcycle, LoaiDieuKien.Ten, LoaiSoSanh.DaiNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarAndMotorcycle_MinTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car và Motorcycle nhỏ nhất theo tốc độ ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarAndMotorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarAndMotorcycle_MaxTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car và Motorcycle lớn nhất theo tốc độ ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarAndMotorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MinTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle ngắn nhất theo tên");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.Ten, LoaiSoSanh.NganNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MaxTheoTen:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle dài nhất theo tên");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.Ten, LoaiSoSanh.DaiNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MinTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle nhỏ nhất theo tốc độ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MaxTheoTocDo:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle lớn nhất theo tốc độ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MinTheoSoChoNgoi:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle nhỏ nhất theo số chỗ ngồi");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarOrMotorcycle_MaxTheoSoChoNgoi:
                        Console.WriteLine("Tìm danh sách phương tiện Car hoặc Motorcycle lớn nhất theo số chỗ ngồi");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.CarOrMotorcycle, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimCarCoSoChoNgoi_MaxVaMotorcycleCoTocDo_Min:
                        Console.WriteLine("Tìm Car có số chỗ ngồi cao nhất và Motorcycle có tốc độ thấp nhất ");
                        Console.WriteLine("Car có số chỗ ngồi cao nhất là : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.LonNhat).Xuat();
                        Console.WriteLine("Motorcycle có tốc độ thấp nhất là : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimCarCoSoChoNgoi_MinVaMotorcycleCoTocDo_Min:
                        Console.WriteLine("Tìm các Car có số chỗ ngồi cao nhất và Motocycle có tốc độ thấp nhất");
                        Console.WriteLine("Car có số chỗ ngồi nhỏ nhất : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.NhoNhat).Xuat();
                        Console.WriteLine("Motorcycle có tốc độ nhỏ nhất : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.NhoNhat).Xuat();
                        break;
                    case ThucDon.TimCarCoSoChoNgoi_MinVaMotorcycleCoTocDo_Max:
                        Console.WriteLine("Tìm các Car có số chỗ ngồi thấp nhất và Motocycle có tốc độ thấp nhất");
                        Console.WriteLine("Car có số chỗ ngồi thấp nhất : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, LoaiSoSanh.NhoNhat).Xuat();
                        Console.WriteLine("Motorcycle có tốc độ cao nhất : ");
                        ds.TimPhuongTienMin_MaxTheoDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, LoaiSoSanh.LonNhat).Xuat();
                        break;
                    case ThucDon.TimPhuongTienCarTheoTen:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten15 = Console.ReadLine();
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.Ten, ten15, 0, 0).Xuat();
                        break;

                    case ThucDon.TimPhuongTienCarTheoSoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Số Chỗ Ngồi");
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi15 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, null, soChoNgoi15, 0).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTocDo:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tốc Độ");
                        Console.Write("Nhập tốc độ cần tìm : ");
                        int tocDo15 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TocDo, null, 0, tocDo15).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTen_SoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên và Số Chỗ Ngồi");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten16 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi12 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TenvaSoChoNgoi, ten16, soChoNgoi12, 0).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTen_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên và Tốc Độ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten17 = Console.ReadLine();
                        Console.Write("Nhập tốc độ cần tìm : ");
                        int tocDo16 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TenvaTocDo, ten17, 0, tocDo16).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoSoChoNgoi_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Số Chỗ Ngồi và Tốc Độ");
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi17 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tốc độ cần tìm : ");
                        int tocDo18 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoivaTocDo, null, soChoNgoi17, tocDo18).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTen_SoChoNgoi_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên, Số Chỗ Ngồi và Tốc Độ");
                        Console.Write("Nhập tên cần tìm : ");
                        string ten20 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần tìm : ");
                        int soChoNgoi19 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tốc độ cần tìm : ");
                        int tocDo19 = int.Parse(Console.ReadLine());
                        ds.TimLoaiPhuongTienVaLoaiDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TenvaSoChoNgoivaTocDo, ten20, soChoNgoi19, tocDo19).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTen_DaiNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên Dài Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.DaiNhat, LoaiDieuKien.Ten).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTen_NganNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tên Ngắn Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.NganNhat, LoaiDieuKien.Ten).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoSoChoNgoi_LonNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Số Chỗ Ngồi Lớn Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.LonNhat, LoaiDieuKien.SoChoNgoi).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoSoChoNgoi_NhoNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Số Chỗ Ngồi Nhỏ Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.NhoNhat, LoaiDieuKien.SoChoNgoi).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTocDo_LonNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tốc Độ Lớn Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.LonNhat, LoaiDieuKien.TocDo).Xuat();

                        break;

                    case ThucDon.TimPhuongTienCarTheoTocDo_NhoNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Car Theo Tốc Độ Nhỏ Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Car, LoaiSoSanh.NhoNhat, LoaiDieuKien.TocDo).Xuat();

                        break;

                    case ThucDon.TimPhuongTienMotorcycleTheoTen_DaiNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Motorcycle Theo Tên Dài Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Motorcycle, LoaiSoSanh.DaiNhat, LoaiDieuKien.Ten).Xuat();

                        break;

                    case ThucDon.TimPhuongTienMotorcycleTheoTen_NganNhat:
                        ds.Xuat();
                        Console.WriteLine("Tìm Phương Tiện Motorcycle Theo Tên Ngắn Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Motorcycle, LoaiSoSanh.NganNhat, LoaiDieuKien.Ten).Xuat();

                        break;


                    case ThucDon.TimPhuongTienMotorcycleTheoTocDo_LonNhat:
                        Console.WriteLine("Tìm Phương Tiện Motorcycle Theo Tốc Độ Lớn Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Motorcycle, LoaiSoSanh.LonNhat, LoaiDieuKien.TocDo).Xuat();

                        break;
                    case ThucDon.TimPhuongTienMotorcycleTheoTocDo_NhoNhat:
                        Console.WriteLine("Tìm Phương Tiện Motorcycle Theo Tốc Độ Nhỏ Nhất");
                        ds.TimLoaiPhuongTienVaLoaiDieuKienVaLoaiSoSanh(LoaiPhuongTien.Motorcycle, LoaiSoSanh.NhoNhat, LoaiDieuKien.TocDo).Xuat();

                        break;

                    case ThucDon.SapXepLoaiPhuongTienTang:
                        Console.WriteLine("Sắp xếp danh sách phương tiện tăng theo Car -> Motorcycle : ");
                        ds.SapXepLoaiPhuongTienTang().Xuat();
                        break;
                    case ThucDon.SapXepLoaiPhuongTienGiam:
                        Console.WriteLine("Sắp xếp danh sách phương tiện giảm theo Motorcycle -> Car: ");
                        ds.SapXepLoaiPhuongTienGiam().Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTen:
                        Console.WriteLine("Sắp xếp danh sách tăng theo tên :");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTen:
                        Console.WriteLine("Sắp xếp danh sách giảm theo tên : ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangTheoSoChoNgoi:
                        Console.WriteLine("Sắp xếp danh sách tăng theo số chỗ ngồi : ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoSoChoNgoi:
                        Console.WriteLine("Sắp xếp danh sách giảm theo số chỗ ngồi : ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách tăng theo tốc độ : ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách giảm theo tốc độ : ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.XoaTheoPhuongTienCar:
                        Console.WriteLine("Xóa tất cả phương tiện Car");
                        ds.XoaTheoLoaiPhuongTien(LoaiPhuongTien.Car);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoPhuongTienMotorcycle:
                        Console.WriteLine("Xóa tất cả phương tiện Motorcycle");
                        ds.XoaTheoLoaiPhuongTien(LoaiPhuongTien.Motorcycle);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoPhuongTienCarAndMotorcycle:
                        Console.WriteLine("Xóa tất cả phương tiện Car và Motorcycle");
                        ds.XoaTheoLoaiPhuongTien(LoaiPhuongTien.CarAndMotorcycle);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoPhuongTienCarOrMotorcycle:
                        Console.WriteLine("Xóa tất cả phương tiện Car hoặc Motorcycle");
                        ds.XoaTheoLoaiPhuongTien(LoaiPhuongTien.CarOrMotorcycle);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienTen:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo tên ");
                        Console.Write("Nhập tên cần xóa : ");
                        string ten10 = Console.ReadLine();
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.Ten, ten10, 0, 0);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienSoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo số chỗ ngồi ");
                        Console.Write("Nhập số chỗ ngồi cần xóa : ");
                        int soChoNgoi10 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, null, soChoNgoi10, 0);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienTocDo:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo tốc độ ");
                        Console.Write("Nhập số tốc độ cần xóa : ");
                        int tocDo10 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.TocDo, null, 0, tocDo10);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuTen_SoChoNgoi:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo tên và số chỗ ngồi");
                        Console.Write("Nhập tên cần xóa : ");
                        string ten11 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần xóa : ");
                        int soChoNgoi11 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoi, ten11, soChoNgoi11, 0);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienTen_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo tên và tốc độ ");
                        Console.Write("Nhập tên cần xóa : ");
                        string ten12 = Console.ReadLine();
                        Console.Write("Nhập tốc độ cần xóa : ");
                        int tocdo12 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.TenvaTocDo, ten12, 0, tocdo12);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienSoChoNgoi_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo số chỗ ngồi và tốc độ");
                        Console.Write("Nhập số chỗ ngồi cần xóa : ");
                        int soChoNgoi13 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tốc độ cần xóa : ");
                        int tocDo13 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoivaTocDo, null, soChoNgoi13, tocDo13);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTheoDieuKienTen_SoChoNgoi_TocDo:
                        ds.Xuat();
                        Console.WriteLine("Xóa theo tên, số chỗ ngồi và tốc độ ");
                        Console.Write("Nhập tên cần xóa : ");
                        string ten14 = Console.ReadLine();
                        Console.Write("Nhập số chỗ ngồi cần xóa : ");
                        int soChoNgoi14 = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tốc độ cần xóa : ");
                        int tocDo14 = int.Parse(Console.ReadLine());
                        ds.XoaTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoivaTocDo, ten14, soChoNgoi14, tocDo14);
                        ds.Xuat();
                        break;

                    case ThucDon.SXTenTang_SoChoNgoiTang_TocDoTang:
                        Console.WriteLine("Sắp xếp : Chiều dài tên tăng, số chỗ ngồi tăng, tốc độ tăng ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Giam)
                           .SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Tang)
                           .SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Tang)
                           .Xuat();
                        break;
                    case ThucDon.SXTenTang_SoChoNgoiTang_TocDoGiam:
                        Console.WriteLine("Sắp xếp : Chiều dài tên tăng, số chỗ ngồi tăng, tốc độ giảm ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Giam)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Tang)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Tang)
                            .Xuat();
                        break;
                    case ThucDon.SXTenTang_SoChoNgoiGiam_TocDoTang:
                        Console.WriteLine("Sắp xếp : Chiều dài tên tăng, số chỗ ngồi giảm, tốc độ tăng ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Tang)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Giam)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Tang)
                            .Xuat();
                        break;
                    case ThucDon.SXTenGiam_SoChoNgoiGiam_TocDoTang:
                        Console.WriteLine("Sắp xếp : Chiều dài tên giảm, số chỗ ngồi giảm, tốc độ tăng ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Tang)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Giam)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Giam)
                            .Xuat();
                        break;
                    case ThucDon.SXTenGiam_SoChoNgoiGiam_TocDoGiam:
                        Console.WriteLine("Sắp xếp : Chiều dài tên giảm, số chỗ ngồi giảm, tốc độ giảm ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TocDo, SapXep.Giam)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoi, SapXep.Giam)
                            .SapXepTheoLoaiDieuKien(LoaiDieuKien.Ten, SapXep.Giam)
                            .Xuat();
                        break;
                    case ThucDon.XoaTenDaiNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa tên dài nhất ");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.DaiNhat, LoaiDieuKien.Ten);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaTenNganNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa tên ngắn nhất ");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.NganNhat, LoaiDieuKien.Ten);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaSoChoNgoiLonNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa số chỗ ngồi lớn nhất ");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.SoChoNgoi);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaSoChoNgoiNhoNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa số chỗ ngồi nhỏ nhất ");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.SoChoNgoi);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaSoTocDoLonNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa số tốc độ lớn nhất");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.TocDo);
                        ds.Xuat();
                        break;
                    case ThucDon.XoaSoTocDoNhoNhat:
                        ds.Xuat();
                        Console.WriteLine("Xóa số tốc độ nhỏ nhất ");
                        ds.XoaTheoLoaiSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.TocDo);
                        ds.Xuat();
                        break;
                    case ThucDon.XuatFile:
                        ds.XuatFile();
                        Console.WriteLine("Đã Xuất !");
                        break;
                    case ThucDon.SapXepTangTheoTen_SoChoNgoi:
                        Console.WriteLine("Sắp xếp tăng theo tên và số chỗ ngồi");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoi, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTen_SoChoNgoi:
                        Console.WriteLine("Sắp xếp giảm theo tên và số chỗ ngồi");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoi, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTen_TocDo:
                        Console.WriteLine("Sắp xếp tăng theo tên và số tốc độ ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaTocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTen_TocDo:
                        Console.WriteLine("Sắp xếp giảm tên và số tốc độ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaTocDo, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangTheoSoChoNgoi_TocDo:
                        Console.WriteLine("Sắp xếp tăng theo số chỗ ngồi và tốc độ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoivaTocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoSoChoNgoi_TocDo:
                        Console.WriteLine("Sắp xếp giảm theo số chỗ ngồi và tốc độ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.SoChoNgoivaTocDo, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangTheoTen_SoChoNgoi_TocDo:
                        Console.WriteLine("Sắp xếp tăng theo tên , số chỗ ngồi và tốc độ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoivaTocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamTheoTen_SoChoNgoi_TocDo:
                        Console.WriteLine("Sắp xếp giảm theo tên, số chỗ ngồi và tốc độ");
                        ds.SapXepTheoLoaiDieuKien(LoaiDieuKien.TenvaSoChoNgoivaTocDo, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.HienThiDSCar:
                        Console.WriteLine("Hiển thị danh sách Car:");
                        ds.TimDSPhuongTien(LoaiPhuongTien.Car).Xuat();
                        break;
                    case ThucDon.HienThiDSMotorcycle:
                        Console.WriteLine("Hiển thị danh sách Motorcycle:");
                        ds.TimDSPhuongTien(LoaiPhuongTien.Motorcycle).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoTenDaiNhat:
                        Console.WriteLine("Hiển thị danh sách theo tên dài nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.DaiNhat, LoaiDieuKien.Ten).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoTenNganNhat:
                        Console.WriteLine("Hiển thị danh sách theo tên ngắn nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.NganNhat, LoaiDieuKien.Ten).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoSoChoNgoiLonNhat:
                        Console.WriteLine("Hiển thị danh sách theo số chỗ ngồi lớn nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.SoChoNgoi).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoSoChoNgoiNhoNhat:
                        Console.WriteLine("Hiển thị danh sách theo số chỗ ngồi nhỏ nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.SoChoNgoi).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoTocDoLonNhat:
                        Console.WriteLine("Hiển thị danh sách theo tốc độ lớn nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.LonNhat, LoaiDieuKien.TocDo).Xuat();
                        break;
                    case ThucDon.HienThiDSTheoTocDoNhoNhat:
                        Console.WriteLine("Hiển thị danh sách theo tốc độ nhỏ nhất:");
                        ds.TimDSSoSanh(LoaiSoSanh.NhoNhat, LoaiDieuKien.TocDo).Xuat();
                        break;
                    case ThucDon.SapXepCarTangTheoTen:
                        Console.WriteLine("Sắp xếp danh sách Car tăng dần theo tên:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.Ten, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepCarGiamTheoTen:
                        Console.WriteLine("Sắp xếp danh sách Car giảm dần theo tên:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.Ten, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepCarTangTheoSoChoNgoi:
                        Console.WriteLine("Sắp xếp danh sách Car tăng dần theo số chỗ ngồi:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepCarGiamTheoSoChoNgoi:
                        Console.WriteLine("Sắp xếp danh sách Car giảm dần theo số chỗ ngồi:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.SoChoNgoi, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepCarTangTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách Car tăng dần theo tốc độ:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepCarGiamTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách Car giảm dần theo tốc độ:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Car, LoaiDieuKien.TocDo, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangMotorcycleTheoTen:
                        Console.WriteLine("Sắp xếp danh sách Motorcycle tăng dần theo tên:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.Ten, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamMotorcycleTheoTen:
                        Console.WriteLine("Sắp xếp danh sách Motorcycle giảm dần theo tên:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.Ten, SapXep.Giam).Xuat();
                        break;
                    case ThucDon.SapXepTangMotorcycleTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách Motorcycle tăng dần theo tốc độ:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, SapXep.Tang).Xuat();
                        break;
                    case ThucDon.SapXepGiamMotorcycleTheoTocDo:
                        Console.WriteLine("Sắp xếp danh sách Motorcycle giảm dần theo tốc độ:");
                        ds.SapXepTheoLoaiPhuongTienVaDieuKien(LoaiPhuongTien.Motorcycle, LoaiDieuKien.TocDo, SapXep.Giam).Xuat();
                        break;
                    default:
                    case ThucDon.Thoat:
                        return;
                }
                Console.WriteLine("Nhap 1 phim de tiep tuc ");
                Console.ReadKey();
            }
        }
    }

    public enum ThucDon
    {
        NhapTuFile = 1,
        Xuat,
        DemSoLuongPhuongTienCar,
        DemSoLuongPhuongTienMotorcycle,
        DemSoLuongPhuongTienCarAndMotorcycle,
        DemSoLuongPhuongTienCarOrMotorcycle,
        DemSoLuongDemSoLuongTheoTen,
        DemSoLuongTheoChoNgoi,
        DemSoLuongTheoTocDo,
        DemSoLuongTheoTenVaSoChoNgoi,
        DemSoLuongTheoTenVaTocDo,
        DemSoLuongTheoSoChoNgoiVaTocDo,
        DemSoLuongTheoTenVaSoChoNgoivaTocDo,
        DemSoLuongTenDaiNhat,
        DemSoLuongTenNganNhat,
        DemSoLuongChoNgoiLonNhat,
        DemSoLuongChoNgoiNhoNhat,
        DemSoLuongTocDoLonNhat,
        DemSoLuongTocDoNhoNhat,
        TimDSPhuongTienCar,
        TimDSPhuongTienMotorcycle,
        TimDSPhuongTienCarAndMotorcycle,
        TimDSPhuongTienCarOrMotorcycle,
        TimDSDieuKienTen,
        TimDSDieuKienSoChoNgoi,
        TimDSDieuKienTocDo,
        TimDSDieuKienTen_SoChoNgoi,
        TimDSDieuKienTen_TocDo,
        TimDSDieuKienSoChoNgoi_TocDo,
        TimDSDieuKienTen_SoChoNgoi_TocDo,
        TimDSSoSanhTen_Max,
        TimDSSoSanhTen_Min,
        TimDSSoSanhSoChoNgoi_Max,
        TimDSSoSanhSoChoNgoi_Min,
        TimDSSoSanhTocDo_Max,
        TimDSSoSanhTocDo_Min,
        TimPhuongTienCar_MinTheoTen,
        TimPhuongTienCar_MaxTheoTen,
        TimPhuongTienCar_MinTheoSoChoNgoi,
        TimPhuongTienCar_MaxTheoSoChoNgoi,
        TimPhuongTienCar_MinTheoTocDo,
        TimPhuongTienCar_MaxTheoTocDo,
        TimPhuongTienMotorcycle_MinTheoTen,
        TimPhuongTienMotorcycle_MaxTheoTen,
        TimPhuongTienMotorcycle_MinTheoTocDo,
        TimPhuongTienMotorcycle_MaxTheoTocDo,
        TimPhuongTienCarAndMotorcycle_MinTheoTen,
        TimPhuongTienCarAndMotorcycle_MaxTheoTen,
        TimPhuongTienCarAndMotorcycle_MinTheoTocDo,
        TimPhuongTienCarAndMotorcycle_MaxTheoTocDo,
        TimPhuongTienCarOrMotorcycle_MinTheoTen,
        TimPhuongTienCarOrMotorcycle_MaxTheoTen,
        TimPhuongTienCarOrMotorcycle_MinTheoSoChoNgoi,
        TimPhuongTienCarOrMotorcycle_MaxTheoSoChoNgoi,
        TimPhuongTienCarOrMotorcycle_MinTheoTocDo,
        TimPhuongTienCarOrMotorcycle_MaxTheoTocDo,
        TimPhuongTienCarTheoTen,
        TimPhuongTienCarTheoSoChoNgoi,
        TimPhuongTienCarTheoTocDo,
        TimPhuongTienCarTheoTen_SoChoNgoi,
        TimPhuongTienCarTheoTen_TocDo,
        TimPhuongTienCarTheoSoChoNgoi_TocDo,
        TimPhuongTienCarTheoTen_SoChoNgoi_TocDo,
        TimPhuongTienCarTheoTen_DaiNhat,
        TimPhuongTienCarTheoTen_NganNhat,
        TimPhuongTienCarTheoSoChoNgoi_LonNhat,
        TimPhuongTienCarTheoSoChoNgoi_NhoNhat,
        TimPhuongTienCarTheoTocDo_LonNhat,
        TimPhuongTienCarTheoTocDo_NhoNhat,
        TimPhuongTienMotorcycleTheoTen_DaiNhat,
        TimPhuongTienMotorcycleTheoTen_NganNhat,
        TimPhuongTienMotorcycleTheoTocDo_LonNhat,
        TimPhuongTienMotorcycleTheoTocDo_NhoNhat,
        TimCarCoSoChoNgoi_MaxVaMotorcycleCoTocDo_Min,
        TimCarCoSoChoNgoi_MinVaMotorcycleCoTocDo_Min,
        TimCarCoSoChoNgoi_MinVaMotorcycleCoTocDo_Max,
        SapXepLoaiPhuongTienTang,
        SapXepLoaiPhuongTienGiam,
        SapXepTangTheoTen,
        SapXepGiamTheoTen,
        SapXepTangTheoSoChoNgoi,
        SapXepGiamTheoSoChoNgoi,
        SapXepTangTheoTocDo,
        SapXepGiamTheoTocDo,
        SapXepCarTangTheoTen,
        SapXepCarGiamTheoTen,
        SapXepCarTangTheoSoChoNgoi,
        SapXepCarGiamTheoSoChoNgoi,
        SapXepCarTangTheoTocDo,
        SapXepCarGiamTheoTocDo,
        SapXepTangMotorcycleTheoTen,
        SapXepGiamMotorcycleTheoTen,
        SapXepTangMotorcycleTheoTocDo,
        SapXepGiamMotorcycleTheoTocDo,
        SapXepTangTheoTen_SoChoNgoi,
        SapXepGiamTheoTen_SoChoNgoi,
        SapXepTangTheoTen_TocDo,
        SapXepGiamTheoTen_TocDo,
        SapXepTangTheoSoChoNgoi_TocDo,
        SapXepGiamTheoSoChoNgoi_TocDo,
        SapXepTangTheoTen_SoChoNgoi_TocDo,
        SapXepGiamTheoTen_SoChoNgoi_TocDo,
        SXTenTang_SoChoNgoiTang_TocDoTang,
        SXTenTang_SoChoNgoiTang_TocDoGiam,
        SXTenTang_SoChoNgoiGiam_TocDoTang,
        SXTenGiam_SoChoNgoiGiam_TocDoTang,
        SXTenGiam_SoChoNgoiGiam_TocDoGiam,
        XoaTheoPhuongTienCar,
        XoaTheoPhuongTienMotorcycle,
        XoaTheoPhuongTienCarAndMotorcycle,
        XoaTheoPhuongTienCarOrMotorcycle,
        XoaTheoDieuKienTen,
        XoaTheoDieuKienSoChoNgoi,
        XoaTheoDieuKienTocDo,
        XoaTheoDieuTen_SoChoNgoi,
        XoaTheoDieuKienTen_TocDo,
        XoaTheoDieuKienSoChoNgoi_TocDo,
        XoaTheoDieuKienTen_SoChoNgoi_TocDo,
        XoaTenDaiNhat,
        XoaTenNganNhat,
        XoaSoChoNgoiLonNhat,
        XoaSoChoNgoiNhoNhat,
        XoaSoTocDoLonNhat,
        XoaSoTocDoNhoNhat,
        HienThiDSCar,
        HienThiDSMotorcycle,
        HienThiDSTheoTenDaiNhat,
        HienThiDSTheoTenNganNhat,
        HienThiDSTheoSoChoNgoiLonNhat,
        HienThiDSTheoSoChoNgoiNhoNhat,
        HienThiDSTheoTocDoLonNhat,
        HienThiDSTheoTocDoNhoNhat,
        XuatFile,
        Thoat = 0
    }
}
