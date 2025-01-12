//1. Khai bao kieu du lieu, hang, ....


//2. Khai bao nguyen mau ham
int TinhTong(int n);
void XuatNSoNguyen(int n);
void TimTatCaUocSoCuaN(double sum);
bool KiemTraNCoPhaiSoNguyenToKhong(int n);
int XuatSo(int n);


//3. Dinh nghia ham
//Ham tinh tong 1+ 2+ ...+n
int TinhTong(int n)
{
	cout << "\nHam tinh tong!";
	int s = 0;
	for (int i = 1; i <= n; i++)
	{
		s += i;
	}
	return s;
}
//Ham xuat n so nguyen dau tien
void XuatNSoNguyen(int n)
{
	cout << "\n" << n << " so nguyen dau tien la:\n";
	for (int i = 1; i <= n; i++)
		cout << i << "\t";
}

//tim tat ca uoc so cua n
void TimTatCaUocSoCuaN(int n)
{
	
	for (int i = 1; i <= n; i++)
		if (n % i == 0) cout << i << "\t";
}
bool KiemTraNCoPhaiSoNguyenToKhong(int n)
{
	if (n < 2) {
		return false;
	}
	else {
		int c = 0;
		for (int i = 2; i < n; i++) {
			if (n % i == 0) {
				return false;
			}
		}
		return true;
	}

}
int XuatSo(int n) {
	int s = 0;
	if (n < 2) {
		cout << "k phai snt";

	}
	else {
		for (int i = 2; i <= n; i++) {
			if (KiemTraNCoPhaiSoNguyenToKhong(i)) {
				s++;
				cout << i << "\t";
				if (s % 5 == 0) {
					cout << endl;
				}
			}
		}
	}
	return 0;
}
