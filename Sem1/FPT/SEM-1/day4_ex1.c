#include <stdio.h>
//NhanLT@fe.edu.vn
int main(){
	//1. Nhập 2 số n1 và n2
	int n1, n2;
	char x;
	printf("Nhập số nguyên thứ nhất n1 = ");
	scanf("%d",&n1);
	//2. Nhập toán tử (+, -, *, /)
	printf("Nhập số nguyên thứ hai n2 = ");
	scanf("%d",&n2);
	getchar(); //cach giang ho
	printf("Nhap toan tu (+ - & /): ");
	x = getchar();
	//3. Hiện thị kết quả theo toán tử đã nhập
	switch(x){
	case '+':
		int sum = n1 + n2;
		printf("Tổng %d + %d = %d\n",n1,n2,sum);
		break;
	case '-':
		int de = n1-n2;
		printf("Hiệu của %d - %d = %d\n",n1,n2,de);
		break;
	case '*':
		int dc = n1*n2;
		printf("Phép nhân của %d * %d = %d\n", n1,n2, dc);
	case '/':
		int cd = n1 /n2;
		printf("Phép chia của %d / %d = %d\n", n1, n2, cd);
		break;
	default:
		printf("Something wrong!\n");
		break;
	};
	return 0;
}
