#include <iostream>
#include <bitset>
using namespace std;

int main() {
    int n;
    cout << "Nhap so nguyen duong n: ";
    cin >> n;

    // Xuất các số từ 1 tới n
    cout << "Cac so tu 1 toi " << n << " la:\n";
    for (int i = 1; i <= n; i++) {
        cout << i << "\t";
        if (i % 10 == 0) {
            cout << "\n";
        }
    }

    // Đếm số chia hết cho 3 nhưng không chia hết cho 4
    int count = 0;
    for (int i = 1; i <= n; i++) {
        if (i % 3 == 0 && i % 4 != 0) {
            count++;
        }
    }
    cout << "\nSo luong so chia het cho 3 nhung khong chia het cho 4 tu 1 toi " << n << " la: " << count << "\n";

    // Đếm số lượng chữ số của n
    int temp = n;
    int digits = 0;
    while (temp != 0) {
        temp /= 10;
        digits++;
    }
    cout << "So luong chu so cua " << n << " la: " << digits << "\n";

    // Đảo ngược số n
    temp = n;
    int reverse = 0;
    while (temp != 0) {
        reverse = reverse * 10 + temp % 10;
        temp /= 10;
    }
    cout << "So " << n << " sau khi dao nguoc la: " << reverse << "\n";

    // Tính tổng các chữ số trong n
    temp = n;
    int sum = 0;
    while (temp != 0) {
        sum += temp % 10;
        temp /= 10;
    }
    cout << "Tong cac chu so trong  " << n << " la: " << sum << "\n";

    // Chữ số đầu tiên trong n
    temp = n;
    int firstDigit;
    while (temp != 0) {
        firstDigit = temp % 10;
        temp /= 10;
    }
    cout << "Chu so dau tien trong " << n << " la: " << firstDigit << "\n";

    // Đổi số n sang hệ nhị phân
    cout << "So " << n << " sau khi doi sang so nhi phan la: " << bitset<32>(n) << "\n";

    // Kiểm tra số n có phải số hoàn hảo
    sum = 0;
    for (int i = 1; i < n; i++) {
        if (n % i == 0) {
            sum += i;
        }
    }
    if (sum == n) {
        cout << n << " la so hoan hao.\n";
    }
    else {
        cout << n << " khong phai so hoan hao.\n";
    }

    // Xuất tất cả số hoàn hảo trong phạm vi từ 1 đến n
    cout << "Cac so hoan hao trong pham vi tu 1 den " << n << " la: ";
    for (int i = 1; i <= n; i++) {
        sum = 0;
        for (int j = 1; j < i; j++) {
            if (i % j == 0) {
                sum += j;
            }
        }
        if (sum == i) {
            cout << i << " ";
        }
    }
    cout << "\n";

    // Tìm số nguyên m lớn nhất 
    sum = 0;
    int m = 0;
    while (sum <= n) {
        m++;
        sum += m;
    }
    cout << "so nguyen m lon nhat tu 1+2+3...m<=" << n << " la: " << m - 1 << "\n";

    return 0;
}
