#include <stdio.h>
#include <math.h>
int main(){
	int n;
	printf("Tính diện tích hình vuông: (diện tích hình vuông  = bình phương 1 cạnh\n");
	printf("Nhập số chiều dài 1 cạnh: (cm)");
	scanf("%d",&n);
	printf("Diện tích của hình vuông cạnh: %d là = %.2f(cm^2)\n", n , pow(n,2));
	return 0;
}
