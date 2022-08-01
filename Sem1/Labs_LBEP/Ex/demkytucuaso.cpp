#include <stdio.h>
#include <conio.h>

int main() {
	int n, tmp;
	printf("Input n: ");
	scanf("%d", &n);
	int count = 0;
	tmp = n;
	if (n == 0) 
		count = 1;
	while (tmp != 0) {
		count++;
		tmp = tmp / 10; // chia nguyen
	}
	printf("Number of digits of the number %d is: %d", n, count);
	getch();
}

