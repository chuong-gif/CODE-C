#define MAX 100
#define TAB '\t'
struct NgayThang
{
	unsigned short Ngay;
	unsigned short Thang;
	unsigned short Nam;

};
struct NhanVien
{
	unsigned int MaSo;
	string HoTen;
	string DiaChi;
	NgayThang NgaySinh;
	float HeSoLuong;
};
typedef NhanVien MangNV[MAX];

void XuatTieuDe() {
	cout << endl
		<< setiosflags(ios::left)
		<< setw(6) << "Ma so"
		<< setw(25) << "Ho va ten"
		<< setw(25) << "Dia chi"
		<< setw(15) << "Ngay sinh"
		<< setw(7) << "HSLuong"
		<< endl;
}
void XuatDongKeNgang()
{
	cout << setiosflags(ios::left)
		<< setw(6) << "====="
		<< setw(25) << "======================"
		<< setw(25) << "======================"
		<< setw(15) << "============="
		<< setw(7) << "======"
		<< endl;

}
void XuatMotNV(NhanVien nv)
{
	cout << setiosflags(ios::left)
		<< setw(6) << nv.MaSo
		<< setw(25) << nv.HoTen
		<< setw(25) << nv.DiaChi
		<< setw(2) << nv.NgaySinh.Ngay << "/ "
		<< setw(2) << nv.NgaySinh.Thang << "/ "
		<< setw(7) << nv.NgaySinh.Nam
		<< setw(7) << nv.HeSoLuong
		<< endl;
}
void XuatDSNV(MangNV a, int n)
{
	XuatTieuDe();
	XuatDongKeNgang();
	for (int i = 0; i < n; i++)
	{
		XuatMotNV(a[i]);
		XuatDongKeNgang();
		cout << endl;
	}
}

void NhapMotNV(NhanVien & nv)
{
	cout << "Nhap ma so NV    :";
	cin >> nv.MaSo;

	cout << "Nhap ho va ten   :";
	cin.ignore();
	getline(cin,nv.HoTen);

	cout << "Nhap dia chi     :";
	_flushall();
	getline(cin,nv.DiaChi);

	cout << "Nhap ngay sinh (thu tu ngay thang nam)  :  ";
	cin >> nv.NgaySinh.Ngay
		>> nv.NgaySinh.Thang
		>> nv.NgaySinh.Nam;

	cout << "Nhap he so luong : ";
	cin >> nv.HeSoLuong;
};

void NhapDSNV(MangNV a, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << endl << "Nhap vien thu "
			<< i + 1 << ":" << endl;
		NhapMotNV(a[i]);
	}
	cout << endl << "Da nhap xong" << endl;
}
int KiemTraMaNV(MangNV a, int n, int maSo)
{
	for (int i = 0; i < n; i++)
		if (a[i].MaSo == maSo)
			return 1;
	return 0;

}
void ThemMotNV(MangNV a, int& n)
{
	NhanVien nv;
	NhapMotNV(nv);
	while (KiemTraMaNV(a, n, nv.MaSo)) {
		cout << endl << "Ma so " << nv.MaSo
			<< " da bi trung, nhap lai ma khac  :";
		cin >> nv.MaSo;
	}
	a[n] = nv;
	n++;
		
}