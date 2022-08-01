#include<stdio.h>
#include<conio.h>
#define MAX 100

int main() {
	int n;
	float a[MAX];
	do {
		printf("Input the total number of array: ");
		scanf("%d", &n);
		if(n <= 0 || n > MAX) {
			printf("The total number is between %d and %d\n", 1, MAX);
		}
	} while(n <= 0 || n > MAX);
	for(int i = 0; i < n; i++) {
		printf("a[%d]: ", i);
		scanf("%f", &a[i]);
	}
	printf("Print out the element of array\n");
	for(int i = 0; i < n; i++) {
		printf("%8.3f", a[i]);
	}
	// bubble sort
	for(int i = 0; i < n - 1; i++) {
		for(int j = i + 1; j < n; j++) {
			if(a[i] > a[j]) {
				float temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}
		}
	}
	printf("\nThe sorted array\n");
	for(int i = 0; i < n; i++) {
		printf("%8.3f", a[i]);
	}
	getch();
	return 0;
}



