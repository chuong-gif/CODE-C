void XuatMenu();
int XuLyMenu();
void ChonMenu();

void XuatMenu() 
{
	cout << "njakj ";
	cout << " ";

}
int XuLyMenu(int soMenu) {
	int stt;
	for (;;) {
		system("CLS");
		XuatMenu();
		cout << "vui long nhap[0..." << soMenu << "] de chon so stt = ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;

}
void ChonMenu(int menu, LIST& l)
{
	switch (menu)
	{
		case 0:

			break;
			(void)_getch();
	}
}

