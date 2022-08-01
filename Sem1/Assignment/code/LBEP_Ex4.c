#include <stdio.h>

int main() {
	printf("*******************************************\n");
	printf("\tC PROGRAM LANGUAGE\n");
	printf("\t\t1. Question 02.\n");
	printf("\t\t2. Question 03.\n");
	printf("\t\t3. Exit.\n");
	printf("*******************************************\n");
	printf("Enter Choice (1-3):");
	int x;
	double per, area;
	scanf("%d",&x);
	if(x == 1){
	double y,z;
	printf("Enter the width of Rectangle: ");
	scanf("%lf",&y);
	printf("Enter the high of Rectangle: ");
	scanf("%lf",&z);
	per = (y+z)*2;
	area = y*z;
	printf("\tPerimeter of the Rectangle: 2 * ( %.1f + %.1f) = %.1f\n",y,z,per);
	printf("\tArea of the Rectangle: %.1f * %.1f = %.1f\n",y,z,area);
	} else if( x == 2) {
	printf("Enter the radius of Circle: ");
	double r;
	scanf("%lf",&r);
	per = r*2*3.14;
	area = r*r*3.14;
	printf("\tPerimeter of the Circle: 2 * %.1f * 3.14 = %.1f\n",r,per);
	printf("\tArea of the Rectangle: %.1f * %.1f *3.14 = %.1f\n",r,r,area);
	} else {
	printf("\tGoodbye!\n");
	};
	return 0;
}
