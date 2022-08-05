#include <stdio.h>
#include <math.h>
#include <stdbool.h>
#include <string.h>
bool is_leap_year(int year){
	bool check = true;
	if(year%4 != 0){
		check = false;
	}else {
		if(year%100 == 0 && year%400 != 0){
			check = false;
		}else {
			printf("\n\t Năm %d là năm nhuận!!!\n",year);
			check = true;
		}
	};
	return check;

}
void chuso(int num){
	switch(num){
		case 1:
			printf("một");
			break;
		case 2:
			printf("hai");
			break;
		case 3:
			printf("ba");
			break;
		case 4:
			printf("bốn");
			break;
		case 5:
			printf("lăm");
			break;
		case 6:
			printf("sáu");
			break;
		case 7:
			printf("bảy");
			break;
		case 8:
			printf("tám");
			break;
		case 9:
			printf("chín");
			break;
		default:
			printf("\n");
			break;
	};
}

int main(){
	int a, b,c, month,year,num;
	double x,y,z,temp;
	char str2[40];
	/*printf("Bài 1: Viết phương trình giải hàm bậc nhất ax + b = 0\n");
	printf("Nhập số a, b: ");
	scanf("%d %d",&a,&b);
	printf("Phương trình ta có : %dx + %d = 0\n",a,b);
	x = -b/a;
	printf("X = %.2lf\n\n",x);
	printf("Bài 2: Nhập 3 cạnh của 1 tam giác :");
	scanf("%d %d %d",&a,&b,&c);
	if((a+b)< c || (a + c)<b || (b+c)<a){
		printf("3 cạnh: %d %d và %d  không thể tạo thành 1 tam giác\n\n",a,b,c);
	} else if(a == b || a == c || b == c){
		if(c == sqrt(a*a + b*b) || a == sqrt(b*b + c*c) || b == sqrt(a*a + c*c)){
			printf("Đây là một tam giá vuông cân\n\n");
		}else {
		printf("Đây là một tam giá cân!\n\n");
		};
	}else if(c == sqrt(a*a + b*b)|| a == sqrt(b*b + c*c)|| b == sqrt(a*a + c*c)){
		printf("Đây là một tam giác vuông!\n\n");
	}else{
		printf("Đây là một tam giác bình thường\n\n");
	};
	printf("Bài 3: Sắp xếp 3 số thực được nhập vào theo thứ tự tăng dần\nNhập 3 số thực: ");
	scanf("%lf %lf %lf",&x,&y,&z);
	if(x <= y && x <= z){
		printf("\n%.2lf \t",x);
		if(y<=z){
			printf("%.2lf \t %.2lf\n\n",y,z);
		}else{
			printf("%.2lf \t %.2lf\n\n",z,y);
		}
	}else if(y<=x && y<= z){
		printf("\n%.2lf \t",y);
		if(x <= z){
		printf("%.2lf \t %.2lf\n\n",x,z);
		}else {
		printf("%.2lf \t %.2lf\n\n",z,x);
		};
	}else if(z <= x && z <= y){
		printf("\n%.2lf \t",z);
		if(y<=x){
		printf("%.2lf \t %.2lf\n\n",y,x);
		}else{
		printf("%.2lf \t %.2lf\n\n",x,y);
		}
	};
	printf("Bài 4: Nhập tháng, năm cho biết tháng đó có bao nhiêu ngày \nNhập tháng: ");
	scanf("%d",&month);
	printf("Nhập năm: ");
	scanf("%d",&year);
	switch(month){
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			printf("Tháng %d năm %d có 31 ngày!\n\n",month,year);
			break;
		case 4: case 6: case 9: case 11:
			printf("Tháng %d năm %d có 30 ngày!\n\n ",month, year);			break;
		case 2:
			if(is_leap_year(year)){
				printf("Tháng %d năm %d có 29 ngày!\n\n",month,year);
			}else{
				printf("Tháng %d năm %d có 28 ngày!\n\n", month, year);
			};
			break;
		default:
			printf("Nhập sai tháng!!\n\n");
			break;
	};

	printf("Bài 5: Cho biết tháng thuộc quý mấy trong năm\nNhập tháng: ");
	scanf("%d",&month);
	switch(month){
		case 1: case 2: case 3:
			printf("Tháng %d thuộc quý 1\n\n",month);
			break;
		case 4: case 5: case 6:
			printf("Tháng %d thuộc quý 2\n\n",month);
			break;
		case 7: case 8: case 9:
			printf("Tháng %d thuộc quý 3\n\n", month);
			break;
		case 10: case 11: case 12:
			printf("Tháng %d thuộc quý 4\n\n",month);
			break;
		default:
			printf("Không có tháng %d trong 1 năm!\n\n", month);
			break;
	};*/
	printf("Bài 6: Nhập số nguyên có 2 chữ số, in ra cách đọc của số nguyên\nNhập số nguyên : ");
	scanf("%d", &num);
	if(num<10 || num >= 1000){
		printf("Số nguyên có 2 chữ số!!!\n\n");
	}else{
		for(int i = 2; i>= 0;i--){
			a = num/pow(10,i);
			chuso(a);
			if(a > 0 && num%((int)pow(10,i)) >10){
				printf(" trăm ");
			}else if (a > 0 && num%((int)pow(10,i)) > 0){
				printf(" mươi ");
			}else {
				printf("\n");
			};
			num -= a*pow(10,i);
		}
	};
	return 0;
}
