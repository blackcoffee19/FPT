#include <stdio.h>

int main(){
	int sl1 = 1, hd1 = 100;
	if(hd1 >= 1000){
		printf("HD\n");
		printf("\n+ Coupon\n");

	} else {
		if(sl1 >= 5){
			printf("HD\n");
			printf("\n+ Coupon\n");
		} else {
			printf("HD\n");

		}
	};
	if((hd1 >= 1000) || (sl1 >= 5)){
		printf("HD\n+ Coupon\n");
	}else{
		printf("HD\n");
	};
	return 0;
}
