#include <stdio.h>
int main(){
	int num,num1,num2,sum2, count = 0;
	double x1,x2,sum;
	double x[3];
	printf("Bài 1: Tính tổng 2 số thực \nNhập 2 số thực: ");
	scanf("%lf %lf",&x1,&x2);
	sum = x1 + x2;
	printf("Tổng là %.2f\n\n",sum);
	printf("Bài 2: Đếm số lượng chữ của số nguyên dương\nNhập số nguyên dương: ");
	scanf("%d",&num);
	sum2 = num;
	while(num > 0){
		num/=10;
		count++;
	};
	printf("Số ký tự số của số %d là %d\n\n",sum2,count);
	printf("Bài 3: Kiểm tra 2 số nhập vào có cùng dấu hay không\nNhập 2 số ");
	scanf("%d %d",&num1,&num2);
	if(num1 >= 0 && num2 >= 0){
		printf("Hai số cùng dương\n\n");
	}else if(num1 < 0 && num2 < 0){
		printf("Hai số cùng âm\n\n");
	}else {
		printf("Hai số trái dấu\n\n");
	};
	printf("Bài 4: Kiểm tra tháng thuộc quý mấy trong năm.\nNhập tháng: ");
	scanf("%d",&num);
	switch(num){
		case 1: case 2: case 3:
			printf("Tháng %d thuộc quý 1\n\n",num);
			break;
		case 4: case 5: case 6:
			printf("Tháng %d thuộc quý 2\n\n",num);
			break;
		case 7: case 8: case 9:
			printf("Tháng %d thuộc quý 3\n\n",num);
			break;
		case 10: case 11: case 12:
			printf("Tháng %d thuộc quý 4\n\n",num);
			break;
	};
	printf("Bài 5: Tính tổng các chữ số nguyên dương ");
	scanf("%d",&num);
	sum2 = 0;
	while(num>0){
		sum2 += num%10;
		num /= 10;
	};
	printf("Tổng  = %d \n\n",sum2);
	printf("Bài 6: Đổi tất cả các số âm bằng giá trị tuyệt đối của nó\n ");
	for(int i = 0; i< 3;i++){
		printf("Nhập số %d: ",i+1);
		scanf("%lf",&x[i]);
	};
	for(int i = 0; i< (sizeof(x)/sizeof(double));i++){
		if(x[i]<0){
			x[i] = 0 -x[i];
		};
		printf("%lf ",x[i]);
	};
	printf("\n");
	return 0;
}
