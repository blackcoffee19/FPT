#include<stdio.h>
#include<conio.h>

int main() {
	int i, j, n;
	printf("Input n: ");
	scanf("%d", &n);
	// 1. Tam giac can dac
	for(i = 1; i <= n; ++i) {
		for(j = 1; j <= n + i - 1; ++j) {
			printf((j < n - i + 1) ? " " : "%c", 234);
		}
		putchar('\n');
	}
	// 2. Tam giac can rong
	for(i = 1; i <= n; ++i) {
		for(j = 1; j <= n + i - 1; ++j) {
			printf((j == n - i + 1 || j == n + i - 1 || i == n) ? "%c" : " ", 234);
		}
		putchar('\n');
	}
	printf("\n");
	// 3. Tam giac vuong can dac 
	for(i = 1; i <= n; ++i) {
		for(j = 1; j <= n; ++j) {
			printf((j <= i) ? "%c" : " ", 234);
		}
		printf("\n\n");
	}
	// 4. Tam giac vuong can rong
	for(i = 1; i <= n; ++i) {
		for(j = 1; j <= n; ++j) {
			printf((j == i || j == 1 || i == n) ? "*" : " ");
		}
		printf("\n");
	}
	getch();
	return 0;
}

