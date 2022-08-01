#include <stdio.h>
#include <stdbool.h>
bool is_not_prime(int num){
	bool check = false;
	for(int i = 1;i<num;i++){
		for(int j = num-1; j>=i;j--){
			int num2 = i*j;
			if(num2 == num){
				printf("=> %d x %d = ",i,j);
				check = true;
			}
		}
	}
	return check;
}
int uocso(int num1,int num2){
	int max = 0;
	for(int i = 1; i<= num1;i++){
		if(num1%i == 0 && num2 %i == 0){
			max = i;
		}
	};
	return max;
}
void can_dac(int num){
	for(int i = 0; i<num;i++){
		printf("\t \t");
		for(int j = 0; j<num-i; j++){
			printf(" ");
		}
		for(int j=0;j<=i;j++){
			printf("*");
		};
		for(int j = 0;j<i;j++){
			printf("*");
		}
		printf("\n");
	}

}
void can_rong(int num){
	for(int i =0;i<num-1;i++){
		printf("\t \t");
		for(int j = 0; j<num-i;j++){
			printf(" ");
		}
		printf("*");
		for(int j = 0; j<i;j++){
			printf(" ");
		};
		for(int j = 0; j< i;j ++){
			printf(" ");
			if(j == i-1){
				printf("*");
			}
		};
		printf("\n");
	};
	printf("\t \t ");
	for(int i = 0; i<num;i++){
		printf("**");
	};
	printf("\n");

}
void vuong_dac(int num){
	for(int i = 0; i < num ;i++){
		printf("\t\t");
		for(int j = 0; j<num-i;j++){
			printf("  ");
		};
		for(int j = 0; j<=i;j++){
			if(j == i){
			printf("*");
			}else{
			printf("**");}
		};
		printf("\n");
	}

}
void vuong_rong(int num){
	for(int i = 0; i< num-1;i++){
		printf("\t\t");
		for(int j = 0; j<num-i-1;j++){
			printf("  ");
		};
		printf("*");
		for(int j = 0; j<i;j++){
			printf("  ");
		};
		if(i == 0){
			printf("\n");
		}else {
			printf("*\n");
		};
	};
	printf("\t\t");
	for(int j = 0; j<num;j++){
		printf("**");
	};
	printf("\n");

}
void currency(int num){
	int num2,num3,num4;
	int arr[] = {1000,2000,5000};
	int count= 0;
	for(int i = 0; i < sizeof(arr)/sizeof(int); i++){
		if(num%arr[i] == 0){
			printf("Cách %d: \n",count+1);
			count++;
			printf("Số tiền %d cần %d tờ %d đồng\n\n",num,num/arr[i],arr[i]);
		}else{
			num2 = num/arr[i];
			num3 = num%arr[i];
			if(num2 != 0){
			printf("Cách %d:\n%d cần %d tờ %d đồng+\n",count+1,num,num2,arr[i]);
			while(num3 > 0){
				if(num3 >= 5000){
					num4 = num3/5000;
					num3 = num3%5000;
				printf("%d cần %d tờ %d đồng+\n",num,num4,5000);
				}else if(num3 >= 2000){
					num4 = num3/2000;
					num3 = num3%2000;
				printf("%d cần %d tờ %d đồng+\n",num,num4,2000);
				}else if(num3 >= 1000){
					num4 = num3/1000;
					num3 = num3%1000;
				printf("%d cần %d tờ %d đồng+\n",num,num4,1000);
				}else {
				printf("Dư %d đồng\n\n",num3);
				break;
				};
			};
			count++;}else{continue;}
		}
		printf("\n");
	};
		printf("Tổng: %d cách\n",count);
}
void cn_dac(int m, int n){
	for(int i = 0; i< n; i++){
		printf("\t\t");
		for(int j = 0; j<m;j++){
			printf("**");
		};
		printf("\n");
	}
}
void cn_rong(int m, int n){
	for(int i = 0; i< n; i++){
		printf("\t\t *");
		for(int j = 0; j<m;j++){
			if(i == 0 || i == n-1){
				printf("**");
			}else{
				printf("  ");
			};
		};
		printf("*\n");
	}

}
int tinh_tong(int num){
	int sum = 0;
	for(int i = num; i>0;i--){
		if(i%2 != 0){
			sum+=i;
		}
	};
	return sum;
}
int main(){
	int num,num1,num2, choice;
	/*printf("Bài 1: Kiểm tra 1 số có phải là số nguyên tố hay không?\n");
	printf("Enter any number: ");
	scanf("%d",&num);
	if(!is_not_prime(num)){
		printf("%d is a prime number\n",num);
	}else{
		printf("%d is not a prime number\n",num);
	};
	printf("Bài 2: Ước số chung lớn nhất của 2 số nguyên dương\nEnter number 1: ");
	scanf("%d",&num1);
	printf("Enter number 2: ");
	scanf("%d",&num2);
	if(uocso(num1,num2) != 0){
		printf("\nƯớc số chung lớn nhất là: %d\n",uocso(num1,num2));
	}else {
		printf("\nKHông có ước số chung\n");
	};
	*/
	printf("Bài 3: In ra tam giác cân có độ cao h\nEnter height: ");
	scanf("%d",&num);
	printf("1. Tam giác cân đặc nằm giữa màn hình\n");
	printf("2. Tam giác cân rỗng nằm giữa màn hình\n");
	printf("3. Tam giác vuông cân đặc\n");
	printf("4. Tam giác vuông cân rỗng\n");
	printf("Your choice: ");
	scanf("%d",&choice);
	switch(choice){
		case 1:
		can_dac(num);
		break;
		case 2:
		can_rong(num);
		break;
		case 3:
		vuong_dac(num);
		break;
		case 4:
		vuong_rong(num);
		break;
		default:
		printf("\nWrong number!\n");
		break;
	};
	printf("Bài 4: Chương trình đếm tiền\n Nhập số tiền: ");
	scanf("%d",&num);
	currency(num);
	printf("Bài 5: Chương trình in ra hình chữ nhật có kích thước m x n\nEnter m & n: ");
	scanf("%d %d",&num1,&num2);
	printf("1. Hình chữ nhật đặc\n");
	printf("2. Hình chữ nhật rỗng\n");
	printf("Your choice: ");
	scanf("%d",&choice);
	switch(choice){
		case 1:
		cn_dac(num1,num2);
		break;
		case 2:
		cn_rong(num1,num2);
		break;
		default:
		printf("Nhập sai số!\n");
	};
	printf("\nBài 6: Tổng các số nguyên dương nhỏ hơn n\nNhập n: ");
	scanf("%d",&num);
	printf("Tổng các số lẻ nguyên dương nhỏ hơn %d là %d",num,tinh_tong(num));
	return 0;
}
