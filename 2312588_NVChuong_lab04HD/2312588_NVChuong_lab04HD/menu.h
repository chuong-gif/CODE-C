//1. Khai bao kieu du lieu, hang ...

//2. Khai bao nguyen mau ham
void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int chon, int n);

//3. Dinh nghia ham
void XuatMenu()
{
	cout << "\n======================Menu==========================";
	cout << "\n1. Tinh tong 1+2+3+....+n";
	cout << "\n2. Xuat n so nguyen dau tien";
	cout << "\n3. Tim tat ca uoc so cua n";
	cout << "\n4. Kiem tra n co phai la so nguyen to hay khong?";
	cout << "\n5. Xuat cac so nguyen to <n";
	cout << "\n6. Tinh tong cac chu so cua n";
	cout << "\n7. Dem cac uoc so la so nguyen to cua n";
	cout << "\n8. Doi n thanh co so b";
	cout << "\n9. Tinh n!";
	cout << "\n10. Tinh tong 1+1/2+....+1/n";
	cout << "\n0. Thoat chuong trinh";
	cout << "\n====================================================";


}
//Ham chon menu: [0...somenu=8]
int ChonMenu(int somenu)
{
	int chon;
	do
	{
		XuatMenu();
		cout << "\nNhap chon[0.." << somenu << "]:";
		cin >> chon;
		if (0 <= chon && chon <= somenu)
			break;
	} while (1);

	return chon;
}
//Ham xu ly menu
void XuLyMenu(int chon, int n)
{
	int kq;
	switch (chon)
	{
	case 1:
		cout << "\n1. Tinh tong 1+2+3+....+n";
		kq = TinhTong(n);
		cout << "\n 1+ 2+ ...+" << n << "=" << kq;

		break;
	case 2:
		cout << "\n2. Xuat " << n << " so nguyen dau tien";
		XuatNSoNguyen(n);

		break;
	case 3:
		cout << "\n3. Tim tat ca uoc so cua n: ";
		TimTatCaUocSoCuaN(n);
		break;
	case 4:
		cout << "\n4. Kiem tra n co phai la so nguyen to hay khong?";
		cout << KiemTraNCoPhaiSoNguyenToKhong(n);
		break;
	case 5:
		cout << "\n5. Xuat cac so nguyen to <n";
		cout << XuatSo(n);
		break;
	case 6:
		cout << "\n6. Tinh tong cac chu so cua n";

		break;
	case 7:
		cout << "\n7. Dem cac uoc so la so nguyen to cua n";

		break;
	case 8:
		cout << "\n8. Doi n thanh co so b";

		break;
	case 9:
		cout << "\n9. Tinh n!";

		break;
	case 10:
		cout << "\n10. Tinh tong 1+1/2+....+1/n";

		break;
	case 0:
		cout << "\n0. Thoat chuong trinh";
		break;
	default:
		break;
	}
	_getch();
}
