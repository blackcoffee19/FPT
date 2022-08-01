#include <stdio.h>

int main(){
	printf("Enter a number: ");
	int num;
	int i =1;
	int exp = 0;
	scanf("%d",&num);
	while(exp < num){
		printf("%d \t",exp);
		exp += i;
		i++;
	};
	printf("\n");
	return 0;
}
