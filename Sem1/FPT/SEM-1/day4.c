#include <stdio.h>

int main() {
	/*
		A. Group A
			1. Fixed Loop: for
			2. Variable Loop: while, do... while
		B. Group B
			1. Checking before (condition checking): for, while
			2. Check After (condition checking): do ... while
		_________
		for (intial; condition; evaluate value)
		initial : khoi tao
		condition: dieu kien. Toi dau thi dungL
		increa.decreament expression : Bieu thuc dieu kien. Moi lan thuc hien tang giam bao nhieu?
	*/
	//1. For
//	for(int i = 1; i<= 10; i++){
//		printf("%d\t",i);
//	};
	//2. While
//	int i = 0;
//	while(i <= 10){
//		printf("%d\t",i);
//		i++;
//	};
	//3. do ... while
//	int i =1;
//	do{
//		printf("%d\t",i);
//		i++;
//	}while(i <=10);

//	for(int i = 0, ch = 65; i< 5;i++,ch + 2*1){
//		printf("%x\t",ch);
//	}
//	for(int dong = 1; dong <= 5; dong++){
//		for(cot =1 ; cot <= 5;cot++){
//			printf("*\t");
//		}
//		printf("\n\n\n");
	printf("so sao nguoi dung yeu cau\n");
	int num, count;
	scanf("%d",&num);
	for(int i = 0; i < num;i++){
		for(int j = 0; j < num-i+1;j++){
			printf(" ");
		};
		for(int m = 0; m < i+1;m++){
			printf("*");
		};
		printf("\n");
	}
	return 0;
}
