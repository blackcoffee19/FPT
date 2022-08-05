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
	printf("\n No \t Name \t Subject \t Mark\t Result\n");
	printf("_____|__________|____|_____|_____\n");
	//3. Hiển thị thông tin
	for(int i = 0; i<max; i++){
		char re;
		if(sv[i].marks>5){
			re = 'P';
		}else{
			re = 'R';
		}
		printf("%d \t %s \t %s \t %d \t %c \n",i+1,sv[i].name,sv[i].subject,sv[i].marks,re);
	};
	return 0;
}
