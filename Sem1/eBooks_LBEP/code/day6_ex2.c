#include <stdio.h>
int main(){
	int n;
	printf("Enter the size of array: ");
	scanf("%d",&n);
	int temp, arr[n];

	for(int i =0 ; i< n; i++){
		printf("Enter number no.%d : ",i+1);
		scanf("%d",&arr[i]);
	};
	for(int i = 0; i < n-1; i++){
		for(int j = i+1; j < n; j++){
			if(arr[i]>arr[j]){
				temp = arr[i];
				arr[i] =  arr[j];
				arr[j] = temp;
			}
		}
	};
	printf("[");
	for(int i = 0; i< n; i++){
		printf("%d ,",arr[i]);
	};
	printf("]\n");
	return 0;
}
