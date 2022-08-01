#include <stdio.h>
#include <string.h>
struct Book{
	char name[40];
	int quantity;
	int price;
};
void factoria(int* num){
	int num2 = *num;
	while(num2>1){
		num2--;
		(*num) *= num2;
	};
}

void perform(){
	printf("************************************\n");
	printf("C Program language\n");
	printf("\t1. Question 02.\n");
	printf("\t2. Question 03.\n");
	printf("\t3. Exit.\n");
	printf("************************************\n");
	printf("Enter Choice (1-3): ");
}
void question2(){
		int num2;
		printf("Enter an integer: ");
		scanf("%d",&num2);
		int number = num2;
		factoria(&num2);
		printf("Factoria: %d! = %d\n",number, num2);
}
void question3(){
	int num2,num3,num4;
	char a;
	double x,y;
	printf("How many books would you like to manage: ");
		scanf("%d",&num2);
		while(num2 > 10){
			printf("The number is invalid! Please any key to continue\n");
			scanf("%c",&a);
			printf("How many books would you like to manage: ");
			scanf("%d",&num2);
		};
		struct Book arr_book[num2];
		for(int i= 0; i < num2; i++){
			struct Book book;
			int num = i+1;
			char str[40];
			printf("Enter book %d name: ",num);
			scanf("%s",book.name);
			printf("Enter quantity: ");
			scanf("%d",&num3);
			book.quantity = num3;
			printf("Enter Unit price: ");
			scanf("%d",&num4);
			book.price = num4;
			printf("\n");
			arr_book[i] = book;
		};
		printf("\nBook List Information: \n");
		printf("No\tName\tQuantity Price Amount\n");
		printf("__|____________|_______|_______|______\n");
		for(int i = 0; i < num2;i++){
			int am = arr_book[i].quantity * arr_book[i].price;
			int j = i+1;
			printf("%d \t %s \t %d \t %d \t %d\n",j,arr_book[i].name,arr_book[i].quantity,arr_book[i].price,am);
		}
}
int main() {
	int num =1;
	while(num != 3){
	perform();
	scanf("%d",&num);
	if(num == 1){
		question2();
	} else if(num == 2){
		question3();
	}else if(num == 3){
		break;
	}else {
		printf("Nhập sai số\n Vui lòng chọn lại \n");
		perform();
	};
	}
}
