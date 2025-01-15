void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, MangNV a, int& n);
void ChayChuongTrinh(MangNV a, int n);

void XuatMenu(){
	cout << "\n========== CHON CHUC NANG ==========";
	cout << "\n[1]. Nhap danh sach nhan vien moi ||";
	cout << "\n[2]. Xuat danh sach nhan vien     ||";
	cout << "\n[3]. Them mot nhan vien moi       ||";
	cout << "\n[0]. Thoat khoi chuong trinh      ||";
	cout << "\n====================================";
}

int ChonMenu(int soMenu)
{
	int stt;
	do
	{
		system("cls");
		XuatMenu();
		cout << endl << "Nhap 1 so de chon menu :";
		cin >> stt;
	} while (stt < 0 || stt > soMenu);
	return stt;
}
void XuLyMenu(int menu, MangNV a, int& n)
{
	
	switch (menu)
	{
	case 1:
		cout << endl << "Nhap so nhan vien : ";
		cin >> n;
		NhapDSNV(a, n);
		break;
	case 2:
		cout << "\nXuat danh sach nhan vien";
		XuatDSNV(a, n);
		break;
	case 3:
		cout << "\nThem mot nhan vien moi";

		ThemMotNV(a, n);

		break;
	default:
		cout << endl << "Thoat khoi chuong trinh";
		break;
	}
	if (menu > 0)
	{
		cout << endl << "Nhan 1 phim bat ky de tiep tuc ";
		_getch();
	}
}
void ChayChuongTrinh(MangNV a, int n)
{
	int menu,
		soMenu = 3;

	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, a, n);

	} while (menu > 0);
}