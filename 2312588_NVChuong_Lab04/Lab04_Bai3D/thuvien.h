//Dinh nghi kieu du lieu : LIST
#define MAX 1000

struct nhanvien
{
	char maNV[8];
	char hoNV[10];
	char tenLot[10];
	char ten[10];
	char diachi[12];
	int namSinh;
	double luong;
};
typedef nhanvien nodeData;
struct tagNode
{
	nodeData info;
	tagNode * pNext;
};
typedef tagNode NODE;
struct LIST
{
	NODE* pHead;
	NODE* pTail;
};
//=============================================
NODE* GetNode(nodeData x);
void CreatList(LIST& l);
int IsEmpty(LIST l);
void InsertHead(LIST& l, nodeData x);
void InsertTail(LIST& l, nodeData x);
//========================================
int TapTin_List(char* filename, LIST& l);
void Xuat_DSNV(LIST l);
void Xuat_NV(nodeData p);
void TieuDe();
//========================================
void Tach_Luong_x(LIST l, double x);
void Tach_LuanPhien(LIST l);
void DaoNguoc_DS(LIST l);
void Remove_Ten(LIST& l, char ten[10]);
int RemoveNode_First(LIST& l, char ten[10]);
void Hoanvi(nodeData& x, nodeData& y);
void List_SapTang_Ten_Ho_TLot(LIST& l);
void List_Selection_Sort(LIST& l);

//========================================
//Tao nut moi
NODE* GetNode(nodeData x)
{
	NODE* p;
	p = new NODE;
	if (p != NULL)
	{
		p->info = x;
		p->pNext = NULL;
	}
	return p;
}


