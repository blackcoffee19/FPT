#include <stdio.h>
#include <stdbool.h>
#include <string.h>
#include <stdlib.h>
bool songuyento(int num){
	bool check = true;
	if(num >=2){
	for(int i = 2; i<num;i++){
		if(num%i ==0 && num != i){
			check = false;
			break;
		}
	};}else{check = false;}
	return check;
}
void check_songuyento(){
	int num;
	int m = 0;
	printf("Nhập 1 số nguyên dương: ");
	scanf("%d",&num);
	while(num <= 0){
		printf("Nhập sai !! Vui lòng nhập lại!\n");
		scanf("%d",&num);
	};
	if(songuyento(num)){
		printf("%d là số nguyên tố!!\n",num);
	}
	else{
		printf("%d không phải là số nguyên tố!\n",num);
	}
}
bool is_leap_year(int year){
	bool check = true;
	if(year%4 != 0){
		check = false;
	}else{
		if(year%100 == 0&&year%400!= 0){
		check = false;
		};
	};
	return check;
}
void day_of_month(int *day, int *month, int *year){
	switch(*month){
		case 2:
		if(is_leap_year(*year)){
			*day = 29;
		}else{
			*day = 28;
		}
		break;
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			*day=31;
		break;
		case 4: case 6: case 9: case 11:
			*day = 30;
		break;
		default:
		printf("Wrong month!!");
		*day = 0;
		break;
	};
}
void dmy(int *day,int *month,int *year, int num){
	int _day,_month,_year;
	int num2 = num;
	day_of_month(&_day,month,year);
	while(num > 0){
		if(num>(_day - *day)){
			num -= (_day - *day)+1;
			*day = 1;
			int num3 = (_day - *day)+1;
			*month +=1;
			if(*month >12){
				*month = *month %12;
				*year += 1;
			};
				day_of_month(&_day,month,year);
			printf("\nTrừ %d ngày thành Ngày %d tháng %d năm %d còn %d ngày\n",num3,*day,*month,*year,num);
		}else{
			*day += num;
			num -= *day;
		};
	};
	printf("Sau %d ngày là ngày %d tháng %d năm %d\n",num2,*day,*month,*year);
}
void dssinhvien(int num){
	int num2;
	char arr_str[num][50];
	char str[50] = "";
	for (int i = 0;i<num;i++){
		printf("Nhập tên sinh viên %d: ",i+1);
		scanf("%s",arr_str[i]);
		getchar();
	};
	printf("\tNhấn 1 hiện danh sách sinh vên\n\tNhấn 2 Nhập lại danh sách\\tnNhấn 0 để thoát\n");
	printf("Choose: ");
	scanf("%d",&num2);
	if(num2 == 1){
		for(int i = 0; i<num-1;i++){
			for(int j = i+1;j<num;j++){
				if(arr_str[i][0] > arr_str[j][0]){
				strcpy(str,arr_str[i]);
				strcpy(arr_str[i],arr_str[j]);
				strcpy(arr_str[j],str);
				};
			}
		};
		for(int i = 0; i<num;i++){
			printf("%d.\t %s \n",i+1,arr_str[i]);
		}
	}else if(num2 == 2){
		dssinhvien(num);
	}else{
		printf("\nSee you!\n");
	}
}
void inhoa(char* str){
	for(int i = 0; i< strlen(str);i++){
		if(*(str+i) >=97&&*(str+i) <=122){
			*(str+ i) = *(str+i) -32;
		}
	}
}
bool doixung(char *str){
	bool check = true;
	int i = 0;
	int j = strlen(str)-1;
	while(i<j){
		if(*(str+i) != *(str+j)){
			check = false;
			break;
		};
		i++;
		j--;
	};
	return check;
}
int count_word(char *str){
	int count = 0;
	for(int i = 0; i<strlen(str);i++){
		//printf("\n%c\t%d\n",*(str +i),*(str+i));
		if(*(str+i) == 32){
			count+=1;
		}
	};
	count += 1;
	return count;
}
void doikytu(char *str){
	if(str[0] >= 97 && str[0]<= 122){
		str[0] -= 32;
	};
};
void perform(int * choice){
	int num, day,month,year,k;
	char str1[50],str2[50]="";
	char choice2;
	printf("Bài 1: Kiểm tra 1 số có phải là 1 số nguyên tố\n");
	printf("Bài 2: Liệt kê cá số nguyên tố nhỏ hơn số nhập vào\n");
	printf("Bài 3: Nhập ngày tháng năm , tính ngày tháng năm sau k ngày\n");
	printf("Bài 4: Nối chuỗi\n");
	printf("Bài 5: Nhập danh sách sinh viên và in ra theo thứ tự tăng dần\n");
	printf("Bài 6: Chương trình đổi chuỗi số thành chuỗi bằng hàm atoi\n");
	printf("Bài 7: Đỗi chuổi in thường sang in hoa\n");
	printf("Bài 8: Kiểm tra chuỗi nhập có phải là chuỗi đối xứng hay không\n");
	printf("Bài 9: Đếm số từ trong chuỗi\n");
	printf("Bài 10: Đổi ký tự đầu tiên trong chuỗi thành chữ in hoa\n");
	printf("\t\tNhập 0 để thoát\n");
	printf("Nhập số bài muốn chọn: ");
	scanf("%d",choice);
	switch(*choice){
		case 1:
			check_songuyento();
			printf("\n");
			break;
		case 2:
			printf("Nhập số: ");
			scanf("%d",&num);
			printf("Các số nguyên tố là: ");
			for(int i = 1; i<=num;i++){
				if(songuyento(i)){
					printf("%d,  ",i);
				};
			};
			printf("\n");
		break;
		case 3:
			while(choice2 != 'n')
			{printf("Nhập ngày: ");
			scanf("%d",&day);
			printf("Nhập tháng: ");
			scanf("%d",&month);
			printf("Nhập năm: ");
			scanf("%d",&year);
			printf("\n");
			printf("Ngày bạn nhập là: ngày %d tháng %d năm %d\n\tNhấn \'y\' để tiếp tục, \'c\' để thay đổi ngày hoặc \'n\' để thoát\n",day,month,year);
			getchar();
			scanf("%c",&choice2);
			if(choice2 == 'y'){
				printf("\n\tNhập ngày bạn muốn đếm: ");
				scanf("%d",&k);
				dmy(&day,&month,&year,k);
				break;
			}else if(choice2 == 'c'){
				printf("\nNhập lại: \n");
			}else {printf("\nSee you !\n\n");break;};
			};
			break;
		case 4:
			printf("Nhập số chuỗi bạn muốn nối: ");
			scanf("%d",&num);
			int i =1;
			getchar();
			while(num>0){
				printf("Nhập chuỗi  %d: ",i);
				i++;
				gets(&str1);
				strcat(str2,str1);
				num--;
			};
			printf("Chuỗi là: %s\n",str2);
			break;
		case 5:
			printf("Nhập số sinh viên trong danh sách: ");
			scanf("%d",&num);
			dssinhvien(num);
			break;
		case 6:
			getchar();
			printf("Nhập chuỗi: ");
			gets(&str1);
			num = atoi(str1);
			if(num != 0){
				printf("\n\tSố bạn nhập là: %d\n",num);
			}else{
				printf("\n\tChuỗi bạn nhập chưa phải là chuỗi số\n");
			};
			break;
		case 7:
			getchar();
			printf("Nhập 1 chuỗi bất kỳ bằng chữ thường: ");
			gets(&str1);
			inhoa(str1);
			printf("\n\tChuỗi in hoa là %s\n",str1);
			break;
		case 8:
			getchar();
			printf("Nhập 1 chuỗi: ");
			gets(&str1);
			if(doixung(str1)){
				printf("\n \t\"%s\" là chuỗi đối xứng!\n",str1);
			}else{
				printf("\n\t\"%s\" là chuỗi KHÔNG đối xứng!\n",str1);
			};
			break;
		case 9:
			getchar();
			printf("Nhập 1 câu: ");
			gets(&str1);
			printf("Số từ trong câu là %d\n",count_word(str1));
			break;
		case 10:
			getchar();
			printf("Nhập 1 chuỗi: ");
			gets(&str1);
			doikytu(str1);
			printf("\n\tChuỗi mới là %s\n",str1);
			break;
		case 0:
			printf("\n\t Goodbye!!!\n");
			break;
		default:
			printf("\n\tNhập sai số bài!!\n");
			break;
	}
}
int main(){
	int choice = 1;
	while(choice != 0){
		perform(&choice);
		printf("\n");
	}
	return 0;
}
