#include<stdio.h>
#include<conio.h>

int main()
{
	int a, b, c;
	printf("Input edge a: ");
	scanf("%d", &a);

	printf("Input edge b: ");
	scanf("%d", &b);

	printf("Input edge c: ");
	scanf("%d", &c);

	if(a + b <= c || a + c <= b ||  b + c <= a) {
		printf("%d, %d, %d are not 3 edges of a triangle\n", a, b, c);
	} else {
		printf("%d, %d, %d are 3 edges of a triangle \n", a, b, c);
	    if ((a == b) && (b == c)) {
			printf("This is an equilateral triangle \n");
		} else {
			if(a * a + b * b == c * c || a * c + c * c == b * b || b * b + c * c == a * c) {
				if(a == b || a == c || b == c) {
					printf("This is a right isosceles triangle \n");
				} else {
					printf("This is a right triangle \n");
				}
			} else if(a == b || a == c || b == c) {
			    printf("This is an isosceles triangle \n");  
		    } else {
				printf("This is a regular triangle \n");  
			}
		}
	}

	getch();
	return 0;
}

