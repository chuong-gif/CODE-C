#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <conio.h>
using namespace std;
#include "thuvien.h"

void ChayChuongTrinh();

int main() {
    ChayChuongTrinh();
    return 0;
}

void ChayChuongTrinh() {
    LLNV dsNhanVien;      // Danh sách liên kết lưu lý lịch nhân viên
    ChamCong dsChamCong;  // Danh sách liên kết lưu chấm công

    // Đọc dữ liệu từ tệp lý lịch và chấm công
    if (TapTin_List_LL("llnv.txt", dsNhanVien) && TapTin_List_CC("chamcong.txt", dsChamCong)) {
        // Xuất bảng lương nếu cả hai tệp được mở thành công
        XuatBangLuong(dsNhanVien, dsChamCong);
    }
    else {
        cout << "\nLoi mo tap tin";
        _getch();
    }
}
