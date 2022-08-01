#include<math.h>
#include<conio.h>
#include<stdio.h>
main()
{
    float a,b,c,d;
    printf("Input a: ");
    scanf("%f",&a);
	printf("Input b: ");
    scanf("%f",&b);
    printf("Input c: ");
    scanf("%f",&c);
    
    d=b*b-4*a*c;
    if (d<0)
        printf("The equation has no solution.");
    else if (d==0)
        printf("The equation has a double solution : %f",-b/(2*a));
    else
        printf("The equation has 2 distinct solutions: %f,%f",(-b+sqrt(d))/(2*a),(-b-sqrt(d))/(2*a));        
  	getch();
}
