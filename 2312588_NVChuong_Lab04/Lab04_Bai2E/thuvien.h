

// Định nghĩa kiểu dữ liệu cho lý lịch nhân viên
struct LLNhanVien {
    char maNV[8];
    char hoTen[15];
    char diaChi[15];
    int trinhDoVH;
    int luongCB;
};

// Định nghĩa kiểu dữ liệu cho chấm công nhân viên
struct ChamCongNV {
    char maNV[8];
    int ngayNghiCoPhep;
    int ngayNghiKoPhep;
    int ngayLamThem;
};

// Định nghĩa Node và danh sách liên kết cho lý lịch nhân viên
struct tagNodeLL {
    LLNhanVien info;
    tagNodeLL* pNext;
};
typedef tagNodeLL NODELL;
struct LLNV {
    NODELL* pHead;
    NODELL* pTail;
};

// Định nghĩa Node và danh sách liên kết cho chấm công
struct tagNodeCC {
    ChamCongNV info;
    tagNodeCC* pNext;
};
typedef tagNodeCC NODECC;
struct ChamCong {
    NODECC* pHead;
    NODECC* pTail;
};

// Khai báo nguyên mẫu các hàm cho lý lịch nhân viên
NODELL* GetNode_LL(LLNhanVien x);
void CreatList_LL(LLNV& l);
void InsertTail_LL(LLNV& l, LLNhanVien x);
int TapTin_List_LL(const char* filename, LLNV& l);

// Khai báo nguyên mẫu các hàm cho chấm công
NODECC* GetNode_CC(ChamCongNV x);
void CreatList_CC(ChamCong& l);
void InsertTail_CC(ChamCong& l, ChamCongNV x);
int TapTin_List_CC(const char* filename, ChamCong& l);

// Khai báo hàm tính và xuất bảng lương
void XuatBangLuong(LLNV l, ChamCong g);
void TieuDe();

// Định nghĩa hàm cho lý lịch nhân viên
NODELL* GetNode_LL(LLNhanVien x) {
    NODELL* p = new NODELL;
    if (p != NULL) {
        p->info = x;
        p->pNext = NULL;
    }
    return p;
}

void CreatList_LL(LLNV& l) {
    l.pHead = l.pTail = NULL;
}

void InsertTail_LL(LLNV& l, LLNhanVien x) {
    NODELL* new_ele = GetNode_LL(x);
    if (new_ele == NULL) {
        cout << "\nKhong du bo nho";
        return;
    }
    if (l.pHead == NULL) {
        l.pHead = l.pTail = new_ele;
    }
    else {
        l.pTail->pNext = new_ele;
        l.pTail = new_ele;
    }
}

int TapTin_List_LL(const char* filename, LLNV& l) {
    ifstream in(filename);
    if (!in) return 0;
    LLNhanVien x;
    CreatList_LL(l);
    while (!in.eof()) {
        in >> x.maNV >> x.hoTen >> x.diaChi >> x.trinhDoVH >> x.luongCB;
        InsertTail_LL(l, x);
    }
    in.close();
    return 1;
}

// Định nghĩa hàm cho chấm công
NODECC* GetNode_CC(ChamCongNV x) {
    NODECC* p = new NODECC;
    if (p != NULL) {
        p->info = x;
        p->pNext = NULL;
    }
    return p;
}

void CreatList_CC(ChamCong& l) {
    l.pHead = l.pTail = NULL;
}

void InsertTail_CC(ChamCong& l, ChamCongNV x) {
    NODECC* new_ele = GetNode_CC(x);
    if (new_ele == NULL) {
        cout << "\nKhong du bo nho";
        return;
    }
    if (l.pHead == NULL) {
        l.pHead = l.pTail = new_ele;
    }
    else {
        l.pTail->pNext = new_ele;
        l.pTail = new_ele;
    }
}

int TapTin_List_CC(const char* filename, ChamCong& l) {
    ifstream in(filename);
    if (!in) return 0;
    ChamCongNV x;
    CreatList_CC(l);
    while (!in.eof()) {
        in >> x.maNV >> x.ngayNghiCoPhep >> x.ngayNghiKoPhep >> x.ngayLamThem;
        InsertTail_CC(l, x);
    }
    in.close();
    return 1;
}

// Hàm tính và xuất bảng lương
void XuatBangLuong(LLNV l, ChamCong g) {
    TieuDe();
    NODELL* p = l.pHead;
    NODECC* q = g.pHead;

    while (p != NULL && q != NULL) {
        int phuTroi = 0;

        if (p->info.trinhDoVH == 5) phuTroi += p->info.luongCB * 0.1;
        else if (p->info.trinhDoVH == 6) phuTroi += p->info.luongCB * 0.2;

        phuTroi += p->info.luongCB * 0.04 * q->info.ngayLamThem;
        phuTroi -= p->info.luongCB * 0.04 * q->info.ngayNghiKoPhep;

        if (q->info.ngayNghiCoPhep >= 15) {
            phuTroi -= p->info.luongCB * 0.1;
        }

        int luongThucLinh = p->info.luongCB + phuTroi;

        cout << setiosflags(ios::left)
            << setw(10) << p->info.maNV
            << setw(15) << p->info.hoTen
            << setw(10) << p->info.luongCB
            << setw(10) << phuTroi
            << setw(10) << luongThucLinh << endl;

        p = p->pNext;
        q = q->pNext;
    }
}

void TieuDe() {
    cout << setiosflags(ios::left)
        << setw(10) << "Ma NV"
        << setw(15) << "Ho Ten"
        << setw(10) << "Luong CB"
        << setw(10) << "Phu Troi"
        << setw(10) << "Luong Thuc Linh" << endl;
    cout << string(55, '=') << endl;
}
