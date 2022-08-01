#include <stdio.h>
#include <math.h>
int main(){
	int num,a,b,c,x,del;
	double x1,x2;
	printf("Bài 1: kiểm tra số được nhập là chẵn hay lẽ\nNhập số : ");
	scanf("%d",&num);
	if(num%2 == 0){
		printf("Số %d là số chẵn.\n",num);
	}else {
		printf("Số %d là số lẻ.\n",num);
	};
	printf("Bài 2: Giả phương trình bậc 2: ax^2 + bx + c\nNhập a, b, c: ");
	scanf("%d %d %d",&a ,&b, &c);
	printf("f(x) = %dx^2 +%dx + %d \n",a,b,c);
	del = b*b - 4*a*c;
	if(del < 0){
		printf("Phương trình vô nghiệm\n\n");
	}else if(del == 0){
		printf("Phương trình có nghiệm kép\n");
		x1 = -b/(2*a);
		printf("X1 = X2 = %.2f\n\n",x1);
	}else {
		printf("Phương trình có 2 nghiệm phân biệt\n");
		x1 = (-b - sqrt(del))/(2*a);
		x2 = (-b + sqrt(del))/(2*a);
		printf("X1 = %.2f \t X2 = %.2f\n\n",x1,x2);
	};
	printf("Bài 3: Hoán đổi 2 số\nNhập 2 số a và b: ");
	scanf("%d %d",&a ,&b);
	c = a;
	a =b;
	b = c;
	printf("a = %d \t b = %d\n\n", a,b);
	printf("Bài 4: Kiểm tra năm nhuận\n(Năm nhuận chia hết cho 4, không chia hết cho 100 những chia hết cho 400)\nNhập năm để kiểm tra: ");
	scanf("%d",&x);
	if(x%4 != 0){
		printf("%d không phải năm nhuận!!\n",x);
	}else {
		if(x%100 == 0 && x%400 != 0){
			printf("%d không phải năm nhuận!!\n",x);
		}else {
			printf("%d là năm nhuận !\n\n",x);
		}
	};
	return 0;
}
