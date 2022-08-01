#include<stdio.h>
#include<conio.h>

int main()
{
	float a, b;
	float x;
	printf("Input a: ");
	scanf("%f", &a);
	printf("Input b: ");
	scanf("%f", &b);

	if(a == 0) {
		if(b == 0)
			printf("The equation has countless solutions\n");
		else
			printf("The equation has no solution\n");
	} else {
		x = -b / a;
		printf("\The equation has 1 solution: %f", x);
	}
	getch();
	return 0;
}

