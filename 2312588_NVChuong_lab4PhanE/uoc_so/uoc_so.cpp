#include <iostream>
#include <vector>
using namespace std;

vector<int> divisors(int n) {
    vector<int> divs;
    for (int i = 1; i <= n; i++) {
        if (n % i == 0) {
            divs.push_back(i);
        }
    }
    return divs;
}

double squareRoot(int n) {
    double x = n;
    double y = 1;
    double e = 0.000001;
    while (x - y > e) {
        x = (x + y) / 2;
        y = n / x;
    }
    return x;
}

int largestPowerOfTwo(int n) {
    int res = 1;
    while (res <= n) {
        res *= 2;
    }
    return res / 2;
}

int main() {
    int n;
    cout << "Nhap so nguyen duong n: ";
    cin >> n;

    vector<int> divs = divisors(n);
    cout << "Cac uoc so cua " << n << " là: ";
    int sum = 0;
    for (int i = 0; i < divs.size(); i++) {
        cout << divs[i] << " ";
        sum += divs[i];
    }
    cout << "\nSo luong cac uoc so cua " << n << " la: " << divs.size() << "\n";
    cout << "Tong cac uoc so cua " << n << " la: " << sum << "\n";
    cout << "Can bac 2 cua " << n << " la: " << squareRoot(n) << "\n";
    cout << "So lon nhat nho hon hoac bang " << n << " ma la luy thua cua 2 la: " << largestPowerOfTwo(n) << "\n";

    return 0;
}
