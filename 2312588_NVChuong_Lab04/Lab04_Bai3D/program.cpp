#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <conio.h>
using namespace std;
#include "thuvien.h"
#include "menu.h"
void ChayChuongTrinh();
int main()
{
	ChayChuongTrinh();
	return 1;
}


void ChayChuongTrinh()
{
	int soMenu = 6,
		menu;
	LIST l;
	int	n = 0;
	do
	{
		system("CLS");
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, l);
		system("PAUSE");
	} while (menu >= 0);
}



