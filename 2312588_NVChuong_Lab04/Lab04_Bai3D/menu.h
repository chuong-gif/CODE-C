void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu, LIST& l);


void XuatMenu()
{
    cout << "\n========================================Chon Chuc Nang=====================================================";
    cout << "\n0. Tao danh sach";
    cout << "\n1. Xem danh sach";
    cout << "\n2. Tach danh sach nhan vien thanh 2 danh sach, danh sach dau gom nhung nhan vien co luong <= x.";
    cout << "\n3. Tach danh sach nhan vien theo cach luan phien.";
    cout << "\n4. Dao nguoc danh sach.";
    cout << "\n5. Sap danh sach tang dan theo ten, ten trung thi tang dan theo ho; ten va ho trung thi tang theo ten lot.";
    cout << "\n6. Thoat";
    cout << "\n===========================================================================================================";
}

int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("CLS"); //xoa man hinh
		XuatMenu();
		cout << "\nNhap mot so ( 0 <= so <= " << soMenu << " ) de chon menu, stt = ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;
}

void XuLyMenu(int menu, LIST& l)
{
    nodeData x, y;
    NODE* p;
    int kq;
    LIST l1, l2;
    char filename[MAX];

    switch (menu)
    {
    case 0: 
        cout << "\n0. Tao du lieu\n";
        do
        {
            cout << "\nNhap ten tap tin, filename = ";
            _flushall();
            cin >> filename;
            kq = TapTin_List(filename, l);
            if (!kq)
                cout << "\nLoi mo file ! nhap lai\n";
        } while (!kq);
        Xuat_DSNV(l);
        cout << endl;
        break;
    case 1:
        system("CLS");

        Xuat_DSNV(l);
        break;
    case 2:
        system("CLS");
        double x;
        cout << "Nhap gia tri x (luong <= x): ";
        cin >> x;
        Tach_Luong_x(l, x);
        Xuat_DSNV(l);
        break;
    
    case 3:
        system("CLS");
        Tach_LuanPhien(l);
        Xuat_DSNV(l);

        break;
    case 4:
        system("CLS");
        DaoNguoc_DS(l);
        Xuat_DSNV(l);

        break;
    case 5:
        system("CLS");
        List_SapTang_Ten_Ho_TLot(l); 
        cout << "\nDanh sach nhan vien sau khi sap xep:\n";
        Xuat_DSNV(l);  
        Xuat_DSNV(l);

        break;
    case 6:
        system("CLS");
        cout << "Thoat khoi chuong trinh." << endl;
        break;
    
    }
}