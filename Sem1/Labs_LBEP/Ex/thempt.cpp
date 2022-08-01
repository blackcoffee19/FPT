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
	// add x at position k
	int pos, elem;
	do {
		printf("\nInput position of element (%d --> %d) \n", 0, n);
		scanf("%d", &pos);

		if (pos < 0 || pos > n) {
			printf("\nWrong position, please input again !\n");
		}
	} while (pos < 0 || pos > n);

	printf("\nInput element: ");
	scanf("%d", &elem);

	for(int i = n; i > pos; i--) {
		a[i] = a[i - 1];
	}
	a[pos] = elem;	// chen elem vao vi tri pos
	n++; 	// tang so phan tu cua mang len 1
	
	printf("\nThe array after add element\n");
	for(int i = 0; i < n; i++) {
		printf("%8.3f", a[i]);
	}
	getch();
	return 0;
}

