#include <stdio.h>
#include <stdlib.h>
#include <string.h>
struct Phanso{
	int tu;
	int mau;
};
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
		printf("\nNhap gio sai, gio tu 1-24 h!!!\n");
	}else if(((*time1).minutes<0 ||(*time1).minutes>59)&&((*time2).minutes<0||(*time2).minutes>59)){
		printf("\nNhap phut sai, 1 gio co 60 phut(0-59p)!!\n");
	}else if(((*time1).second<0 ||(*time1).second>59)&&((*time2).second<0||(*time2).second>59)){
		printf("\nNhap giay sai, 1 phut co 60s (0-59s)!!\n");
	}else{
		if((*time1).hour<=(*time2).hour){
			pHour = time2->hour - time1->hour;
		}else{
			pHour = (24 - time1->hour) + time2->hour;
		};
		if(time1->second != 0 ){
			time1->minutes++;
		}
		pSecond = (60 -time1->second)+ time2->second;
		pMinutes = (60 - time1->minutes) +time2->minutes;
		if(pMinutes >= 60){
			pMinutes = pMinutes%60;
		};
		if(pSecond >= 60){
			pSecond = pSecond%60;
		};
		if(pMinutes != 0){
			pHour--;
		};
		printf("\n\tKhoang thoi gian giua 2 moc thoi gian la %d h/ %d m/ %d s\n\n",pHour,pMinutes,pSecond);
	};
}
void Rutgon(int *tu, int *mau){
	int i = 2;
	do{
		if(*tu%i == 0 && *mau%i == 0){
			*tu /= i;
			*mau /= i;
		};
		i++;
	}while(i <= *tu);
}
void Quydong(struct Phanso* ps1,struct Phanso* ps2){
	int mauchung;
	if(ps1->mau != ps2->mau){
		mauchung = ps1->mau*ps2->mau;
		ps1->tu *= ps2->mau;
		ps2->tu *= ps1->mau;
		ps1->mau = mauchung;
		ps2->mau = mauchung;
		//printf("\nMau chung: %d\n",mauchung);
		//printf("\nPhan so thu 1: %d/%d\n\n",ps1->tu,ps1->mau);
		//printf("Phan so thu 2: %d/%d\n\n",ps2->tu,ps2->mau);
	};
}
void Calculator(struct Phanso *p1,struct Phanso *p2){
	int tu1,mau1,i = 2;
	if(p1->mau != p2->mau){
		tu1 = ((p1->tu)*(p2->mau))+((p2->tu)*(p1->mau));
		mau1 = (p1->mau)*(p2->mau);
		Rutgon(&tu1,&mau1);
		printf("\n\tTong 2 phan so: %d/%d\n",tu1,mau1);
		tu1 = ((p1->tu)*(p2->mau) -(p2->tu)*(p1->mau));
		mau1 = ((p1->mau)*(p2->mau));
		Rutgon(&tu1,&mau1);
		printf("\n\tHieu 2 phan so: %d/%d\n",tu1,mau1);
		tu1 = (p1->tu)*(p2->tu);
		mau1 = (p1->mau)*(p2->mau);
		Rutgon(&tu1,&mau1);
		printf("\n\tTich 2 phan so: %d/%d\n",tu1,mau1);
		tu1 = (p1->tu)*(p2->mau);
		mau1 = (p1->mau)*(p2->tu);
		Rutgon(&tu1,&mau1);
		printf("\n\tThuong 2 phan so: %d/%d\n",tu1,mau1);
	};
}
void perform(){
	printf("\nBai 1: Su dung struct de bieu dien va hien thi gio phut, giay va tinh khoang thoi gian giua 2 moc thoi gian (h/m/s)\n");
	printf("Bai 2: Chuong trinh quan ly sinh vien\n");
	printf("Bai 3: Chuong trinh thuc hien phep toan tren phan so\n");
	printf("\t Nhap 0 de thoat chuong trinh\n");
}
int main(){
	int choice1 = 1,choice2=1,hour,minute,second,num1,num2,num;
	char str[40];
	struct Student *stu;
	typedef struct Phanso Phanso;
	while(choice1 != 0){
		perform();
		printf("Chon bai: ");
		scanf("%d",&choice1);
		switch(choice1){
			case 1:
				printf("Nhap moc thoi gian 1(h-m-s): ");
				scanf("%d %d %d",&hour,&minute,&second);
				struct Time clock1 = {hour,minute,second};
				printf("Nhap moc thoi gian 2(h-m-s): ");
				scanf("%d %d %d",&hour,&minute,&second);
				struct Time clock2 = {hour,minute,second};
				printf("\tMoc thoi gian 1: %d h/ %d m/ %d s\n\tMoc thoi gian 2: %d h/ %d m/ %d s\n",clock1.hour,clock1.minutes,clock1.second,clock2.hour,clock2.minutes,clock2.second);
				period(&clock1,&clock2);
				break;
			case 2:
				printf("Nhap so sinh vien ban muon them vao danh sach: ");
				scanf("%d",&num1);
				stu =(struct Student *) malloc(num1*sizeof(struct Student));
				for(int i =0 ; i< num1 ;i++){
					getchar();
					printf("\nNhap ten sinh vien %d: ",i+1);
					gets((stu+i)->name);
					printf("Nhap lop: ");
					gets((stu + i)->stu_class);
					printf("Nhap diem: ");
					scanf("%d", &(stu+i)->mark);
					printf("____________________________\n");
				};
				printf("\tNo | \t Name |\tClass |\tMarks\n");
				for(int i = 0; i<num1;i++){
					printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
				};
				while(choice2 != 0){
					printf("\n1. Them sinh vien\t2. Tim kiem sinh vien\t3. Chinh sua thong tin sinh vien \t4. Sap xep sinh vien theo ten tang dan theo bang chu cai\n Nhap 0 de thoat\n");
					scanf("%d",&choice2);
					switch(choice2){
						case 1:
							printf("Nhap so sinh vien ban muon them: ");
							scanf("%d",&num2);
							stu = (struct Student *)realloc(stu,num2*sizeof(struct Student));
							for(int i = num1;i<num2+num1;i++){
								getchar();
								printf("____________________________\n");
								printf("\nNhap ten sinh vien %d:",i+1);
								gets((stu+i)->name);
								printf("Nhap lop: ");
								gets((stu+i)->stu_class);
								printf("Nhap diem: ");
								scanf("%d",&(stu+i)->mark);
							};
							printf("\tNo | \t Name |\tClass |\tMarks\n");
							num1 += num2;
							for(int i = 0; i<num1;i++){
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
							};
							break;
						case 2:
							getchar();
							printf("Nhap ten sinh vien ban muon tim: ");
							int count = 0;
							gets(str);
							for(int i = 0; i<num1;i++){
								if(strstr((stu+i)->name,str)){
								printf("\tNo | \t Name |\tClass |\tMarks\n");
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
								count++;
								};
							};
							if(count == 0){
								printf("\nKhong tim thay sinh vien trong danh sach\n");
							};
							break;
						case 3:
							getchar();
							printf("Nhap ten sinh vien ban muon chinh sua: ");
							gets(str);
							for(int i = 0; i<num1;i++){
								if(strstr((stu+i)->name,str)){
									printf("1. Sua ten\t 2.Sua diem \t 3. Sua lop\n");
									scanf("%d",&num);
									getchar();
									switch(num){
										case 1:
											printf("Nhap ten moi: ");
											gets(str);
											strcpy((stu+i)->name,str);
											break;
										case 2:
											printf("Nhap diem moi: ");
											scanf("%d",&(stu+i)->mark);
											break;
										case 3:
											printf("Nhap lop moi: ");
											gets(str);
											strcpy((stu+i)->stu_class,str);
											break;
										default:
											printf("\nError!!\n");
											break;
									};
								}
							};
							printf("\tNo | \t Name |\tClass |\tMarks\n");
							for(int i =0; i<num1;i++){
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
							};
							break;
							case 4:
							struct Student stu_temp;
							for(int j = 0; j<num1-1;j++){
								for(int i = j+1; i <num1;i++){
									if((stu+i)->name[0]<(stu+j)->name[0] ){
										stu_temp = *(stu+i);
										*(stu+i) = *(stu +j);
										*(stu+j) = stu_temp;
									}
								}
							};
							printf("\tNo | \t Name |\tClass |\tMarks\n");
							for(int i =0; i<num1;i++){
								printf("\t%d \t %s   \t %s \t %d\n",i+1,(stu+i)->name,(stu+i)->stu_class,(stu+i)->mark);
							};
							break;
						default:
							printf("\nNhap sai so!!\nVui long nhap lai!\n");
							break;
					}
				}
				break;
			case 3:
				getchar();
				Phanso ps1, ps2;
				printf("Nhap tu so cua phan so 1: ");
				scanf("%d",&ps1.tu);
				printf("Nhap mau so cua phan so 1: ");
				scanf("%d",&ps1.mau);
				printf("\nPhan so thu 1: %d/%d\n",ps1.tu,ps1.mau);
				printf("Nhap tu so cua phan so 2: ");
				scanf("%d",&ps2.tu);
				printf("Nhap mau so cua phan so 2: ");
				scanf("%d",&ps2.mau);
				printf("\nPhan so thu 2: %d/%d\n",ps2.tu,ps2.mau);
				printf("\n1. Tinh tong, hieu, tich,thuong 2 phan so\n2. Rut gon 2 phan so\n3.Quy dong 2 phan so\n4.So sanh 2 phan so\n\tNhap 0 de thoat\nChon muc: ");
				scanf("%d",&choice2);
				switch(choice2){
					case 1: 
						Calculator(&ps1,&ps2);
						break;
					case 2:
						Rutgon(&ps1.tu,&ps1.mau);
						printf("\nPhan so thu 1 sau khi rut gon la: %d/%d\n\n",ps1.tu,ps1.mau);
						Rutgon(&ps2.tu,&ps2.mau);
						printf("Phan so thu 2 sau khi rut gon la: %d/%d\n\n",ps2.tu,ps2.mau);
						break;
					case 3:
						Quydong(&ps1,&ps2);
						printf("\nPhan so thu 1: %d/%d\n\n",ps1.tu,ps1.mau);
						printf("Phan so thu 2: %d/%d\n\n",ps2.tu,ps2.mau);
						break;
					case 4:
						Quydong(&ps1,&ps2);
						if(ps1.tu == ps2.tu){
							printf("\nHai phan so bang nhau!!\n");
						}else if(ps1.tu >ps2.tu){
							printf("\nPhan so thu nhat lon hon phan so thu hai!\n\n");
						}else{
							printf("\nPhan so thu hai lon hon phan so thu nhat!\n\n");
						};
						break;
					default:
						printf("\nNhap sai so!!\n");
						break;
				}
				break;
			case 0:
				printf("\n\t Goodbye!!\n");
				break;
			default:
				printf("\n\tSo bai khong co!Vui long nhap lai!\n");
				break;
		}
	}
	return 0;
}
