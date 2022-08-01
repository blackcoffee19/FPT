#include <stdio.h>
#include <conio.h>

int main() {
	int n, result;
	printf("Input n: ");
	scanf("%d", &n);
	result = n % 2;
	if (result == 0) // n chia het cho 2 => n la so chan
		printf("%d is even", n);
	else 
		printf("%d is odd", n);
	getch();
}
