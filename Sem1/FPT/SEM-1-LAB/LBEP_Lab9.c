#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Student{
	char name[40];
	char stu_class[40];
	int mark;
};
struct Time{
	int hour;
	int minutes;
	int second;
}clock1,clock2;
void period(struct Time* time1,struct Time* time2){
	int pHour,pMinutes,pSecond;
	if(((*time1).hour<1 ||(*time1).hour>24)&&((*time2).hour<1||(*time2).hour>24)){
		printf("\nNhập giờ sai, giờ từ 1-24!!!\n");
	}else if(((*time1).minutes<0 ||(*time1).minutes>59)&&((*time2).minutes<0||(*time2).minutes>59)){
		printf("\nNhập phút sai, 1 giờ có 60 phút (0-59p)!!\n");
	}else if(((*time1).second<0 ||(*time1).second>59)&&((*time2).second<0||(*time2).second>59)){
		printf("\nNhập giây sai, 1 phút có 60 giây (0-59s)!!\n");
	}else{
		if((*time1).hour<=(*time2).hour){
			pHour = time2->hour - time1->hour;
		}else{
			pHour = (24 - time1->hour) + time2->hour;
		};
		if(time1->second != 0 ){
			time1->minutes++;
		}
		pSecond = (60 -time1->second)+time2->second;
		pMinutes = (60 - time1->minutes) +time2->minutes;
		if(pMinutes >= 60){
			pMinutes = 60 - pMinutes;
		};
		if(pSecond >= 60){
			pSecond = 60 - pSecond;
		};
		if(pMinutes != 0){
			pHour--;
		};
		printf("\n\tKhoảng thời gian giữa 2 mốc thời gian là %d h/ %d m/ %d s\n\n",pHour,pMinutes,pSecond);
	};
}
void perform(){
	printf("Bài 1: Sử dụng struct để biểu diễn và hiển thị giờ phút, giây và tính khoảng thời gian giữa 2 mốc thời gian (h/m/s)\n");
	printf("Bài 2: Chương trình quản lý sinh viên\n");
	printf("\t Nhấn 0 để thoát chương trình\n");
}
int main(){
	int choice1 = 1,choice2=1,hour,minute,second,num1,num2,num;
	char str[40];
	struct Student *stu;
	while(choice1 != 0){
		perform();
		printf("Chọn bài: ");
		scanf("%d",&choice1);
		switch(choice1){
			case 1:
				printf("Nhập mốc thời gian 1(h-m-s): ");
				scanf("%d %d %d",&hour,&minute,&second);
				struct Time clock1 = {hour,minute,second};
				printf("Nhập mốc thời gian 2(h-m-s): ");
				scanf("%d %d %d",&hour,&minute,&second);
				struct Time clock2 = {hour,minute,second};
				printf("\tMốc thời gian 1: %d h/ %d m/ %d s\n\tMốc thời gian 2: %d h/ %d m/ %d s\n",clock1.hour,clock1.minutes,clock1.second,clock2.hour,clock2.minutes,clock2.second);
				period(&clock1,&clock2);
				break;
			case 2:
				printf("Nhập số sinh viên bạn muốn cho vào danh sách: ");
				scanf("%d",&num1);
				stu =(struct Student *) malloc(num1*sizeof(struct Student));
				for(int i =0 ; i< num1 ;i++){
					getchar();
					printf("\nNhập tên sinh viên %d: ",i+1);
					gets((stu+i)->name);
					printf("Nhập lớp: ");
					gets((stu + i)->stu_class);
					printf("Nhập điểm: ");
					scanf("%d", &(stu+i)->mark);
					printf("____________________________\n");
				};
				printf("\tNo | \t Name | \t Class |\t Mark\n");
				for(int i = 0; i<num1;i++){
					printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
				};
				while(choice2 != 0){
					printf("\n1. Thêm sinh viên\t2. Tìm kiếm sinh viên\t3. Chỉnh sửa thông tin sinh viên\n Nhập 0 để thoát\n");
					scanf("%d",&choice2);
					switch(choice2){
						case 1:
							printf("Nhập số sinh viên bạn muốn thêm: ");
							scanf("%d",&num2);
							stu = (struct Student *)realloc(stu,num2*sizeof(struct Student));
							for(int i = num1;i<num2+num1;i++){
								getchar();
								printf("____________________________\n");
								printf("\nNhập tên sinh viên %d:",i+1);
								gets((stu+i)->name);
								printf("Nhập lớp: ");
								gets((stu+i)->stu_class);
								printf("Nhập điểm: ");
								scanf("%d",&(stu+i)->mark);
							};
							printf("\tNo | \t Name |\tClass | \t Mark\n");
							num1 += num2;
							for(int i = 0; i<num1;i++){
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
							};
							break;
						case 2:
							getchar();
							printf("Nhập tên sinh viên muốn tìm kiếm: ");
							int count = 0;
							gets(str);
							for(int i = 0; i<num1;i++){
								if(strstr((stu+i)->name,str)){
								printf("\tNo | \t Name |\tClass | \t Mark\n");
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
								count++;
								};
							};
							if(count == 0){
								printf("\nKhông tìm thấy tên sinh viên trong danh sách\n");
							};
							break;
						case 3:
							getchar();
							printf("Nhập tên sinh viên muốn chỉnh sửa: ");
							gets(str);
							for(int i = 0; i<num1;i++){
								if(strstr((stu+i)->name,str)){
									printf("1. Sửa tên\t 2.Sửa điểm \t 3. Sửa lớp\n");
									scanf("%d",&num);
									getchar();
									switch(num){
										case 1:
											printf("Nhập tên mới: ");
											gets(str);
											strcpy((stu+i)->name,str);
											break;
										case 2:
											printf("Nhập điểm mới: ");
											scanf("%d",&(stu+i)->mark);
											break;
										case 3:
											printf("Nhập lớp mới: ");
											gets(str);
											strcpy((stu+i)->stu_class,str);
											break;
										default:
											printf("\nError!!\n");
											break;
									};
								}
							};
							printf("\tNo | \t Name | \t Class | \t Mark\n");
							for(int i =0; i<num1;i++){
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
							};
							break;
						default:
							printf("\nNhập sai số!!\nVui lòng nhập lại!\n");
							break;
					}
				}
				break;
			case 0:
				printf("\n\t Goodbye!!\n");
				break;
			default:
				printf("\n\tSố bài không có!Vui lòng nhập lại!\n");
				break;
		}
	}
	return 0;
}
