#include <stdio.h>

int main(){
	char a,b;
	printf("Nhap chu in hoa,in chu in thuong\n");
	printf("Vui long nhap chu in hoa: ");
	a = getchar();
	b = a+32;
	printf("%c co kieu in thuong la: %c\n", a, b);
	return 0;
}
