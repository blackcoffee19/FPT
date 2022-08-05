#include <stdio.h>
#include <math.h>

int main() {
	/*
		1. assignment operator 
		Left (write) = Right (Read)
	*/
	//float i;
	//	1.1 Read from a constant
	// n =10.5;
	//	1.2 Read from a variable
	//float a = 20.3;
	//i = a;
	//	1.3 Read from a function
	//i = pow(a,3);
	//printf("%f",i);

	/* 2. Unary follow by assignment operator
		2.1 n = ++tmp;
			tmp += 1;
			n = tmp;
		=> n = 11; tmp = 11;
		2.2 n = tmp++;
			n = tmp;
			tmp ++;
		=> n = 10; tmp = 11;
	*/
	int n, tmp = 10;
	char x;
	printf("Choose: \na. n = ++tmp \nb. n = tmp++\n ");
	x = getchar();
	if(x == 'a'){

	n = ++tmp;
	printf("n = %d\ttmp = %d\n", n, tmp);
	}else{
	n = tmp++;
	printf("n = %d\ttmp = %d\n",n, tmp);
	};
	return 0;


}
