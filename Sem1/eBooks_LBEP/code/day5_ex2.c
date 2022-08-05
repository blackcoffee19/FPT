#include <stdio.h>

int main(){
	int num1 = 0, num2 = 1, num3,max;
	printf("Enter a number: ");
	scanf("%d",&max);
	printf("%d \t %d \t",num1,num2);
	while(num3< max && (num2+num1) < max){
	num3 = num1+num2;
	num1 = num2;
	num2 = num3;
	printf("%d \t",num3);
	};
	printf("\n");
	return 0;
}
