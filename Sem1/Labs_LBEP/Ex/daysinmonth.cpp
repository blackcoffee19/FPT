#include<stdio.h>
#include<conio.h>
#include<stdlib.h>

const int minYear = 1900, maxYear = 10000;
int main() {
	int year, month;
	printf("Input month: ");
	scanf("%d", &month);
	if (month < 1 || month > 12) {
		printf("Wrong month, program exit.\n");
		exit(1);
	}
	printf("Input year: ");
	scanf("%d", &year);
	if(year < minYear || year > maxYear) {
		printf("The year is between %d and %d.\n", minYear, maxYear);
		exit(1);
	}
	
	switch(month) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		printf("This month has 31 days.\n");
		break;
	case 4: case 6: case 9 : case 11:
		printf("This month has 30 days.\n");
		break;
	case 2:
		int isLeafYear = (year % 4 == 0 && year % 100 != 0 || (year % 400 == 0));
		if(isLeafYear) {
			printf("This month has 29 days.\n");
		} else {
			printf("This month has 28 days.\n");
		}
	}

	getch();
	return 0;
}
