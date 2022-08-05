#include <stdio.h>
#include <math.h>

int main(){
	printf("Bài 1: \n");
	printf("Tính bình phương số nguyên n. Nhập n: ");
	int n;
	scanf("%d",&n);
	n *= n;
	printf("Bình phương của n = %d\n", n);
	printf("Bài 2: \nTính tổng các số nguyên từ 1 đến n \nNhập n:");
	scanf("%d",&n);
	int m;
	while(n>0){
	m +=n;
	n--;
	};
	printf("Tổng là: %d\n",m);
	printf("\n Bài 3: Viết chương trình tính tổng bình phương của 1 đến số: ");
	scanf("%d",&n);
	printf("S = ");
	int sum = 0;
	for(int i = 1; i <= n; i++){
		printf("%d^2 + ",i);
		sum += i*i;
	};
	printf("\nKết quả là : %d\n",sum);
	printf("Bài 4: Tìm giá trị lớn nhất trong 3 số nguyên a, b, c. \n Nhập 3 số a, b, c: ");
	int a, b, c, max;
	scanf("%d %d %d",&a,&b,&c);
	if(a > b && a > c){
		max = a;
	}else if(a > b && a< c){
		max = c;
	}else if(a>c && a<b){
		max = b;
	};
	printf("Gía trị lớn nhất là: %d\n", max);
	return 0;
}

