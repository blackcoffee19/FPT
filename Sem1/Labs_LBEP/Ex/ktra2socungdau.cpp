#include<stdio.h>
#include<conio.h>

int main()
{
	float a, b;
	printf("Input a: ");
	scanf("%f", &a);
	printf("Input b: ");
	scanf("%f", &b);

	if(a * b > 0)
		printf("\n%10.3f and %10.3f are the same sign", a, b);
	else
		printf("\n%10.3f and %10.3f are opposite sign", a, b);
	getch();
	return 0;
}

