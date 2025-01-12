#define MAX 100
struct nhanvien {
	char ho[8];

};
typedef nhanvien Data;
struct tagNode {
	Data info;
	tagNode* pNext;
};
typedef nhanvien NODE;
struct LIST {
	NODE* pHead;
	NODE* pTall;
};