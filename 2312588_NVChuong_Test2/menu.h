void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, LIST& l);

void XuatMenu()
{
	cout << "||========================[Chon Chuc Nang]============================||";
	cout << "\n||0). Thoat chuong trinh                                              ||";
	cout << "\n||1). Nhap danh sach nhan vien tu file                                ||";
	cout << "\n||2). Xem danh sach nhan vien                                         ||";
	cout << "\n||3). Dem so luong nhan vien co he so luong >= 3.4                    ||";
	cout << "\n||4). Tim kiem tuyen tinh: theo ten nhan vien, tra ve node cuoi cung  ||";
	cout << "\n||5). Chen 1 nhan vien sau nhan vien co ma nhan vien = x              ||";
	cout << "\n||6). Xoa tat ca nhan vien co ten nhan vien                           ||";
	cout << "\n||7). Dung thuat toan chon truc tiep sap tang theo nam sinh           ||";
	cout << "\n||====================================================================||";
}

int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("CLS");
		XuatMenu();
		cout << "\nVui long nhap so [0..." << soMenu << "] de chon menu, stt = ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;
}

void XuLyMenu(int menu, LIST& l)
{
	char filename[MAX] = "test.txt";
	int kq;
	char ten[10], maNV[8];
	NODE* tim, * q;
	Data nvMoi, x;

	switch (menu)
	{
	case 0:
		cout << "\n0. Thoat chuong trinh";
		exit(0);
		break;

	case 1:
		cout << "\n1. Nhap danh sach nhan vien tu file";
		do
		{
			kq = DocFile(filename, l);
			if (!kq)
				cout << "\nLoi mo file! Nhap lai!\n";
		} while (!kq);
		cout << "\nDanh sach nhan vien la: " << endl;
		XuatDSNV(l);
		break;

	case 2:
		cout << "\n2. Xem danh sach nhan vien\n";
		XuatDSNV(l);
		break;

	case 3:
		cout << "\n3. Dem so luong nhan vien co he so luong >= 3.4\n";
		XuatDSNV(l);
		kq = Dem_HSL(l);
		cout << "\n\nDanh sach co " << kq << " nhan vien co he so luong >= 3.4";
		break;

	case 4:
		cout << "\n4. Tim kiem tuyen tinh: theo ten nhan vien, tra ve node cuoi cung\n";
		XuatDSNV(l);

		cout << "\n\nNhap ten nhan vien can tim: ";
		cin >> ten;

		tim = Search(l, ten);
		if (tim != NULL)
		{
			cout << "\nNhan vien cuoi cung co ten " << ten << " la :";
			TieuDe();
			Xuat1NV(tim->info);
			cout << endl;
			cout << ':';
			for (int i = 1; i <= 56; i++)
				cout << '=';
			cout << ':';
		}
		else
			cout << "\nKhong tim thay nhan vien nao co ten " << ten;
		break;

	case 5:
		cout << "\n5. Chen 1 nhan vien sau nhan vien co ma nhan vien = x \n";
		XuatDSNV(l);

		cout << "\nNhap ma nhan vien can tim: ";
		cin >> maNV;

		cout << "\nNhap thong tin nhan vien moi:";
		cout << "\nMa nhan vien (7 ki tu): ";
		cin >> nvMoi.maNV;
		cout << "Ho: ";
		cin >> nvMoi.ho;
		cout << "Ten lot: ";
		cin >> nvMoi.tenLot;
		cout << "Ten: ";
		cin >> nvMoi.ten;
		cout << "Nam sinh: ";
		cin >> nvMoi.namSinh;
		cout << "He so luong: ";
		cin >> nvMoi.hsLuong;

		q = l.pHead;
		while (q != NULL && strcmp(q->info.maNV, maNV) != 0)
			q = q->pNext;
		if (q != NULL)
		{
			InsertAfter(l, q, nvMoi);
			cout << "\nChen thanh cong! Danh sach nhan vien sau khi chen la:";
			XuatDSNV(l);
		}
		else
			cout << "\nKhong tim thay ma nhan vien " << maNV << " de chen sau.";
		break;

	case 6:
		cout << "\n6. Xoa tat ca nhan vien co ten nhan vien\n";
		XuatDSNV(l);

		cout << "\nNhap ten nhan vien can xoa: ";
		cin >> x.ten;

		Remove_x(l, x);
		cout << "\nDanh sach nhan vien sau khi xoa tat ca nhan vien co ten " << x.ten << " la:";
		XuatDSNV(l);
		break;

	case 7:
		cout << "\n7. Dung thuat toan chon truc tiep SAP TANG theo nam sinh";
		cout << "\nDanh sach truoc khi sap xep: "; XuatDSNV(l);
		cout << "\n\nDanh sach sau khi sap xep:"; List_Selection_Sort(l); XuatDSNV(l);
		break;
	}
	(void)_getch();
}