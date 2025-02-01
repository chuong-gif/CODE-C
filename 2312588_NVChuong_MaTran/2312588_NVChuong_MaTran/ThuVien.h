#define MAX 100
typedef int MaTran[MAX][MAX];

void NhapMaTran(MaTran a, int n);
void NhapMaTranTD(MaTran a, int n);
void XuatMaTran(MaTran a, int n);
int TinhTong(MaTran a, int n);
void HoanVi(int& a, int& b);
void SapTangHangi(MaTran a, int n, int i);
void SuatCPT(MaTran a, int n, int i);
int TimMaxI(MaTran a, int n, int i);

void NhapMaTranTD(MaTran a, int n)
{
	srand(time(NULL));
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{

			a[i][j] = rand() % MAX - MAX / 2;
		}
}
void NhapMaTran(MaTran a, int n)
{

	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{
			cout << "\nNhap a[" << i << "][" << j << "]=";
			cin >> a[i][j];

		}
}
void XuatMaTran(MaTran a, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "\n";
		for (int j = 0; j < n; j++)
		{
			cout << a[i][j] << "\t";
		}
	}

}

int TinhTong(MaTran a, int n)
{
	int s = 0;
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{
			s += a[i][j];
		}

	return s;
}

int TongCheoChinh(MaTran a, int n)
{
	int s = 0;
	for (int i = 0; i < n; i++)
		s += a[i][i];
	return s;
}
void HoanVi(int& a, int& b)
{
	int c = a;
	a = b;
	b = c;
}
//Sap xep tang: a[i][0], a[i][1], ... a[i][n-1] --> mang 1 chieu
void SapTangHangi(MaTran a, int n, int i)
{
	int j, k;
	bool dk;

	for (j = 0; j < n - 1; j++)
		for (k = j + 1; k < n; k++)
		{
			dk = a[i][j] > a[i][k];
			if (dk)
				HoanVi(a[i][j], a[i][k]);

		}
}
void SapTangTheoHang(MaTran a, int n)
{
	for (int i = 0; i < n; i++)
		SapTangHangi(a, n, i);
}
void SuatCPT(MaTran a, int n, int i)
{
	for (int j = 0; j < n; j++){
	cout << a[i][j] << "\t"; 
	}
}
int TimMaxI(MaTran a, int n, int i) {
	int max = a[i][0];
	for (int j=1; j < n; j++) {
		if (a[i][j] > max);
			max = a[i][j];
	}
	return max;
}
int TongCacPTCuaI(MaTran a, int n) {
	int sum = 0;
	for (int i = 0; i < n; i++) {
		sum += TimMaxI(a, n, i);
	}
	return sum;
}
void SapGiamCotj(MaTran a, int n, int j)
{
	int i, k;
	bool dk;
	for (i = 0; i< n-1; i++)
		for (k = i + 1; k < n; k++)
		{
			dk = a[i][j] < a[i][k];
			if (dk)
				HoanVi(a[i][j], a[j][k]);
		}
}