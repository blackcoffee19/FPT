#include <stdio.h>

struct Student{
	char name[40];
	char subject[40];
	int marks;
};

int main(){
	//1. Khai báo biến cấu trúc 
	//Cách 1: struct Student sv1,sv2;
	//Cách 2:
	int max;
	typedef struct Student sinhvien;
	printf("Nhập số sinh viên max: ");
	scanf("%d",&max);
	sinhvien sv[max];
	sinhvien std = {"Le Van A","DDD",84}; 

	//2. Nhập data
	for(int i = 0; i<max;i++){
		getchar();
		printf("Vui lòng nhập tên sinh viên %d: ",i+1);
		gets(sv[i].name);
		printf("Vui lòng nhập môn học: ");
		gets(sv[i].subject);
		printf("Vui lòng nhập điểm sinh viên %d:",i+1);
		scanf("%d",&sv[i].marks);
		printf("\n");
	}
	//3. Hiển thị thông tin
	for(int i = 0; i<max; i++){
		printf("Tên sinh viên %d: %s\n",i+1,sv[i].name);
		printf("Môn học: %s\n",sv[i].subject);
		printf("Điểm sinh viên là: %d\n",sv[i].marks);
	}
	printf("Tên sinh viên 3: %s\n",std.name);
	printf("Môn học: %d\n",std.subject);
	printf("Điểm sinh viên là: %d\n",std.marks);
	return 0;
}
