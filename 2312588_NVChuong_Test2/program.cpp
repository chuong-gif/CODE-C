#include<iostream>
#include<iomanip>
#include<fstream>
#include<conio.h>
using namespace std;

#include"thuvien.h"
#include"menu.h"

void ChayCT();

int main()
{
	ChayCT();
	return 1;
}

void ChayCT()
{
	LIST l;
	int menu, soMenu = 7;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, l);
	} while (menu > 0);
}