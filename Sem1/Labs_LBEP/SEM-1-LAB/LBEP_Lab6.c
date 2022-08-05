#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
void giatriam(int *p,int num){
	for(int i = 0; i<num;i++){
		if(p[i] < 0){
			printf("%d \t",p[i]);
		};
	};
	printf("\n");
}
int search_min(int *p,int num){
	int min = 0;
	for(int i = 1;i<num;i++){
		if(p[i-1] > p[i]){
			min = i;
		}
	};
	return min;
}
void sort(int *p,int num){
	int temp;
	for(int i = 0; i<num-1;i++){
		for(int j = i+1; j<num;j++){
			if(p[i]>p[j]){
				temp = p[i];
				p[i] = p[j];
				p[j] = temp;
			}
		}
	}
}
void big_small(int *p,int num){
	int temp;
	for(int i = 0;i <num-1;i++){
		for(int j = i+1; j<num;j++){
			if(*(p+i)<*(p+j)){
				temp = p[i];
				p[i] = p[j];
				p[j] = temp;
			}
		}
	}
}
void add_element(int *p,int num1){
	int k, num;
	printf("\n\t Thêm 1 phần tử vào vị trí: ");
	scanf("%d",&k);
	printf("\n\t Phần tử thứ %d là: ",k);
	scanf("%d",&num);
	p = (int *)realloc(p,k*sizeof(int));
	*(p+k-1) = num;
	printf("\n \t Array => [\n");
	for(int i = 0; i< k;i++){
		printf("\t %d => %d\n",i,*(p+i));
	};
	printf(" \t ]\n\n");
}
int search_even(int *p, int num){
	int even =0;
	for(int i = 0; i<num;i++){
		if(*(p+i)%2==0){
			even = p[i];
			break;
		}
	};
	if(even ==0){
		printf("Khong co so chan trong mang\n");
		even = 0;
	}
	return even;
}
void delete_el(int *p,int num){
	int num1;
	printf("Xóa phần tử tại vị trí: ");
	scanf("%d",&num1);
	if(num1<0 ||num1>num){
		printf("Mảng có chiều dài là %d nen không thể xóa phần tử tại vị trí %d\n",num,num1);
	}else {
		p[num1-1] = 0;
	}
}
int main(){
	int choice = 1,num,*arr,min;
	while(choice != 0){
		printf("\nBài 1: Tìm giá trị âm trong mảng 1  chiều\n");
		printf("Bài 2: Tìm vị trí của phần tử nhỏ nhất  trong mảng 1  chiều\n");
		printf("Bài 3: Sắp xếp mảng 1 chiều theo các số thực tăng dần\n");
		printf("Bài 4: Thêm 1 phần tử x vào mảng tại vị trí k\n");
		printf("Bài 5: Tìm giá trị nhỏ nhất trong mảng 1 chiều\n");
		printf("Bài 6: Tìm số chẵn đầu tiên trong mảng các số nguyên\n");
		printf("Bài 7: Liệt kê các số âm trong mảng 1 chiều\n");
		printf("Bài 8: Sắp xếp mảng 1 chiều theo thứ tự giảm dần\n");
		printf("Bài 9: Xóa 1 phần tử x tại vị trí k của mảng 1 chiều\n");
		printf("\tChọn 0 để kết thúc chương trình\n");
		printf("Chọn bài: ");
		scanf("%d",&choice);
		if(choice == 0){
			break;
		};
		printf("\nNhập chiều dài mảng:");
		scanf("%d",&num);
		arr =(int*)malloc(num*(sizeof(int)));
		for(int i = 0; i<num;i++){
			printf("Nhập số thứ %d: ",i+1);
			scanf("%d",arr+i);
		};
		switch(choice){
			case 1:
				printf("\nSố âm là: ");
				giatriam(arr,num);
				break;
			case 2:
				min = search_min(arr,num);
				printf("\nSố có giá trị ở vị trí index [%d] là nhỏ nhất ( %d)\n",min, arr[min]);
				break;
			case 3:
				sort(arr,num);
				printf("Array = [");
				for(int i = 0; i <num;i++){
					printf("%d, ",arr[i]);
					};
				printf("] \n");
				break;
			case 4:
				add_element(arr,num);
				break;
			case 5:
				min = search_min(arr,num);
				printf("\nSố có giá trị ở vị trí index [%d] là nhỏ nhất ( %d)\n",min, arr[min]);
				break;
			case 6:
				int e = search_even(arr,num);
				printf("\nSố chẵn đầu tiên trong mảng là: %d\n",e);
				break;
			case 7:
				printf("Các số âm là: ");
				giatriam(arr,num);
				break;
			case 8:
				big_small(arr,num);
				printf("\n\t\tArray = [");
				for(int i =0; i<num;i++){
					printf(" %d,",arr[i]);
				};
				printf("]\n\n");
				break;
			case 9:
				delete_el(arr,num);
				printf("\n\t\tArray = [");
				for(int i =0; i<num;i++){
					printf(" %d,",arr[i]);
				};
				printf("]\n\n");
				break;
			default:
				printf("Nhập sai số!\n");
				break;
		}
		free(arr);
	}
}
