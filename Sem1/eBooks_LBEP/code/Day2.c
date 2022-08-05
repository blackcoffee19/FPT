#include <stdio.h>
#include <math.h>

int main(){
	//1. Ko co doi so
	printf("Chi co control string");
	//2. Co doi so (argument) va vi du 1 hang so (constant)
	printf("\n%d la so nguyen", 10);
	//3.Doi so co the la 1 bien
	char ch = 'a';
	printf("\n%c la ky tu", ch);
	//4.Doi so co the la mot bieu thuc (expression)
	int n = 4, m = 6;
	printf("\n%d + %d = %d",n, m, n+m);
	//5. Doi so co the la mot han (function)
	printf("\nBinh phuong cua %d = %.2f",m , pow(6,2));

	//Summary: match the argument list in number, type, order
	printf("\nConstant: %d\nVariable:%c\nExpression: %d\nFuntion: %.2f", 10, ch, m+n, pow(3,4));

	//Escape  character: \\
	printf("\n\\blackcoffee\\code\\FPT\\SEM-1\n");
	//Excape character: \"
	printf("\"Ban khoe khong?\" tieng Anh la: \"How are you?\"\n");
	//Escape character: %%
	printf("\tToan tu mod 10 %% 3 = %d\n", 10%3);

	//1.NHap gia trij cho x va y = 2 lenh scanf
	int x, y;
	printf("Vui long nhap gia tri cho x va y: ");
	scanf("%d",&x);
	scanf("%d",&y);
	printf("Gia tri vua nhap la: %d va %d\n", x, y);
	//2. Nhap gia tri cho k va l  = 1 lenh scanf
	printf("Vui long nhap gia tri cho k va l: ");
	int k, l;
	scanf("%d%d",&k,&l);
	printf("Gia trij k va l vua nhap la: %d %d\n", k, l);

	//3. Nhap ky tu voi getchar()
	char sh;
	printf("Vui long nhap 1 ky tu: ");
	sh = getchar();
	printf("Ky tu vua nhap la: %c", sh);
	printf("In kieu putchar(): ");
	putchar(sh);

	//1. Hang ky tu
	putchar('Z');
	//2. Nonprinting char
	putchar('\n');
	//3. Ascii
	putchar(65);
return 0;
}
