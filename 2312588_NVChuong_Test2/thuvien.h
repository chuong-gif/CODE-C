#define MAX 100

struct NhanVien
{
	char maNV[8];
	char ho[10];
	char tenLot[10];
	char ten[10];
	int namSinh;
	double hsLuong;
};

typedef	NhanVien Data;

struct tagNode
{
	Data info;
	tagNode* pNext;
};

typedef tagNode NODE;

struct LIST
{
	NODE* pHead;
	NODE* pTail;
};

//Khai bao nguyen mau
//========================================================
NODE* GetNode(Data x);
void CreatList(LIST& l);
int IsEmpty(LIST l);
void InsertTail(LIST& l, Data x);
//========================================================
int DocFile(char* filename, LIST& l);
void TieuDe();
void Xuat1NV(Data p);
void XuatDSNV(LIST l);
//========================================================
int Dem_HSL(LIST l);
NODE* Search(LIST l, char ten[10]);
void InsertAfter(LIST& l, NODE* q, Data x);
void AddFirst(LIST& l, NODE* new_ele);
//========================================================
int RemoveNode_First(LIST& l, Data x);
void Remove_x(LIST& l, Data x);
void HoanVi(Data& nv1, Data& nv2);
void List_Selection_Sort(LIST& l);
//========================================================

//Tao nut moi
NODE* GetNode(Data x)
{
	NODE* p = new NODE;
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

//Chen x vao cuoi ds
void InsertTail(LIST& l, Data x)
{
	NODE* new_ele = GetNode(x);
	if (new_ele == NULL)
	{
		cout << "\nKhong du bo nho";
		return;
	}
	if (l.pHead == NULL)
	{
		l.pHead = new_ele;
		l.pTail = l.pHead;
	}
	else
	{
		l.pTail->pNext = new_ele;
		l.pTail = new_ele;
	}
}

//Chuyen du lieu tap tin dang list
int DocFile(char* filename, LIST& l)
{
	Data x;
	ifstream in(filename);
	if (!in)
		return 0;
	CreatList(l);
	while (!in.eof())
	{
		in >> x.maNV;
		in >> x.ho;
		in >> x.tenLot;
		in >> x.ten;
		in >> x.namSinh;
		in >> x.hsLuong;
		InsertTail(l, x);
	}
	in.close();
	return 1;
}

void TieuDe()
{
	cout << endl;
	cout << ':';
	for (int i = 1; i <= 56; i++)
		cout << '=';
	cout << ':' << endl;

	cout << setiosflags(ios::left)
		<< '|'
		<< setw(8) << "MaNV"
		<< '|'
		<< setw(10) << "Ho"
		<< '|'
		<< setw(10) << "Ten lot"
		<< '|'
		<< setw(10) << "Ten"
		<< '|'
		<< setw(6) << "NS"
		<< '|'
		<< setw(7) << "HSLuong"
		<< '|';

	cout << endl;
	cout << '|';
	for (int i = 1; i <= 56; i++)
		cout << '=';
	cout << '|';
}

void Xuat1NV(Data p)
{
	cout << endl;
	cout << setiosflags(ios::left)
		<< '|'
		<< setw(8) << p.maNV
		<< '|'
		<< setw(10) << p.ho
		<< '|'
		<< setw(10) << p.tenLot
		<< '|'
		<< setw(10) << p.ten
		<< '|'
		<< setw(6) << p.namSinh
		<< '|'
		<< setw(7) << p.hsLuong
		<< '|';
}

void XuatDSNV(LIST l)
{
	NODE* p;
	p = l.pHead;
	TieuDe();
	while (p != NULL)
	{
		Xuat1NV(p->info);
		p = p->pNext;
	}
	cout << endl;
	cout << ':';
	for (int i = 1; i <= 56; i++)
		cout << '=';
	cout << ':';
}

//3. Đếm số lượng nhân viên có hệ số lương >= 3.4.
int Dem_HSL(LIST l)
{
	int dem = 0;
	NODE* p;
	p = l.pHead;
	while (p != NULL)
	{
		if (p->info.hsLuong >= 3.4)
			dem++;
		p = p->pNext;
	}
	return dem;
}

//4. Tìm kiếm tuyến tính: theo tên nhân viên, trả về node cuối.
NODE* Search(LIST l, char ten[10])
{
	NODE* p = l.pHead;
	NODE* kq = NULL;
	while (p != NULL)
	{
		if (strcmp(p->info.ten, ten) == 0)
			kq = p; // node cuoi cung tim thay
		p = p->pNext;
	}
	return kq;
}

//5. Chèn 1 nhân viên sau nhân viên có mã nhân viên=x (x nhập từ bàn phím).
void InsertAfter(LIST& l, NODE* q, Data x)
{
	NODE* new_ele = GetNode(x);
	if (new_ele == NULL)
	{
		cout << "\nLoi cap phat bo nho! Khong thuc hien duoc thao tac nay.";
		return;
	}
	if (q != NULL)
	{
		new_ele->pNext = q->pNext;
		q->pNext = new_ele;
		if (q == l.pTail)
			l.pTail = new_ele;
	}
	else
		AddFirst(l, new_ele); // Chen vao dau neu q == NULL
}

// Ham chen nut vao dau l
void AddFirst(LIST& l, NODE* new_ele)
{
	if (l.pHead == NULL)
	{
		l.pHead = new_ele;
		l.pTail = l.pHead;
	}
	else
	{
		new_ele->pNext = l.pHead;
		l.pHead = new_ele;
	}
}

//6. Xóa tất cả nhân viên theo tên nhân viên.
int RemoveNode_First(LIST& l, Data x)
{
	NODE* p = l.pHead;
	NODE* q = NULL;
	while (p != NULL)
	{
		if (strcmp(p->info.ten, x.ten) == 0)
			break;
		q = p;
		p = p->pNext;
	}
	if (p == NULL)
		return 0;
	if (q != NULL)
	{
		if (p == l.pTail)
			l.pTail = q;
		q->pNext = p->pNext;
	}
	else
	{
		l.pHead = p->pNext;
		if (l.pHead == NULL)
			l.pTail = NULL;
	}

	delete p;
	return 1;
}

void Remove_x(LIST& l, Data x)
{
	while (RemoveNode_First(l, x));
}

//7. Dùng thuật giải chọn trực tiếp sắp danh sách tăng dần theo năm sinh.
void HoanVi(Data& nv1, Data& nv2)
{
	Data x = nv1;
	nv1 = nv2;
	nv2 = x;
}

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
			if (q->info.namSinh < min->info.namSinh)
				min = q;
			q = q->pNext;
		}
		HoanVi(min->info, p->info);
		p = p->pNext;
	}
}