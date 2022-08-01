#include <stdio.h>
#include <string.h>
int main(){
	int num[3] = {1,3,4};
	printf("num[0] = %d\n",*(num +0)); // *(num + 0) == num[0]
	printf("num[1] = %d\n",*(num +1)); // *(num + 1) == num[1]
	printf("num[2] = %d\n",*(num +2)); // *(num + 2) == num[2]

	/*
		Kết luận:
			*(num +0) , *(num + 1), *(num + 2) -> *num++ => num is a pointer
			Mảng 1 chiều là 1 con trỏ
	*/

	char emailA[40];
	char emailB[40];

	//Nhap chuoi ky tu
	printf("Nhập chuỗi ký tự: ");
	for(int i= 0; i< 5;i++){
		printf("Ký tự %d: ",i+1);
		scanf("%c",&emailA[i]);
		getchar();
	};
	printf("Nhập string: ");
	scanf("%s",emailB);
	//In mang ky tu
	for(int i = 0; i<5; i++){
		printf("%c",emailA[i]);
	};
	printf("\n");
	for(int i=0; i< strlen(emailB); i++){
		printf("%c",emailB[i]);
	};

	//In dang chuoi
	printf("\n%s", emailA);
	printf("\n%s\n", emailB);
	return 0;
}
