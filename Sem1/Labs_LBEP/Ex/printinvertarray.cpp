#include <stdio.h>
#include <conio.h>
#define MAX 100

int main() {
   int n, i, a[MAX];
   int *ptr;

   ptr = &a[0];
   do {
		printf("Input the total number of array: ");
		scanf("%d", &n);
		if(n <= 0) {
			printf("The total number of array is between %d - %d\n", 0, MAX);
		}
	} while(n <= 0 || n > MAX);
   	printf("\nInput the element of array (element per line)\n");
   	for (i = 0; i < n; i++) {
    	scanf("%d", ptr);
    	ptr++;
   	}
	printf("Print out the element of array\n");
	for(int i = 0; i < n; i++) {
		printf("%5d", *(a+i));
	}
   	ptr = &a[n - 1];
   	printf("\nThe inverted array\n");
   	for (i = n - 1; i >= 0; i--) {
    	printf("%5d", *ptr);
    	ptr--;
	}
	return(0);
}

