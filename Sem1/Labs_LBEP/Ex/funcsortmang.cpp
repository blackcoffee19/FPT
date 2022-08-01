#include <stdio.h>
#include <conio.h>
#include <string.h>
#define MAX 100
#define NAME_LENGTH 50

void inputArray(char **a, int &n) {
	do {
		printf("Input the total number of array: ");
		scanf("%d", &n);
		if(n <= 0 || n > MAX) {
			printf("The total number is between %d and %d\n", 1, MAX);
		}
	} while(n <= 0 || n > MAX);
		
	for(int i = 0; i < n; i++) {
		fflush(stdin);
		a[i] = new char[NAME_LENGTH];
		printf("a[%d]: ", i);
		gets(a[i]);
	}
}
void printArray(char **a, int n) {
	for(int i = 0; i < n; i++) {
		printf("%10s", a[i]);
	}
}
void sortArray(char **a, int n) {
	// bubble sort
	for(int i = 0; i < n - 1; i++) {
		for(int j = i + 1; j < n; j++) {
			if(strcmp(a[i], a[j]) > 0) {
				char temp[NAME_LENGTH];
				strcpy(temp, a[i]);
				strcpy(a[i], a[j]);
				strcpy(a[j], temp);
			}
		}
	}
}
int main() {
	int n;
	char *a[MAX];
	
	inputArray(a, n);
	printf("Print out the element of array\n");
	printArray(a, n);
	sortArray(a, n);
	
	printf("\nThe sorted array\n");
	printArray(a, n);
	getch();
	return 0;
}

