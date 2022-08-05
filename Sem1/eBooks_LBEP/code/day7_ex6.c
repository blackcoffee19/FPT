#include <stdio.h>

int main(){
	int a, b, *c;
	//Pass by value -> truyền bằng tham trị: Bản sao
	a = b;
	printf("%d",a);
	//Pass by reference -> tryền bằng tham chiếu: Bản gốc
	c = &b;
	*c =123;
	scanf("%d",&a);
	return 0;
}
