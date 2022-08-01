#include <stdio.h>
squarer(int x){
	int j;
	j = x*x;
	return j;
}
int main(){
	int i;
	//int squarer(int num); if(function is under main())
	for(i = 1; i<=10;i++){
		printf("\nSquare of %d is %d ",i, squarer(i));
	}
	printf("\n");
	return 0;
}
/*squarer(int x){
	int j;
	j = x*x;
	return j;
}*/
