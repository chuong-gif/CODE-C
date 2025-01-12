#include <iostream>
#include <vector>
using namespace std;

bool isPrime(int n) {
    if (n <= 1) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;
    for (int i = 3; i * i <= n; i += 2)
        if (n % i == 0)
            return false;
    return true;
}

vector<int> primeFactors(int n) {
    vector<int> factors;
    while (n % 2 == 0) {
        factors.push_back(2);
        n = n / 2;
    }
    for (int i = 3; i <= sqrt(n); i = i + 2) {
        while (n % i == 0) {
            factors.push_back(i);
            n = n / i;
        }
    }
    if (n > 2)
        factors.push_back(n);
    return factors;
}

int main() {
    int n;
    cout << "Nhap so nguyen duong n: ";
    cin >> n;

    int count = 0;
    int sum = 0;
    for (int i = 1; i <= n; i++) {
        if (isPrime(i)) {
            cout << i << "\t";
            count++;
            if (count % 5 == 0) cout << "\n";
            if (n % i == 0) sum += i;
        }
    }
    cout << "\nSo luong so nguyen to tu 1 toi " << n << " la: " << count << "\n";
    cout << "Tong cac uoc so nguyen to cua " << n << " la: " << sum << "\n";

    cout << n << " = ";
    vector<int> factors = primeFactors(n);
    for (int i = 0; i < factors.size(); i++) {
        cout << factors[i];
        if (i != factors.size() - 1) cout << " * ";
    }
    cout << "\n";

    return 0;
}
