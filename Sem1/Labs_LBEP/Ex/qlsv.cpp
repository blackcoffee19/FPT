#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
 
typedef struct {
    char name[30];
    char classroom[10];
    float mark;
 
} *PSTUDENT, STUDENT;
 
void inputStudent(PSTUDENT pStudent, int total);
void printStudent(STUDENT student);
void searchStudent(PSTUDENT pStudent, int total);
void updateStudent(PSTUDENT pStudent, int total);
 
int main() {
    PSTUDENT pStudent;
    int totalStudent;
    int sel;
    char c;
    printf("Input total Student: ");
    scanf("%d", &totalStudent);
    
    pStudent = new STUDENT[totalStudent];
	// khoi tao gia tri mac dinh cho danh sach STUDENT    
    memset(pStudent, NULL, totalStudent*sizeof(STUDENT));
    // Nhap thong tin sinh vien
    inputStudent(pStudent, totalStudent);
 	// menu
    do {
        printf("\n1. Search Student");
        printf("\n2. Update Student");
        printf("\nChoose: ");
        scanf("%d", &sel);
        switch(sel) {
        case 1:
            //Tim kiem sinh vien
            searchStudent(pStudent, totalStudent);
            break;
        case 2:
            //Chinh sua thong tin sinh vien
            updateStudent(pStudent, totalStudent);
            break;
        }
        printf("\nDo you want to continue: (y/n)?");
        fflush(stdin);
        c = getchar();
    } while(c == 'y'|| c == 'Y');
    getch();
}
 
void inputStudent(PSTUDENT pStudent, int total) {
    int i;
    printf("\n==================Input Student====================\n");
    for(i = 0; i < total; i++) {
        printf("\nStudent [%d]\n", i+1);
        printf("\nStudent Name : ");
        fflush(stdin);
        gets(pStudent[i].name);
        printf("\nClass: ");
        //fflush(stdin);
        gets(pStudent[i].classroom);
        printf("\nMark: ");
        scanf("%f", &pStudent[i].mark);
        printf("\n========================================================");
    }
}
 
// Ham tim kiem thong tin sv
void searchStudent(PSTUDENT pStudent, int total)
{
    int sel;
    int i;
    float totalMark;
    char name[30];
    char classroom[10];
    printf("\n==================Search Student===============");
    printf("\n1. Search by Name");
    printf("\n2. Search by Class\n");
    scanf("%d", &sel);
    switch(sel) {
    case 1:
        printf("\nInput student name: ");
        fflush(stdin);
        gets(name);
        for(i = 0; i < total; i++) {
            if(strcmp(name, pStudent[i].name) == 0) {
                //in ra thong tin sinh vien
                printStudent(pStudent[i]);
            }
        }
        break;
    case 2:
        printf("\nInput class name: ");
        fflush(stdin);
        gets(classroom);
        for(i = 0; i < total; i++) {
            if(strcmp(classroom, pStudent[i].classroom) == 0) {
                //in ra thong tin sinh vien
                printStudent(pStudent[i]); 
            }
        }
        break;
    } 
}
 
// Ham sua thong tin sv
void updateStudent(PSTUDENT pStudent, int total) {
    int i;
    char name[30];
    printf("\n===============Update Student================");
    printf("\nInput student name: ");
    fflush(stdin);
    gets(name);
 
    for(i = 0; i < total; i++) {
        if(strcmp(name, pStudent[i].name) == 0) {
            printf("\nUpdate student: %s", pStudent[i].name);
            printf("\nclass: ");
            fflush(stdin);
            gets(pStudent[i].classroom);
            printf("\nmark: ");
            scanf("%f", &pStudent[i].mark);
        }
    }
}
// Ham hien thi thong tin sv
void printStudent(STUDENT student) {
    printf("\nName\t\t\t\t| Class\t\t| Mark\t|");
    printf("\n---------------------------------------------------------");
    printf("\n%-30s\t| %s\t\t| %0.1f\t|", student.name, student.classroom, student.mark);
    printf("\n---------------------------------------------------------");
}
