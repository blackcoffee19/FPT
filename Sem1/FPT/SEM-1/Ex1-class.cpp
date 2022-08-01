#include  <stdio.h>

int main(){

	char abc = 'A'; 	/*abc of type character - %c*/
	int xyz = 10;		/*xyz of type integer  - %d*/
	float length = 20.5;	/*length of type float - %f*/
	double area = 30.7;	/*area of type double - %lf*/
	long liteyrs = 100;	/*liteyrs of type long - %ld*/
	short arm = 5;		/*arm of type short - %d*/

	printf("abc of type character: %c\n", abc);
	printf("xyz of type integer: %d\n", xyz);
	printf("length of type float: %.2f\n", length);
	printf("area of type double: %.2lf\n", area);
	printf("liteyrs of type long: %ld\n", liteyrs);
	printf("arm of type short - %d\n", arm);
}
