#include<stdio.h>
#include<conio.h>
int main()
{
	int month;
	printf("Input month: ");
	scanf("%d", &month);
	if (month == 1 || month == 2 || month == 3) {
		printf("The 1st quarter\n");
	} else if (month == 4 || month == 5 || month == 6) {
		printf("The 2nd quarter\n");
	} else if (month == 7 || month == 8 || month == 9) {
		printf("The 3rd quarter\n");
	} else if (month == 10 || month == 11 || month == 12) {
		printf("The 4th quarter\n");
	} 
	getch();
	return 0;
}

