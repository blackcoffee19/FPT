#include <stdio.h>

int main(){
	//Cach 1:
	int sl = 1; hd = 1000;
	if(hd >= 1000){
		if(sl > 5){
			printf("HD\n+ Coupon\n");
		}else{
			printf("HD\n");
		}
	}else{
		printf("HD\n");
	};
	//Cach 2:
	int sl2 = 3, hd2 = 13000;
	if((sl2 > 5)&&(hd2 >= 1000)){
		printf("HD\n+ Coupon\n");
	} else {
		printf("HD\n");
	}
	return 0;
}
