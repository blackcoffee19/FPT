#include <stdio.h>
#include <string.h>

int main(){
	char s1[50], s2[50];
	//1. Nhap s1, s2

	printf("Vui lòng nhập chuỗi thứ nhất: ");
	gets(s1);
	printf("Vui lòng nhập chuỗi thứ hai: ");
	gets(s2);
	//2. Hiển thị s1, s2
	printf("Chuỗi 1: %s\n",s1);
	printf("Chuỗi 2: %s\n",s2);
	//3: hàm strcat();
	strcat(s1,s2);
	//4. Hien thi s1 s2
	printf("Chuỗi 1 mới là: %s\n",s1);
	printf("Chuỗi 2 mới là: %s\n",s2);

	return 0;
}
