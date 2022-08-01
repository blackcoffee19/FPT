#include <stdio.h>
#include <conio.h>

int isPrime(int n) {
	if(n < 2) {
		return 0;
	} else if (n == 2) {
		return 1;
	} else {
		if(n % 2 == 0) {
			return 0;
		} else {
			int d = 3;
			while(d <= n) {
                if(n % d == 0)
					break;
				d = d + 2;
			}
			if(d == n)
				return 1;
			else
				return 0;
		}
	}
}
int main() {
   int n;

	printf("Input n: ");
	scanf("%d", &n);
	
	if (isPrime(n)) {
		printf("%d is prime number\n", n);
	} else {
		printf("%d is not prime number\n", n);
	}

	return(0);
}

