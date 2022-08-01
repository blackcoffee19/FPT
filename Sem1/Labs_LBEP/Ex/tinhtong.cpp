#include <stdio.h>
#include <conio.h>

int main() {
	int n, sum = 0;
	printf("Input n: ");
	scanf("%d", &n);
	for (int i = 1; i <= n; i++) {
		sum += i;
	}
	printf("1 + 2 + ... + %d = %d\n", n, sum);
	getch();// ngung man hinh
}
