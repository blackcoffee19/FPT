#include <stdio.h>
#include <math.h>

int main(){
    printf("Enter the radius of Circle: ");
    double x;
    scanf("%lf",&x);
    printf("\tPerimeter of the Cirle: 2* %.2f * 3.14 = %.2f\n",x,x*2*3.14);
    printf("\tArea of the Circle: %.2f * %.2f * 3.14 = %.2f\n",x,x,x*x*3.14);
    return 0;
}