//1. Khai bao thu vien
#include<iostream>
#include<conio.h>
using namespace std;
#include"ThuVien.h"
#include"Menu.h"



//2. Khai bao kieu du lieu, hang, ....

//3. Khai bao nguyen mau ham
void ChayChuongTrinh();

//4. Ham main
void main()
{
	ChayChuongTrinh();
	_getch();
	return;
}

//5. Dinh nghia ham
void ChayChuongTrinh()
{
	int n, chon, somenu = 10;
	do
	{
		system("cls");
		//XuatMenu();
		cout << "\nNhap so nguyen n:";
		cin >> n;
		chon = ChonMenu(somenu);
		XuLyMenu(chon, n);
	} while (chon != 0);

}
