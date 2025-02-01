#include<iostream>
#include<conio.h>
#include<time.h>
using namespace std;
#include"ThuVien.h"
#include"Menu.h"


void ChayChuongTrinh();
int main()
{

	ChayChuongTrinh();
	_getch();
	return 0;
}

void ChayChuongTrinh()
{
	MaTran a = {
		{ 1, 5, 8 },
		{ -8, -5, 0},
		{ 2, -5, 3 }
	};
	int n = 3, soMenu = 8, chon;
	do
	{
		system("cls");
		XuatMenu();
		chon = ChonMenu(soMenu);
		XuLyMenu(chon, a, n);
	} while (chon != 0);
}