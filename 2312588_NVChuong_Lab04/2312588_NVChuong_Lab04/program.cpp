#include<iostream>
#include<fstream>

using namespace std;
void ChayChuongTrinh();
#include "thuvien.h"
#include "menu.h"
int main()
{
	ChayChuongTrinh();
	return 1;
}
void ChayChuongTrinh()
{
	LIST l;
	int soMenu = 18, menu;
	
	do
	{
		system("ClS");
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, l);
		system("PAUSE");

	} while (menu > 0);
}