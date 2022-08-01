#include<stdio.h>
#include<conio.h>

const int minYear = 1900, maxYear = 10000;
int isLeafYear(int year) {
	return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}
int findMonthDates(int month, int year) {
	int monthDates;
	switch(month) {
	case 1: case 3: case 5: case 7: case 8: case 10: case 12:
		monthDates = 31;
		break;
	case 4: case 6: case 9 : case 11:
		monthDates = 30;
		break;
	case 2:
		int leafYear = isLeafYear(year);
		if(leafYear == 1) {
			monthDates = 29;
		} else {
			monthDates = 28;
		}
	}
	return monthDates;
}

void findNextDate(int date, int month, int year)
{
	int monthDates = findMonthDates(month, year);
	if (date < monthDates) {	// date tu 1 ... monthDates, tang ngay len 1
		date++;
	} else if (month < 12) {	// ngay cuoi thang, tang 1 se la ngay dau thang ke
		date = 1; month++;
	} else { // truong hop ngay 31 thang 12, tang 1 se la ngay dau thang 1 nam ke
		date = month = 1;
		year++;
	}
	printf("\nThe next date is: %d - %d - %d ", date, month, year);
}
int main()
{
	int date, month, year;

	do {
		printf("Input year: ");
		scanf("%d", &year);
		if(year < minYear || year > maxYear)
		{
			printf("Wrong year, please input again !");
		}
	} while(year < minYear || year > maxYear);

	do {
		printf("Input month: ");
		scanf("%d", &month);
		if (month < 1 || month > 12)
			printf("Wrong month, please input again !");
	} while(month < 1 || month > 12);

	int monthDates = findMonthDates(month, year);
	do
	{
		printf("Input date: ");
		scanf("%d",&date);
		if(date < 1 || date > monthDates) {
			printf("Wrong date, please input again !");
		}
	} while(date < 1 || date > monthDates);
	
	findNextDate(date, month, year);

	getch();
	return 0;
}

