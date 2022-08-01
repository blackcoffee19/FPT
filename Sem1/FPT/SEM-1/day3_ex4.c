#include <stdio.h>

int main(){
	int x = 1;
	printf("***************************\n");
	printf("+++++C Program Language++++++++++\n");
	printf("\t1. Say 'Hello'\n");
	printf("\t2. Say 'World'\n");
	printf("\t3. Say 'Goodbye'\n");
	printf("***************************\n");
	do{
		getchar();
		printf("Enter a number: ");
		scanf("%d",&x);
		switch(x){
			case 1:
				printf("Choice is 1\n\tHello\n");
				break;
			case 2:
				printf("Choice is 2\n\tWorld\n");
				break;
			case 3:
				printf("Choice is 3\n\tGoodbye\n");
				break;
			default:
				printf("Invalid number\n");
				break;

		};
	} while(x != 3);
	return 0;

}
