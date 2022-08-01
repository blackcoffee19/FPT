#include <stdio.h>
#include <string.h>

int main(){
	char s1[50], s2[50];
	//1. Nhap s1, s2

	printf("Vui lòng nhập chuỗi thứ nhất: ");
	gets(s1);
	printf("Vui lòng nhập chuỗi thứ hai: ");
	gets(s2);
	//2. Gọi hàm strcmp();
	int n = strcmp(s1,s2);
	//4. Sắp thứ tự độ dài tăng dần
	if(n > 0){
		printf("Dài nhất: %s\n",s1);
		printf("Ngắn hơn: %s\n",s2);
	}else if(n<0){
		printf("Dài nhất: %s\n",s2);
		printf("Ngắn hơn: %s\n",s1);
	}else{
		printf("Độ dài %s == độ dài %s\n",s1,s2);
	}
	return 0;
}
