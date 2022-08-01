#include<stdio.h>
#include<conio.h>

int main() {
	int n;
	int *a;
	do {
		printf("Input the total number of array: ");
		scanf("%d", &n);
		if(n <= 0) {
			printf("The total number of array must be greater than %d\n", 0);
		}
	} while(n <= 0);
	a = new int[n];
	printf("\nInput the element of array\n");
	for(int i = 0; i < n; i++) {
		printf("a[%d]: ", i);
		scanf("%d", a+i);
	}
	printf("Print out the element of array\n");
	for(int i = 0; i < n; i++) {
		printf("%5d", *(a+i));
	}
	// bubble sort
	for(int i = 0; i < n - 1; i++) {
		for(int j = i + 1; j < n; j++) {
			if(*(a+i) > *(a+j)) {
				float temp = *(a+i);
				*(a+i) = *(a+j);
				*(a+j) = temp;
			}
		}
	}
	printf("\nThe sorted array\n");
	for(int i = 0; i < n; i++) {
		printf("%5d", *(a+i));
	}
	getch();
	return 0;
}



