#include <stdio.h>
void maynghenhac(){
	printf("Dang choi nhac\n");
}
int guitietkiem(int von,int lai){
	return von*lai;
}
int main(){
	//1.Goi ham
	maynghenhac();
	//2.Goiham;
	int von = 10000,lai = 2000;
	printf("Gui tiet kiem la: %d\n",guitietkiem(von,lai));
	return 0;
}
