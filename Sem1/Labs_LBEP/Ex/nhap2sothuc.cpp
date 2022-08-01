#include <stdio.h>
#include <conio.h>

int main() {
	float n1, n2, sum;
	printf("Input n1: ");
	scanf("%f", &n1);
	printf("Input n2: ");
	scanf("%f", &n2);
	sum = n1 + n2;
	printf("The sum is: %.2f", sum);
	getch();
}
