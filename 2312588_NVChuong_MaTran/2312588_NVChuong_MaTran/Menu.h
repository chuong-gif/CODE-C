void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int chon, MaTran a, int& n);//int m

//Dinh nghia ham
void XuatMenu()
{
	cout << "\n=======================[CHON CHUC NANG]=======================";
	cout << "\n[1]. Nhap ma tran                                           ||";
	cout << "\n[2]. Xuat ma tran                                           ||";
	cout << "\n[3]. Tinh tong cac phan tu thuoc duong cheo chinh           ||";
	cout << "\n[4]. Nhap ma tran tu dong                                   ||";
	cout << "\n[5]. Sap tang hang i                                        ||";
	cout << "\n[6]. Xuat cac phan tu thuoc hang thu i voi(0<=i<=n-1)       ||";
	cout << "\n[7]. Tinh tong cac phan tu max cua hang                     ||";
	cout << "\n[8]. Sap xep giam cac phan tu thuoc cot thu j (0<=j<=n-1)   ||";
	cout << "\n[0]. Thoat chuong trinh                                     ||";
	cout << "\n==============================================================";
}

int ChonMenu(int somenu)
{
	int chon;
	do {
		cout << "\nNhap chon[0.." << somenu << "]=";
		cin >> chon;
		if (0 <= chon && chon <= somenu)
			break;
	} while (1);
	return chon;
}

void XuLyMenu(int chon, MaTran a, int& n)
{
	int i, j;
	switch (chon)
	{
	case 1:
		cout << "\n[1]. Nhap ma tran";
		cout << "\nNhap cap ma tran:";
		cin >> n;
		NhapMaTran(a, n);
		break;
	case 2:
		cout << "\n[2]. Xuat ma tran:";
		XuatMaTran(a, n);
		break;
	case 3:
		cout << "\n[3]. Tinh tong cac phan tu thuoc duong cheo chinh";
		XuatMaTran(a, n);
		cout << "\nTong cheo chinh:" << TongCheoChinh(a, n);
		break;
	case 4:
		cout << "\n[4]. Nhap ma tran tu dong";
		cout << "\nNhap cap ma tran:";
		cin >> n;
		NhapMaTranTD(a, n);
		break;
	case 5:
		cout << "\n[5]. Sap tang hang i";
		XuatMaTran(a, n);
		cout << "\nNhap hang i can sap xep:";
		cin >> i;
		SapTangHangi(a, n, i);
		cout << "\nMa tran sau khi sap tang hang " << i;
		/*cout << "\nMa tran tang theo hang";
		SapTangTheoHang(a, n);*/
		XuatMaTran(a, n);
		break;
	case 6:
		cout << "\n[6]. Xuat cac phan tu thuoc hang thu i voi(0<=i<=n-1)";
		XuatMaTran(a, n);
		cout << "\nNhap hang i can xuat  :";
		cin >> i;
		SuatCPT(a, n, i);
		break;
	case 7:
		cout << "\n[7]. Tinh tong cac phan tu max cua hang ";
		XuatMaTran(a, n);
		cout << "\nTong cac phan tu i cua cac hang la : " << TongCacPTCuaI(a, n);
		break;
	case 8:
		cout << "\n[8]. Sap xep giam cac phan tu thuoc cot thu j (0<=j<=n-1)";
		cout << "Hien Hanh :";
		XuatMaTran(a, n);
		cout << "\nNhap hang i can xap xep:";
		cin >> j;
		cout << "Da xap xep :";
		SapGiamCotj(a, n, j);
		XuatMaTran(a, n);
		break;

	case 0:
		cout << "\n0. Thoat chuong trinh";
		break;
	default:
		break;
	}
	_getch();
	return;
}
