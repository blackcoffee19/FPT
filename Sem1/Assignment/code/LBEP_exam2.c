#include <stdio.h>
#include <math.h>
#include <string.h>
struct Student{
	char name[50];
	char roolno[50];
	int marks;
};
void perform(){
	printf("\n**************************************\n");
	printf("\tC PROGRAM LANGUAGE\n");
	printf("\t\t 1. Question 02.\n");
	printf("\t\t 2. Question 03.\n");
	printf("\t\t 3. Exit.\n");
	printf("**************************************\n");
	printf("\t Enter Choice (1 - 3):");

}
void is_Armstrong(int num){
	int s = 1, count =0, sum = 0;
	while(s < num){
		s *= 10;
		count++;
	};
	s = 1;
	while(s<num){
		int a = floor((num/s)%10);
		sum += pow(a,count);
		s*=10;
	};
	if(sum == num){
		printf("\t %d is an Armstrong number!\n",num);
	}else{
		printf("\t %d is not an Armstrong number!\n",num);
	};
}
struct Student create_Stu(int i){
	struct Student stu;
		printf("\nEnter student %d name: ",i);
		scanf("%s",stu.name);
		getchar();
		printf("Enter Rollno: ");
		scanf("%s",stu.roolno);
		getchar();
		printf("Enter marks: ");
		scanf("%d",&stu.marks);
	return stu;
}
void printInf(struct Student list_stu[],int num){
	printf("\nStudent List Information:\n");
	printf("\t Rollno \t Name \t Marks\n");
	for(int i = 0;i<num;i++){
		printf("\n\t %s \t\t %s \t %d\n",list_stu[i].roolno,list_stu[i].name,list_stu[i].marks);
	};
}
void search(struct Student list[], char roll[50],int num){
	printf("\nStudent List Information:\n");
	printf("\t Rollno \t Nam \t Marks\n");
	for(int i = 0; i < num;i++){
		int x = strcmp(list[i].roolno,roll);
		if(x == 0){
			printf("\n\t %s \t\t %s \t %d\n",list[i].roolno,list[i].name,list[i].marks);
			break;
		};
	};
}
int main(){
	int choice = 1;
	int n = 10, i =1,num;
	int sum=0;
	char ans;
	char stu_roll[50];
	while(choice != 3){
		perform();
		scanf("%d",&choice);
		if(choice == 1){
			printf("Enter an integer: ");
			scanf("%d",&num);
			is_Armstrong(num);
		} else if(choice == 2){
			printf("How many students would you like to manage: ");
			scanf("%d",&num);
			while(num > 5){
				printf("The number is invalid! Max is 5\n \t Try again!\n");
				printf("How many students would you like to manage: ");
				scanf("%d",&num);
			};
			struct Student list_stu[num];
			for(int i = 0; i<num; i++){
				list_stu[i] = create_Stu(i+1);
			};
			getchar();
			printf("\nDo you want to list all students's information?\t Yes | No (y/n): ");
			scanf("%c",&ans);
			if(ans == 'y'){
				printInf(list_stu,num);
			};
			getchar();
			printf("\nEnter Rollno to search: ");
			scanf("%s",stu_roll);
			printf("Rollno strudent you wanna find is %s ?\n",stu_roll);
			search(list_stu,stu_roll,num);
		} else if(choice == 3){
			printf("\n \t \t Goodbye!\n");
		} else {
			printf("\nWrong number! Try again!\n");
			getchar();
		};
	}
}
