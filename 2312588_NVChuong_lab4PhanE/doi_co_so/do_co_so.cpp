#include <iostream>
#include <string>
using namespace std;

string convertBase(unsigned int numberToConvert, int base)
{
    string representation;
    string digits = "0123456789ABCDEF";

    while (numberToConvert != 0)
    {
        representation = digits[numberToConvert % base] + representation;
        numberToConvert /= base;
    }

    return representation;
}     

int main()
{
    unsigned int n;
    int b;
    cout << "Nhap so nguyen duong n: ";
    cin >> n;
    cout << "Chon he co so (2 <= b <= 16): \n";
    cout << "Doi sang he nhi phan (b=2)\n";
    cout << "Doi sang he bat phan (b=8)\n";
    cout << "Doi sang he thap luc phan (b=16)\n";
    cout << "Doi sang he co so 7 (b=7)\n";
    cout << "Doi sang he co so b bat ky (2 <= b <= 16)\n";
    cin >> b;

    if (b == 5) {
        cout << "Nhap gia tri cua b: ";
        cin >> b;
    }

    switch (b) {
    case 1:
        std::cout << "So " << n << " trong he nhi phan la: " << convertBase(n, 2) << "\n";
        break;
    case 2:
        std::cout << "So " << n << " trong he bat phan la: " << convertBase(n, 8) << "\n";
        break;
    case 3:
        std::cout << "So " << n << " trong he thap luc phan la: " << convertBase(n, 16) << "\n";
        break;
    case 4:
        std::cout << "So " << n << " trong he co so 7 la: " << convertBase(n, 7) << "\n";
        break;
    default:
        std::cout << "So " << n << " trong he co so " << b << " la: " << convertBase(n, b) << "\n";
        break;
    }

    return 0;
}
