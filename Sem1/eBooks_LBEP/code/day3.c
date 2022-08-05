#include <stdio.h>

int main(){
	int num;
	printf("Enter a whole number: ");
	scanf("%d",&num);
	//staircase cau truc bac thang
	if(num % 2 == 0){
		printf("%d is Even number\n",num);
	} else {
		printf("%d is Odd number\n",num);
	};
	return 0;
}
