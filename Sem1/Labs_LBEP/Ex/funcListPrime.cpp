#include<stdio.h>
#include<conio.h>
#include<math.h>
// thuat toan tim so nguyen to cai tien
int isPrime(int n) {
	if (n < 2) {
		return 0;
	} else if (n > 2) {
		if (n % 2 == 0) {
			return 0;
		}
		for (int i = 3; i <= sqrt((float)n); i += 2) {
			if (n % i == 0) {
				return 0;
			}
		}
	}
	return 1;
}
void listPrime(int n)
{
	for(int i = 2; i < n; i++) {
		if(isPrime(i))
			printf("%4d", i);
	}
}
int main()
{
	int n;
	printf("Input n: ");
	scanf("%d", &n);

	listPrime(n);

	getch();
	return 0;
}

