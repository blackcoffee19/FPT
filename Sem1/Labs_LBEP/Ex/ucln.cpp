#include<stdio.h>
#include<conio.h>

int main()
{
	int a, b;
	printf("Input a: ");
	scanf("%d", &a);
	printf("Input b: ");
	scanf("%d", &b);

	printf("The greatest common divisor of %d and %d is ", a, b);
	while (a != b) {
		if(a > b)
			a = a - b;
		else
			b = b - a;
	}
	printf("%d", a);
	getch();
	return 0;
}

