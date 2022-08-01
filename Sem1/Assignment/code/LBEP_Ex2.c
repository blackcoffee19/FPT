#include <stdio.h>
int main(){
    printf("Enter the width of Rectangle: ");
    double x,y;
    scanf("%lf",&x);
    printf("Enter the high of Rectangle: ");
    scanf("%lf",&y);
    double per = (x+y)*2;
    double area = x*y;
    printf("\tPerimeter of the Rectangle: 2 * (%.1f + %.1f) = %.1f\n",x,y,per);
    printf("\tArea of the Rectangle: %.1f * %.1f = %.1f\n",x,y,area);
    return 0;
}