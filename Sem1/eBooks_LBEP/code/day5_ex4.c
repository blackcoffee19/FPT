#include <stdio.h>

int main(){
	int num, max, total;
	int arr[10];
	for(int i = 0; i < 10; i++){
		printf("Enter %d number: ",i+1);
		scanf("%d",&num);
		arr[i] = num;
	};
	max = arr[0];
	for(int i = 1; i < 10;i++){
		if(arr[i] > max){
			max = arr[i];
		} else {
			continue;
		}
	};
	printf("\nHighest value entered was %d", max);
	total =0;
	for(int i = 0; i< 10; i++){
		total += arr[i];
	};
	int len = sizeof(arr)/sizeof(int);
	printf("\nTotal : %d",total);
	float aver = total/len;
	printf("\nThe average of the elements of array is %.2f\n", aver);
	return 0;
}
