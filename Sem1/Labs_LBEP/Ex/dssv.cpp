#include <stdio.h>
#include <conio.h>
#include <string.h>
/* run this program using the console pauser or add your own getch, system("pause") or input loop */

struct Sinhvien {
	char masv[12];
	char ten[50];
	int gioitinh;
	char email[50];		// 116 byte
} ;

void menu();
void NhapSinhvien(Sinhvien *sv);
void InSinhvien(Sinhvien sv);
void InsertionSort(Sinhvien *sv, int n);
int TimSinhVienTheoMasv(char *masv, Sinhvien *sv, int n);

int main(int argc, char** argv) {
	menu();
	
	return 0;
}

void menu() 
{
	struct Sinhvien sv[100];
	int count=0;
	printf("Quan Ly Sinh Vien.\n");
	int choose;
	int isExit = 0;
	while (1) 
	{
		printf("1. Nhap Sinh Vien.\n");
		printf("2. In Sinh Vien.\n");
		printf("3. Insertion Sort.\n");
		printf("4. Tim Sinh vien theo Ma.\n");
		printf("9. Thoat\n");
		scanf("%d", &choose);
		switch(choose)
		{
			case 1:
				NhapSinhvien(&sv[count++]);
				break;
			case 2: {
				for (int i = 0; i < count; i++) {
					InSinhvien(sv[i]);
				}
				break;
			case 3:
				InsertionSort(sv, count);
				break;
			case 4: {
				char ma[12];
				printf("Nhap ma sinh vien can tim: ");
				fflush(stdin);
				gets(ma);
				int pos = TimSinhVienTheoMasv(ma, sv, count);
				if (pos >= 0) 
				{
					printf("Tim thay.\n");
					InSinhvien(sv[pos]);
				}
				else 
				{
					printf("Khong co sinh vien voi ma: %s\n", ma);
				}
				break;
			}
			case 9:
				isExit = 1;
				break;
			}
		}
		if (isExit) {
			break;
		}
	}
}

void NhapSinhvien(Sinhvien *sv) 
{
	printf("Nhap thong tin sinh vien.\n");
	
	printf("Ma: ");
	fflush(stdin);
	scanf("%s", &sv->masv);
	
	printf("Ten: ");
	fflush(stdin);
	gets(sv->ten);
	
	printf("Gioi tinh: ");
	char buf[10];
	scanf("%s", buf);
	if (!strcmp(buf, "nam")) {
		sv->gioitinh = 1;
	} else {
		sv->gioitinh = 0;
	}
	
	printf("Email: ");
	fflush(stdin);
	scanf("%s", &sv->email);
}

void InSinhvien(Sinhvien sv) 
{
	printf("\nThong tin sinh vien.\n");
	printf("Ma: %s\n", sv.masv);
	printf("Ten: %s\n", sv.ten);
	printf("Gioi tinh: %s\n", sv.gioitinh==1? "Nam": "Nu");
	printf("Email: %s\n", sv.email);
}

void swap(Sinhvien *sv1, Sinhvien *sv2)
{
	Sinhvien tmp;
	memcpy(&tmp, sv1, sizeof(Sinhvien));
	memcpy(sv1, sv2, sizeof(Sinhvien));
	memcpy(sv2, &tmp, sizeof(Sinhvien));
}

void BubbleSort(Sinhvien *sv, int n) 
{
	for (int i = 0; i < n; i++)
	{
		for (int j = n-1; j>=i; j--)
		{
			if (strcmp(sv[j].ten, sv[j-1].ten) < 0)
			{
				swap(&sv[j], &sv[j-1]);
			}
		}
	}
}

void InsertionSort(Sinhvien *sv, int n)
{
	int pos;
	Sinhvien x;
	for (int i = 1; i < n; i++)
	{
		memcpy(&x, &sv[i], sizeof(Sinhvien));
		pos = i-1;
		while ( pos >= 0 && (strcmp(sv[pos].ten, x.ten) > 0) )
		{
			memcpy(&sv[pos+1], &sv[pos], sizeof(Sinhvien));
			pos--;
		}
		memcpy(&sv[pos+1], &x, sizeof(Sinhvien));
	}
}

int TimSinhVienTheoMasv(char *masv, Sinhvien *sv, int n)
{
	int pos = 0;
	for (; pos < n; pos++)
	{
		if (!strcmp(masv, sv[pos].masv))
			break;
	}
	if (pos < n)
		return pos;
	else 
		return -1;
}

