#include <stdio.h>
int main(){
	int num;
	int arr[10];
	for(int i = 0; i < 10;i++){
		printf("Enter number %d: ",i+1);
		scanf("%d",&arr[i]);
		while(arr[i]<=0 || arr[i]>100){
			printf("\nWrong number! Number must be in 1-100!\nTry again!\n");
			printf("\nEnter nunber %d: ",i+1);
			scanf("%d",&arr[i]);
		};
	};
	printf("\nEnter any number you want from 1- 100 to test: ");
	scanf("%d",&num);
	while(num <= 0 || num > 100){
		printf("Wrong number! Try again!");
		getchar();
		printf("\nEnter any number from 1-100: ");
		scanf("%d",&num);
	};
	printf("Cac so chia het cho %d: ",num);
	for(int i =0; i< 10; i++){
		if(arr[i]%num == 0){
			printf("%d, ",arr[i]);
		} else {
			continue;
		};
	};
	printf("\n");
	return 0;
}
