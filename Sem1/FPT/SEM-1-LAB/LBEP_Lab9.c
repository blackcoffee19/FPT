#include <stdio.h>
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
		pMinutes = (60 - time1->minutes) +time2->minutes;
		pSecond = (60 - time1->second) +time2->second;
		if(pMinutes == 60){
			pMinutes = 0;
		};
		if(pSecond == 60){
			pSecond = 0;
		};
		if(pMinutes != 0 || pSecond != 0){
			pHour--;
		};
		printf("\n\tKhoảng thời gian giữa 2 mốc thời gian là %d h/ %d m/ %d s\n\n",pHour,pMinutes,pSecond);
	};
}
void perform(){
	printf("Bài 1: Sử dụng struct để biểu diễn và hiển thị giờ phút, giây và tính khoảng thời gian giữa 2 mốc thời gian (h/m/s)\n");
}
int main(){
	int choice1 = 1,hour,minute,second;
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
		}
	}
}
