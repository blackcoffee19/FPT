#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
int* create_arr(){
	int *p;
	int num;
	printf("Nhập chiều dài của mảng: ");
	scanf("%d",&num);
	p = (int *)malloc(num);
	for(int i = 0; i<num; i++){
		printf("Nhập phần tử thứ %d: ",i+1);
		scanf("%d",(p+i));
	};
	return p;
}
int sum_arr(int *arr){
	int sum = 0;
	for(int i = 0; i< sizeof(*arr);i++){
		sum += arr[i];
	};
	return sum;
}
void perform(int *choice, int *arr){
	int num1,num2, *ptr1,*ptr2;
	printf("Bài 1: Cộng 2 số sử dụng con trỏ\n");
	printf("Bài 2: In mảng theo chiều ngược lại\n");
	printf("Bài 3: Tổng các phần tử trong mảng\n");
	printf("\t Nhập 0 để thoát\n");
	scanf("%d",choice);
	switch(*choice){
		case 1:
		printf("Bài 1: Cộng 2 số sử dụng con trỏ\n");
		printf("Nhập 2 số: ");
		scanf("%d %d",&num1,&num2);
		ptr1 = &num1;
		ptr2 = &num2;
		int sum = *ptr1 + *ptr2;
		printf("Tổng 2 số là %d\n\n",sum);
		break;
		case 2:
		printf("Bài tập 2: In mảng theo chiều ngược lại\n");
		arr = create_arr();
		for(int j = (sizeof(*arr)-1); j>=0;j--){
		printf("%d \t",arr[j]);
		};
		printf("\n");
		break;
		case 3:
		arr = create_arr();
		printf("Tổng các phần tử trong array là %d\n",sum_arr(arr));
		break;
	}
}
int main(){
	int choice =1, *arr;
	while(choice != 0){
		perform(&choice,arr);
		printf("\n\n");
	};
	return 0;
}
