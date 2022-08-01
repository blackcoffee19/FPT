#include<stdio.h>
#include<conio.h>

int main()
{
	int n, d;
	printf("input n: ");
	scanf("%d", &n);
	if(n < 2)
		printf("%d is not a prime number\n", n);
	else
		if(n == 2)
			printf("%d is a prime number\n", n);
		else if (n % 2 == 0)
			printf("%d is not a prime number\n", n);
		else {
			d = 3;
			while(d <= n)
			{
                if(n % d == 0)
					break;
				d = d + 2;
			}
			if(d == n)
				printf("%d is a prime number\n", n);
			else
				printf("%d is not a prime number\n", n);
		}
	getch();
	return 0;
}