//Khoi tao DSLK don rong
void CreatList(LIST& l)
{
	l.pHead = l.pTail = NULL;
}
//Kiem tra danh sach co rong
int IsEmpty(LIST l)
{
	if (l.pHead == NULL)
		return 1;
	return 0;
}
//Chen x vao dau ds
void InsertHead(LIST& l, nodeData x)
{
	NODE* new_ele = GetNode(x);
	if (new_ele == NULL)
	{
			cout << "\nKhong du bo nho";
		system("PAUSE");
		return;
	}
	if (l.pHead == NULL) //DS rong
	{
		l.pHead = new_ele;
		l.pTail = l.pHead;
	}
	else
	{
		new_ele->pNext = l.pHead; //chen vao dau DS
		l.pHead = new_ele;
	}
}
//Chen x vao cuoi ds
void InsertTail(LIST& l, nodeData x)
{
	NODE* new_ele = GetNode(x);
	if (new_ele == NULL)
	{
		cout << "\nKhong du bo nho";
		system("CLS");
		return;
	}
	if (l.pHead == NULL)
	{
		l.pHead = new_ele; l.pTail = l.pHead;
	}
	else
	{
		l.pTail->pNext = new_ele;
		l.pTail = new_ele;
	}
}
//=============================================
//Chuyen du lieu tap tin dang list
int TapTin_List(char* filename, LIST& l)
{
	nodeData x;
	ifstream in(filename);
	if (!in)
		return 0;
	CreatList(l);
	while (!in.eof())
	{
		in >> x.maNV;
		in >> x.hoNV;
		in >> x.tenLot;
		in >> x.ten;
		in >> x.diachi;
		in >> x.namSinh;
		in >> x.luong;
		InsertTail(l, x);
	}
	in.close();
	return 1;
}
//Xuat tieu de
void TieuDe() {
	cout << left << setw(10) << "Ma NV"
		<< setw(15) << "Ho NV"
		<< setw(15) << "Ten Lot"
		<< setw(15) << "Ten"
		<< setw(15) << "Dia Chi"
		<< setw(10) << "Nam Sinh"
		<< setw(10) << "Luong"
		<< endl;
	for (int i = 0; i < 90; i++) cout << "=";
	cout << endl;
}
//Xuat 1 nhan vien
void Xuat_NV(nodeData p) {
	cout << left << setw(10) << p.maNV
		<< setw(15) << p.hoNV
		<< setw(15) << p.tenLot
		<< setw(15) << p.ten
		<< setw(15) << p.diachi
		<< setw(10) << p.namSinh
		<< setw(10) << fixed << setprecision(2) << p.luong
		<< endl;
}
//Xuat danh sach nhan vien
void Xuat_DSNV(LIST l) {
	if (IsEmpty(l)) {
		cout << "Danh sach rong!" << endl;
		return;
	}

	TieuDe(); // Gọi hàm TieuDe để xuất tiêu đề
	NODE* p = l.pHead;
	while (p != NULL) {
		Xuat_NV(p->info); // Gọi hàm Xuat_NV để xuất thông tin nhân viên
		p = p->pNext;
	}
}
void Tach_Luong_x(LIST l, double x)
{
	NODE* p;
	LIST l1, l2;
	p = l.pHead;
	if (p == NULL)
	{
		cout << "\nDS l rong";
		system("PAUSE");
		return;
	}
	CreatList(l1);
	CreatList(l2);
	while (p != NULL)
	{
		if (p->info.luong <= x)
			InsertTail(l1, p->info);
		else
			InsertTail(l2, p->info);
		p = p->pNext;
	}
	cout << "\n- Danh sach l1 (luong <= " << x << "):\n";
	Xuat_DSNV(l1);
	cout << "\n- Danh sach l2 (luong > " << x << "):\n";
	Xuat_DSNV(l2);
	cout << endl;
}
void Tach_LuanPhien(LIST l)
{
	NODE* p;
	LIST l1, l2;
	p = l.pHead;
	if (p == NULL)
	{
		cout << "\nDS l rong";
		system("PAUSE");
		return;
	}
	int k = 1; //khoa
		CreatList(l1);
	CreatList(l2);
	while (p != NULL)
	{
		if (k == 1)
			InsertTail(l1, p->info);
		else
			InsertTail(l2, p->info);
		p = p->pNext;
		k = 3 - k;
	}
	cout << "\n- Danh sach l1:\n";
	Xuat_DSNV(l1);
	cout << "\n- Danh sach l2 :\n";
	Xuat_DSNV(l2);
	cout << endl;
}
void DaoNguoc_DS(LIST l)
{
	NODE* p;
	LIST l1;
	p = l.pHead;
	if (p == NULL)
	{
		cout << "\nDS l rong";
		system("PAUSE");
		return;
	}
	CreatList(l1);
	while (p != NULL)
	{
		InsertHead(l1, p->info);
		p = p->pNext;
	}
	cout << "\n- Danh sach dao nguoc cua l:\n";
	Xuat_DSNV(l1);
}
//Sap tang theo ten
void List_Selection_Sort(LIST& l)
{
	NODE* min;
	NODE* p, * q;
	p = l.pHead;
	while (p != l.pTail)
	{
		min = p;
		q = p->pNext;
		while (q != NULL)
		{
			if (_strcmpi(q->info.ten, min->info.ten) < 0)
				min = q;
			q = q->pNext;
		}
		Hoanvi(min->info, p->info);
		p = p->pNext;
	}
}

void List_SapTang_Ten_Ho_TLot(LIST & l)
{
	List_Selection_Sort(l);
	NODE* p, * q;
	for (p = l.pHead; p != l.pTail; p = p->pNext)
		for (q = p->pNext; q != NULL; q = q->pNext)
			if (_strcmpi(p->info.ten, q->info.ten) == 0)
				if (_strcmpi(p->info.hoNV, q->info.hoNV) > 0)
					Hoanvi(q->info, p->info);
	for (p = l.pHead; p != l.pTail; p = p->pNext)
		for (q = p->pNext; q != NULL; q = q->pNext)
			if (_strcmpi(p->info.ten, q->info.ten) == 0 && _strcmpi(p->info.hoNV, q->info.hoNV) == 0)
				if (_strcmpi(p->info.tenLot, q->info.tenLot) > 0)
					Hoanvi(q->info, p->info);
}

void Hoanvi(nodeData& x, nodeData& y)
{
	nodeData t = x;
	x = y;
	y = t;
}