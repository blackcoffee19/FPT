#include <stdio.h>
int main(){
	int max =1 ,sum =0;
	int num[5];
	for(int i = 0; i <5;i++){
		printf("Enter number %d: ",i+1);
		scanf("%d",&num[i]);
		sum += num[i];
	};
	printf("Sum: %d\n",sum);
	printf("Check num: ");
	int nu;
	scanf("%d",nu);
	prinf("num %d : %d\n", nu, num[nu-1]);
	return 0;
}
